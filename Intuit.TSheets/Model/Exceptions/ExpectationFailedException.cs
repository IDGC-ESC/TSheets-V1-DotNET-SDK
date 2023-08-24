﻿// *******************************************************************************
// <copyright file="ExpectationFailedException.cs" company="Intuit">
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

namespace Intuit.TSheets.Model.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Client side exception thrown when the request is missing required parameters or is somehow otherwise malformed.
    /// </summary>
    [Serializable]
    public sealed class ExpectationFailedException : ApiClientException
    {
        /// <summary>
        /// The HTTP code for expectation failed.
        /// </summary>
        public const int HttpCode = 417;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpectationFailedException"/> class.
        /// </summary>
        /// <param name="errorText">
        /// Short error text returned from the API call.
        /// </param> 
        /// <param name="message">
        /// The error message that explains the reason for the exception.
        /// </param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception.
        /// </param>
        public ExpectationFailedException(string errorText, string message, Exception innerException)
            : base(HttpCode, errorText, message, innerException)
        {
        }

        private ExpectationFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
