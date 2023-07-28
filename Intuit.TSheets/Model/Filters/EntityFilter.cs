// *******************************************************************************
// <copyright file="EntityFilter.cs" company="Intuit">
// Copyright (c) 2019 Intuit
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// </copyright>
// *******************************************************************************

namespace Intuit.TSheets.Model.Filters
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Intuit.TSheets.Client.Serialization.Attributes;
    using Intuit.TSheets.Client.Serialization.Converters;
    using Newtonsoft.Json;

    /// <summary>
    /// Common base class for all entity filters. Converts properties into a dictionary
    /// for easy construction of URL query parameter strings.
    /// </summary>
    public abstract class EntityFilter : IEntityFilter
    {
        private static JsonSerializerSettings settings;

        protected static JsonSerializerSettings Settings
        {
            get
            {
                if (settings == null)
                {
                    settings = new();
                    settings.Converters.Add(new BoolStringConverter());
                    settings.Converters.Add(new DateFormatConverter());
                    settings.Converters.Add(new DateTimeFormatConverter());
                    settings.Converters.Add(new EmptyArrayObjectConverter());
                    settings.Converters.Add(new EnumerableToCsvConverter());
                    settings.Converters.Add(new SerializationConverter(typeof(NoSerializeOnCreateAttribute), typeof(NoSerializeOnWriteAttribute)));
                    settings.Converters.Add(new TimeFormatConverter());
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    settings.MissingMemberHandling = MissingMemberHandling.Ignore;
                    settings.CheckAdditionalContent = false;
                }
                return settings;
            }
        }

        /// <summary>
        /// Generates a set of key/value pairs from the properties of a EntityFilter object.
        /// </summary>
        /// <returns>The set of key/value pairs</returns>
        public virtual Dictionary<string, string> GetFilters()
        {
            var props = GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => p.GetCustomAttribute<JsonIgnoreAttribute>() == null);
            Dictionary<string, string> results = new();
            foreach (var prop in props)
            {
                string name = prop.Name;
                var att = prop.GetCustomAttribute<JsonPropertyAttribute>();
                if (att != null)
                {
                    name = att.PropertyName;
                }
                object rawValue = prop.GetValue(this, null);
                if (rawValue != null)
                {
                    string value = JsonConvert.SerializeObject(rawValue, Settings);
                    results.Add(name, value);
                }
            }
            return results;
        }
    }
}