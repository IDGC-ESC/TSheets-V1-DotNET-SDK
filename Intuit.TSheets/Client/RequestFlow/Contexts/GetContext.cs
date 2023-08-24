﻿// *******************************************************************************
// <copyright file="GetContext.cs" company="Intuit">
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
    using Intuit.TSheets.Api;
    using Intuit.TSheets.Client.Core;
    using Intuit.TSheets.Model.Filters;
    using Newtonsoft.Json;

    /// <summary>
    /// For a retrieval (GET) operation, provides contextual information as the vehicle of state through the request pipeline.
    /// </summary>
    /// <typeparam name="T">The type of data entity.</typeparam>
    [JsonObject]
    public class GetContext<T> : PipelineContext<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetContext{T}"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint with which to interact.</param>
        /// <param name="filter">The filter for narrowing down the result set.</param>
        /// <param name="options">The options for controlling the behavior of the operation.</param>
        public GetContext(EndpointName endpoint, EntityFilter filter, RequestOptions options)
            : base(MethodType.Get, endpoint)
        {
            Filter = filter ?? new NullFilter();
            Options = options ?? new RequestOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetContext{T}"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint with which to interact.</param>
        /// <param name="filter">The filter for narrowing down the result set.</param>
        public GetContext(EndpointName endpoint, EntityFilter filter)
            : this(endpoint, filter, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetContext{T}"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint with which to interact.</param>
        /// <param name="options">The options for controlling the behavior of the operation.</param> 
        public GetContext(EndpointName endpoint, RequestOptions options)
            : this(endpoint, null, options)
        {
        }

        /// <summary>
        /// Gets or sets the instance of <see cref="IEntityFilter"/>, for narrowing down the result set.
        /// </summary>
        [JsonProperty]
        public IEntityFilter Filter { get; set; }

        /// <summary>
        /// Gets the instance of <see cref="RequestOptions"/>, for controlling the behavior of the operation.
        /// </summary>
        [JsonProperty]
        public RequestOptions Options { get; private set; }
    }
}
