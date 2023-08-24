﻿// *******************************************************************************
// <copyright file="ReportRequest.cs" company="Intuit">
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

namespace Intuit.TSheets.Client.RequestFlow
{
    using System.Collections.Generic;
    using Intuit.TSheets.Model.Filters;
    using Newtonsoft.Json;

    /// <summary>
    /// Class that is serialized to JSON for requesting the retrieval of a report.
    /// </summary>
    [JsonObject]
    public class ReportRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportRequest"/> class.
        /// </summary>
        /// <param name="filter">
        /// An instance of an <see cref="IEntityFilter"/>, for tuning the report results.
        /// </param>
        public ReportRequest(IEntityFilter filter)
        {
            Data = filter?.GetFilters();
        }

        /// <summary>
        /// Gets or sets the key/value pairs which represent the report request.
        /// </summary>
        [JsonProperty("data")]
        public Dictionary<string, string> Data { get; set; }
    }
}