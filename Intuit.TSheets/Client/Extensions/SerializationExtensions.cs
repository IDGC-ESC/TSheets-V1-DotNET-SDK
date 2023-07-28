using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Intuit.TSheets.Client.Extensions
{
    internal static class SerializationExtensions
    {
        public static string ToJson<T>(this T obj)
        {
            string json;
            try
            {
                json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            }
            catch (Exception)
            {
                json = null;
            }
            return json;
        }

        public static T FromJson<T>(this object item)
        {
            T result = default;

            if (item != null)
            {
                string json = item.ToJson();
                if (!string.IsNullOrWhiteSpace(json))
                {
                    while (json.StartsWith("{{") && json.EndsWith("}}"))
                    {
                        json = json.Substring(1, json.Length - 2);
                    }

                    result = JsonConvert.DeserializeObject<T>(json);
                }
            }

            return result;
        }

        public static T FromJson<T>(this string json)
        {
            T result = default;
            if (!string.IsNullOrWhiteSpace(json))
            {
                while (json.StartsWith("{{") && json.EndsWith("}}"))
                {
                    json = json.Substring(1, json.Length - 2);
                }

                JObject obj = JObject.Parse(json);
                result = obj.ToObject<T>();
            }
            
            return result;
        }

        public static string GetJson(this JsonReader reader) => reader.ToDictionary().ToJson();

        public static Dictionary<string, object> ToDictionary(this JsonReader reader)
        {
            StringWriter sw = new(new StringBuilder(), CultureInfo.InvariantCulture);
            
            using (JsonTextWriter jsonWriter = new JsonTextWriter(sw))
            {
                jsonWriter.Formatting = JsonSerializer.Create().Formatting;
                try
                {
                    jsonWriter.WriteToken(reader);
                }
                catch (Exception e)
                {
                    while (reader.Read())
                    {
                        jsonWriter.WriteToken(reader);
                    }
                }
            }
            Dictionary<string, object> result = new();

            string json = sw.ToString();
            if (!string.IsNullOrWhiteSpace(json))
            {
                
                result = json.FromJson<Dictionary<string, object>>() ?? new();
            }

            return result;
        }
    }
}
