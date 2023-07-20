// *******************************************************************************
// <copyright file="DataService_TimeOffRequestEntry.cs" company="Intuit">
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
    /// This file contains operations specific to the TimeOffRequestEntries endpoint.
    /// </remarks>
    public partial class DataService
    {
        #region Create methods

        /// <summary>
        /// Create TimeOffRequestEntries.
        /// </summary>
        /// <remarks>
        /// Add a single time off request entry to your company.
        /// </remarks>
        /// <param name="timeOffRequestEntry">
        /// The <see cref="TimeOffRequestEntry"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="TimeOffRequestEntry"/> object that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (TimeOffRequestEntry, ResultsMeta) CreateTimeOffRequestEntry(TimeOffRequestEntry timeOffRequestEntry)
        {
            (IList<TimeOffRequestEntry> timeOffRequestEntries, ResultsMeta resultsMeta) = CreateTimeOffRequestEntries(new[] { timeOffRequestEntry });

            return (timeOffRequestEntries.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Create TimeOffRequestEntries.
        /// </summary>
        /// <remarks>
        /// Add one or more timeOffRequestEntries to your company.
        /// </remarks>
        /// <param name="timeOffRequestEntries">
        /// The set of <see cref="TimeOffRequestEntry"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="TimeOffRequestEntry"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<TimeOffRequestEntry>, ResultsMeta) CreateTimeOffRequestEntries(IEnumerable<TimeOffRequestEntry> timeOffRequestEntries)
        {
            return AsyncUtil.RunSync(() => CreateTimeOffRequestEntriesAsync(timeOffRequestEntries));
        }

        /// <summary>
        /// Asynchronously Create TimeOffRequestEntries.
        /// </summary>
        /// <remarks>
        /// Add a single time off request entry to your company.
        /// </remarks>
        /// <param name="timeOffRequestEntry">
        /// The <see cref="TimeOffRequestEntry"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="TimeOffRequestEntry"/> object that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(TimeOffRequestEntry, ResultsMeta)> CreateTimeOffRequestEntryAsync(
            TimeOffRequestEntry timeOffRequestEntry)
        {
            (IList<TimeOffRequestEntry> timeOffRequestEntries, ResultsMeta resultsMeta) = await CreateTimeOffRequestEntriesAsync(new[] { timeOffRequestEntry }, default).ConfigureAwait(false);

            return (timeOffRequestEntries.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Create TimeOffRequestEntries, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Add a single time off request entry to your company.
        /// </remarks>
        /// <param name="timeOffRequestEntry">
        /// The <see cref="TimeOffRequestEntry"/> object to be created.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The <see cref="TimeOffRequestEntry"/> object that was created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(TimeOffRequestEntry, ResultsMeta)> CreateTimeOffRequestEntryAsync(
            TimeOffRequestEntry timeOffRequestEntry,
            CancellationToken cancellationToken)
        {
            (IList<TimeOffRequestEntry> timeOffRequestEntries, ResultsMeta resultsMeta) = await CreateTimeOffRequestEntriesAsync(new[] { timeOffRequestEntry }, cancellationToken).ConfigureAwait(false);

            return (timeOffRequestEntries.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Create TimeOffRequestEntries.
        /// </summary>
        /// <remarks>
        /// Add one or more timeOffRequestEntries to your company.
        /// </remarks>
        /// <param name="timeOffRequestEntries">
        /// The set of <see cref="TimeOffRequestEntry"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="TimeOffRequestEntry"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<TimeOffRequestEntry>, ResultsMeta)> CreateTimeOffRequestEntriesAsync(
            IEnumerable<TimeOffRequestEntry> timeOffRequestEntries)
        {
            return await CreateTimeOffRequestEntriesAsync(timeOffRequestEntries, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Create TimeOffRequestEntries, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Add one or more timeOffRequestEntries to your company.
        /// </remarks>
        /// <param name="timeOffRequestEntries">
        /// The set of <see cref="TimeOffRequestEntry"/> objects to be created.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The set of the <see cref="TimeOffRequestEntry"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<TimeOffRequestEntry>, ResultsMeta)> CreateTimeOffRequestEntriesAsync(
            IEnumerable<TimeOffRequestEntry> timeOffRequestEntries,
            CancellationToken cancellationToken)
        {
            var context = new CreateContext<TimeOffRequestEntry>(EndpointName.TimeOffRequestEntries, timeOffRequestEntries);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion

        #region Get Methods

        /// <summary>
        /// Retrieve TimeOffRequestEntries.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all timeOffRequestEntries associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="TimeOffRequestEntryFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="TimeOffRequestEntry"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<TimeOffRequestEntry>, ResultsMeta) GetTimeOffRequestEntries(
            TimeOffRequestEntryFilter filter)
        {
            return AsyncUtil.RunSync(() => GetTimeOffRequestEntriesAsync(filter));
        }

        /// <summary>
        /// Retrieve TimeOffRequestEntries.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all timeOffRequestEntries associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="TimeOffRequestEntryFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="TimeOffRequestEntry"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public (IList<TimeOffRequestEntry>, ResultsMeta) GetTimeOffRequestEntries(
            TimeOffRequestEntryFilter filter,
            RequestOptions options)
        {
            return AsyncUtil.RunSync(() => GetTimeOffRequestEntriesAsync(filter, options));
        }

        /// <summary>
        /// Asynchronously Retrieve TimeOffRequestEntries.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all timeOffRequestEntries associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="TimeOffRequestEntryFilter"/> class, for narrowing down the results.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="TimeOffRequestEntry"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<TimeOffRequestEntry>, ResultsMeta)> GetTimeOffRequestEntriesAsync(
            TimeOffRequestEntryFilter filter)
        {
            return await GetTimeOffRequestEntriesAsync(filter, null, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve TimeOffRequestEntries, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all timeOffRequestEntries associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="TimeOffRequestEntryFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="TimeOffRequestEntry"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<TimeOffRequestEntry>, ResultsMeta)> GetTimeOffRequestEntriesAsync(
            TimeOffRequestEntryFilter filter,
            CancellationToken cancellationToken)
        {
            return await GetTimeOffRequestEntriesAsync(filter, null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve TimeOffRequestEntries.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all timeOffRequestEntries associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="TimeOffRequestEntryFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="TimeOffRequestEntry"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<TimeOffRequestEntry>, ResultsMeta)> GetTimeOffRequestEntriesAsync(
            TimeOffRequestEntryFilter filter,
            RequestOptions options)
        {
            return await GetTimeOffRequestEntriesAsync(filter, options, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Retrieve TimeOffRequestEntries, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all timeOffRequestEntries associated with your company,
        /// with optional filters to narrow down the results.
        /// </remarks>
        /// <param name="filter">
        /// An instance of the <see cref="TimeOffRequestEntryFilter"/> class, for narrowing down the results.
        /// </param>
        /// <param name="options">
        /// An instance of the <see cref="RequestOptions"/> class, for customizing method processing.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// An enumerable set of <see cref="TimeOffRequestEntry"/> objects, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns> 
        public async Task<(IList<TimeOffRequestEntry>, ResultsMeta)> GetTimeOffRequestEntriesAsync(
            TimeOffRequestEntryFilter filter,
            RequestOptions options,
            CancellationToken cancellationToken)
        {
            var context = new GetContext<TimeOffRequestEntry>(EndpointName.TimeOffRequestEntries, filter, options);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion

        #region Update methods

        /// <summary>
        /// Update TimeOffRequestEntries.
        /// </summary>
        /// <remarks>
        /// Edit a single time off request entry in your company.
        /// </remarks>
        /// <param name="timeOffRequestEntry">
        /// The <see cref="TimeOffRequestEntry"/> object to be updated.
        /// </param>
        /// <returns>
        /// The <see cref="TimeOffRequestEntry"/> object that was updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (TimeOffRequestEntry, ResultsMeta) UpdateTimeOffRequestEntry(
            TimeOffRequestEntry timeOffRequestEntry)
        {
            (IList<TimeOffRequestEntry> timeOffRequestEntries, ResultsMeta resultsMeta) =
                UpdateTimeOffRequestEntries(new[] { timeOffRequestEntry });

            return (timeOffRequestEntries.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Update TimeOffRequestEntries.
        /// </summary>
        /// <remarks>
        /// Edit one or more timeOffRequestEntries in your company.
        /// </remarks>
        /// <param name="timeOffRequestEntries">
        /// The set of <see cref="TimeOffRequestEntry"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The set of the <see cref="TimeOffRequestEntry"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<TimeOffRequestEntry>, ResultsMeta) UpdateTimeOffRequestEntries(IEnumerable<TimeOffRequestEntry> timeOffRequestEntries)
        {
            return AsyncUtil.RunSync(() => UpdateTimeOffRequestEntriesAsync(timeOffRequestEntries));
        }

        /// <summary>
        /// Asynchronously Update TimeOffRequestEntries.
        /// </summary>
        /// <remarks>
        /// Edit a single time off request entry in your company.
        /// </remarks>
        /// <param name="timeOffRequestEntry">
        /// The <see cref="TimeOffRequestEntry"/> object to be updated.
        /// </param>
        /// <returns>
        /// The <see cref="TimeOffRequestEntry"/> object that was updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(TimeOffRequestEntry, ResultsMeta)> UpdateTimeOffRequestEntryAsync(
            TimeOffRequestEntry timeOffRequestEntry)
        {
            (IList<TimeOffRequestEntry> timeOffRequestEntries, ResultsMeta resultsMeta) =
                await UpdateTimeOffRequestEntriesAsync(new[] { timeOffRequestEntry }, default).ConfigureAwait(false);

            return (timeOffRequestEntries.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Update TimeOffRequestEntries, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Edit a single time off request entry in your company.
        /// </remarks>
        /// <param name="timeOffRequestEntry">
        /// The <see cref="TimeOffRequestEntry"/> object to be updated.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The <see cref="TimeOffRequestEntry"/> object that was updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(TimeOffRequestEntry, ResultsMeta)> UpdateTimeOffRequestEntryAsync(
            TimeOffRequestEntry timeOffRequestEntry,
            CancellationToken cancellationToken)
        {
            (IList<TimeOffRequestEntry> timeOffRequestEntries, ResultsMeta resultsMeta) =
                await UpdateTimeOffRequestEntriesAsync(new[] { timeOffRequestEntry }, cancellationToken).ConfigureAwait(false);

            return (timeOffRequestEntries.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Update TimeOffRequestEntries.
        /// </summary>
        /// <remarks>
        /// Edit one or more timeOffRequestEntries in your company.
        /// </remarks>
        /// <param name="timeOffRequestEntries">
        /// The set of <see cref="TimeOffRequestEntry"/> objects to be updated.
        /// </param>
        /// <returns>
        /// The set of the <see cref="TimeOffRequestEntry"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<TimeOffRequestEntry>, ResultsMeta)> UpdateTimeOffRequestEntriesAsync(
            IEnumerable<TimeOffRequestEntry> timeOffRequestEntries)
        {
            return await UpdateTimeOffRequestEntriesAsync(timeOffRequestEntries, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Update TimeOffRequestEntries, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Edit one or more timeOffRequestEntries in your company.
        /// </remarks>
        /// <param name="timeOffRequestEntries">
        /// The set of <see cref="TimeOffRequestEntry"/> objects to be updated.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The set of the <see cref="TimeOffRequestEntry"/> objects that were updated, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<TimeOffRequestEntry>, ResultsMeta)> UpdateTimeOffRequestEntriesAsync(
            IEnumerable<TimeOffRequestEntry> timeOffRequestEntries,
            CancellationToken cancellationToken)
        {
            var context = new UpdateContext<TimeOffRequestEntry>(EndpointName.TimeOffRequestEntries, timeOffRequestEntries);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion
    }
}
