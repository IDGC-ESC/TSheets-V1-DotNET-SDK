using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Intuit.TSheets.Api;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Intuit.TSheets.Client.Extensions
{
    internal static class SerializationExtensions
    {
        public static List<T> DeserializePathToList<T>(this JObject obj, string path)
        {
            if (obj is null)
            {
                return new();
            }

            if (path.EndsWith(".*"))
            {
                path = path.Substring(0, path.Length - 2);
            }

            JToken token = obj.SelectToken(path);
            List<T> results = token.FromJson<Dictionary<string, T>>().Select(t => t.Value).ToList();
            return results;
        }

        public static string ToJson<T>(this T obj)
        {
            string json = null;
            if (obj is JObject || obj is JToken)
            {
                json = obj.ToString();
            }
            else
            {
                try
                {
                    json = JsonConvert.SerializeObject(obj, Formatting.Indented, DataService.Settings);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            
            return json;
        }

        public static T FromJson<T>(this object item) => item.ToJson().FromJson<T>();

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

                if (result == null)
                {
                    result = JsonConvert.DeserializeObject<T>(json);
                }
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
