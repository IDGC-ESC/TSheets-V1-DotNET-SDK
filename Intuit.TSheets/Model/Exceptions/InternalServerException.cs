﻿// *******************************************************************************
// <copyright file="InternalServerException.cs" company="Intuit">
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
    /// Server exception thrown when the server encounters an unexpected condition that prevents it from fulfilling the request.
    /// </summary>
    [Serializable]
    public sealed class InternalServerException : ApiServerException
    {
        /// <summary>
        /// The HTTP code for an public server exception.
        /// </summary>
        public const int Code = 500;

        /// <summary>
        /// Initializes a new instance of the <see cref="InternalServerException"/> class.
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
        public InternalServerException(string errorText, string message, Exception innerException)
            : base(Code, errorText, message, innerException)
        {
        }

        private InternalServerException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
