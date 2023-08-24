using System.Linq;
// *******************************************************************************
// <copyright file="ObjectExtensions.cs" company="Intuit">
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

namespace Intuit.TSheets.Client.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Intuit.TSheets.Api;
    using Newtonsoft.Json;

    /// <summary>
    /// For public use, extension methods for object.
    /// </summary>
    public static class ObjectExtensions
    {
        public static string ToJson(this object obj) => obj == null ? string.Empty : JsonConvert.SerializeObject(obj, DataService.Settings);

        public static bool HasCustomAttribute<T>(this T _, Type attributeType) => typeof(T).HasCustomAttribute(attributeType);

        public static bool HasCustomAttribute(this Type type, Type attributeType) => type.GetCustomAttribute(attributeType) != null;

        public static bool IsAssignableTo(this Type objectType, Type baseType) => baseType.IsAssignableFrom(objectType);

        public static bool IsAssignableToAny(this Type objectType, params Type[] baseType) => IsAssignableToAny(objectType, (IEnumerable<Type>)baseType);

        public static bool IsAssignableToAny(this Type objectType, IEnumerable<Type> baseTypes) => baseTypes.Any(objectType.IsAssignableTo);

        /// <summary>
        /// Throws an instance of <see cref="ArgumentNullException"/> if the value is null.
        /// </summary>
        /// <param name="value">The value to test for null.</param>
        public static void ThrowIfNull(this object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
        }
    }
}