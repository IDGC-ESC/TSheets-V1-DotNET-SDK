﻿// *******************************************************************************
// <copyright file="CreateContext.cs" company="Intuit">
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

namespace Intuit.TSheets.Client.RequestFlow.Contexts
{
    using System.Collections.Generic;
    using Intuit.TSheets.Client.Core;
    using Newtonsoft.Json;

    /// <summary>
    /// For a create (POST) operation, provides contextual information as the vehicle of state through the request pipeline.
    /// </summary>
    /// <typeparam name="T">The type of data entity.</typeparam>
    [JsonObject]
    public class CreateContext<T> : PipelineContext<T>, IWritableContext<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateContext{T}"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint with which to interact.</param>
        /// <param name="items">The set of entity items to be created.</param>
        public CreateContext(EndpointName endpoint, IEnumerable<T> items)
            : base(MethodType.Post, endpoint)
        {
            Items = items;
        }

        /// <summary>
        /// Gets or sets the set of entity items to be created.
        /// </summary>
        [JsonProperty]
        public IEnumerable<T> Items { get; set; }

        /// <summary>
        /// Gets or sets the set of entity items to be created, as a serialized JSON string.
        /// </summary>
        [JsonProperty]
        public string SerializedRequest { get; set; }
    }
}
