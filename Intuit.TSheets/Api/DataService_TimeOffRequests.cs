// *******************************************************************************
// <copyright file="DataService_TimeOffRequest.cs" company="Intuit">
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

namespace Intuit.TSheets.Api
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Intuit.TSheets.Client.Core;
    using Intuit.TSheets.Client.RequestFlow.Contexts;
    using Intuit.TSheets.Client.Utilities;
    using Intuit.TSheets.Model;
    using Intuit.TSheets.Model.Filters;

    /// <summary>
    /// Top-level service class for interacting with all TSheets API operations.
    /// </summary>
    /// <remarks>
    /// This file contains operations specific to the TimeOffRequests endpoint.
    /// </remarks>
    public partial class DataService
    {
        #region Create methods

        /// <summary>
        /// Create TimeOffRequests.
        /// </summary>
        /// <remarks>
        /// Add a single time off request to your company.
        /// </remarks>
        /// <param name="timeOffRequest">
        /// The <see cref="TimeOffRequest"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="TimeOffRequest"/> object that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (TimeOffRequest, ResultsMeta) CreateTimeOffRequest(TimeOffRequest timeOffRequest)
        {
            (IList<TimeOffRequest> timeOffRequests, ResultsMeta resultsMeta) = CreateTimeOffRequests(new[] { timeOffRequest });

            return (timeOffRequests.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Create TimeOffRequests.
        /// </summary>
        /// <remarks>
        /// Add one or more timeOffRequests to your company.
        /// </remarks>
        /// <param name="timeOffRequests">
        /// The set of <see cref="TimeOffRequest"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="TimeOffRequest"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<TimeOffRequest>, ResultsMeta) CreateTimeOffRequests(IEnumerable<TimeOffRequest> timeOffRequests)
        {
            return AsyncUtil.RunSync(() => CreateTimeOffRequestsAsync(timeOffRequests));
        }

        /// <summary>
        /// Asynchronously Create TimeOffRequests.
        /// </summary>
        /// <remarks>
        /// Add a single time off request to your company.
        /// </remarks>
        /// <param name="timeOffRequest">
        /// The <see cref="TimeOffRequest"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="TimeOffRequest"/> object that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(TimeOffRequest, ResultsMeta)> CreateTimeOffRequestAsync(
            TimeOffRequest timeOffRequest)
        {
            (IList<TimeOffRequest> timeOffRequests, ResultsMeta resultsMeta) = await CreateTimeOffRequestsAsync(new[] { timeOffRequest }, default).ConfigureAwait(false);

            return (timeOffRequests.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Create TimeOffRequests, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Add a single time off request to your company.
        /// </remarks>
        /// <param name="timeOffRequest">
        /// The <see cref="TimeOffRequest"/> object to be created.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The <see cref="TimeOffRequest"/> object that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(TimeOffRequest, ResultsMeta)> CreateTimeOffRequestAsync(
            TimeOffRequest timeOffRequest,
            CancellationToken cancellationToken)
        {
            (IList<TimeOffRequest> timeOffRequests, ResultsMeta resultsMeta) = await CreateTimeOffRequestsAsync(new[] { timeOffRequest }, cancellationToken).ConfigureAwait(false);

            return (timeOffRequests.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Create TimeOffRequests.
        /// </summary>
        /// <remarks>
        /// Add one or more timeOffRequests to your company.
        /// </remarks>
        /// <param name="timeOffRequests">
        /// The set of <see cref="TimeOffRequest"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="TimeOffRequest"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<TimeOffRequest>, ResultsMeta)> CreateTimeOffRequestsAsync(
            IEnumerable<TimeOffRequest> timeOffRequests)
        {
            return await CreateTimeOffRequestsAsync(timeOffRequests, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Create TimeOffRequests, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Add one or more timeOffRequests to your company.
        /// </remarks>
        /// <param name="timeOffRequests">
        /// The set of <see cref="TimeOffRequest"/> objects to be created.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The set of the <see cref="TimeOffRequest"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<TimeOffRequest>, ResultsMeta)> CreateTimeOffRequestsAsync(
            IEnumerable<TimeOffRequest> timeOffRequests,
            CancellationToken cancellationToken)
        {
            var context = new CreateContext<TimeOffRequest>(EndpointName.TimeOffRequests, timeOffRequests);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion

        #region Get Methods

        /// <summary>
        /// Retrieve TimeOffRequests.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all timeOffRequests associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="TimeOffRequestFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="TimeOffRequest"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<TimeOffRequest>, ResultsMeta) GetTimeOffRequests(
            TimeOffRequestFilter filter)
        {
            return AsyncUtil.RunSync(() => GetTimeOffRequestsAsync(filter));
        }

        /// <summary>
        /// Retrieve TimeOffRequests.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all timeOffRequests associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="TimeOffRequestFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="TimeOffRequest"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<TimeOffRequest>, ResultsMeta) GetTimeOffRequests(
            TimeOffRequestFilter filter,
            RequestOptions options)
        {
            return AsyncUtil.RunSync(() => GetTimeOffRequestsAsync(filter, options));
        }

        /// <summary>
        /// Asynchronously Retrieve TimeOffRequests.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all timeOffRequests associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="TimeOffRequestFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="TimeOffRequest"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<TimeOffRequest>, ResultsMeta)> GetTimeOffRequestsAsync(
            TimeOffRequestFilter filter)
        {
            return await GetTimeOffRequestsAsync(filter, null, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve TimeOffRequests, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all timeOffRequests associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="TimeOffRequestFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="TimeOffRequest"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<TimeOffRequest>, ResultsMeta)> GetTimeOffRequestsAsync(
            TimeOffRequestFilter filter,
            CancellationToken cancellationToken)
        {
            return await GetTimeOffRequestsAsync(filter, null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve TimeOffRequests.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all timeOffRequests associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="TimeOffRequestFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="TimeOffRequest"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<TimeOffRequest>, ResultsMeta)> GetTimeOffRequestsAsync(
            TimeOffRequestFilter filter,
            RequestOptions options)
        {
            return await GetTimeOffRequestsAsync(filter, options, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve TimeOffRequests, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all timeOffRequests associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="TimeOffRequestFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="TimeOffRequest"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<TimeOffRequest>, ResultsMeta)> GetTimeOffRequestsAsync(
            TimeOffRequestFilter filter,
            RequestOptions options,
            CancellationToken cancellationToken)
        {
            var context = new GetContext<TimeOffRequest>(EndpointName.TimeOffRequests, filter, options);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion

        #region Update methods

        /// <summary>
        /// Update TimeOffRequests.
        /// </summary>
        /// <remarks>
        /// Edit a single time off request in your company.
        /// </remarks>
        /// <param name="timeOffRequest">
        /// The <see cref="TimeOffRequest"/> object to be updated.
        /// </param>
        /// <returns>
        /// The <see cref="TimeOffRequest"/> object that was updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (TimeOffRequest, ResultsMeta) UpdateTimeOffRequest(
            TimeOffRequest timeOffRequest)
        {
            (IList<TimeOffRequest> timeOffRequests, ResultsMeta resultsMeta) =
                UpdateTimeOffRequests(new[] { timeOffRequest });

            return (timeOffRequests.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Update TimeOffRequests.
        /// </summary>
        /// <remarks>
        /// Edit one or more timeOffRequests in your company.
        /// </remarks>
        /// <param name="timeOffRequests">
        /// The set of <see cref="TimeOffRequest"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The set of the <see cref="TimeOffRequest"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<TimeOffRequest>, ResultsMeta) UpdateTimeOffRequests(IEnumerable<TimeOffRequest> timeOffRequests)
        {
            return AsyncUtil.RunSync(() => UpdateTimeOffRequestsAsync(timeOffRequests));
        }

        /// <summary>
        /// Asynchronously Update TimeOffRequests.
        /// </summary>
        /// <remarks>
        /// Edit a single time off request in your company.
        /// </remarks>
        /// <param name="timeOffRequest">
        /// The <see cref="TimeOffRequest"/> object to be updated.
        /// </param>
        /// <returns>
        /// The <see cref="TimeOffRequest"/> object that was updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(TimeOffRequest, ResultsMeta)> UpdateTimeOffRequestAsync(
            TimeOffRequest timeOffRequest)
        {
            (IList<TimeOffRequest> timeOffRequests, ResultsMeta resultsMeta) =
                await UpdateTimeOffRequestsAsync(new[] { timeOffRequest }, default).ConfigureAwait(false);

            return (timeOffRequests.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Update TimeOffRequests, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Edit a single time off request in your company.
        /// </remarks>
        /// <param name="timeOffRequest">
        /// The <see cref="TimeOffRequest"/> object to be updated.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The <see cref="TimeOffRequest"/> object that was updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(TimeOffRequest, ResultsMeta)> UpdateTimeOffRequestAsync(
            TimeOffRequest timeOffRequest,
            CancellationToken cancellationToken)
        {
            (IList<TimeOffRequest> timeOffRequests, ResultsMeta resultsMeta) =
                await UpdateTimeOffRequestsAsync(new[] { timeOffRequest }, cancellationToken).ConfigureAwait(false);

            return (timeOffRequests.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Update TimeOffRequests.
        /// </summary>
        /// <remarks>
        /// Edit one or more timeOffRequests in your company.
        /// </remarks>
        /// <param name="timeOffRequests">
        /// The set of <see cref="TimeOffRequest"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The set of the <see cref="TimeOffRequest"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<TimeOffRequest>, ResultsMeta)> UpdateTimeOffRequestsAsync(
            IEnumerable<TimeOffRequest> timeOffRequests)
        {
            return await UpdateTimeOffRequestsAsync(timeOffRequests, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Update TimeOffRequests, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Edit one or more timeOffRequests in your company.
        /// </remarks>
        /// <param name="timeOffRequests">
        /// The set of <see cref="TimeOffRequest"/> objects to be updated.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The set of the <see cref="TimeOffRequest"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<TimeOffRequest>, ResultsMeta)> UpdateTimeOffRequestsAsync(
            IEnumerable<TimeOffRequest> timeOffRequests,
            CancellationToken cancellationToken)
        {
            var context = new UpdateContext<TimeOffRequest>(EndpointName.TimeOffRequests, timeOffRequests);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion
    }
}
