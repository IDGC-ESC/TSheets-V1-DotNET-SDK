namespace Intuit.TSheets.Model.Filters
{
    using System;
    using System.Collections.Generic;
    using Intuit.TSheets.Client.Serialization.Converters;
    using Intuit.TSheets.Model.Enums;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using NJsonSchema;
    using NJsonSchema.Annotations;

    /// <summary>
    /// Filter for narrowing down the results of a call to retrieve <see cref="TimeOffRequest"/> entities.
    /// </summary>
    [JsonObject]
    public class TimeOffRequestFilter : EntityFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimeOffRequestFilter"/> class.
        /// </summary>
        public TimeOffRequestFilter()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeOffRequestFilter"/> class,
        /// with minimal required parameters to perform a retrieval operation.
        /// </summary>
        /// <param name="ids">
        /// The time off request ids you'd like to filter on.
        /// </param>
        public TimeOffRequestFilter(IEnumerable<long> ids)
        {
            Ids = ids;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeOffRequestFilter"/> class,
        /// with minimal required parameters to perform a retrieval operation.
        /// </summary>
        /// <param name="ids">
        /// The time off request ids you'd like to filter on.
        /// </param>
        /// <param name="userIds">
        /// The time off user ids you'd like to filter on.
        /// </param>
        public TimeOffRequestFilter(IEnumerable<long> ids, IEnumerable<long> userIds)
        {
            Ids = ids;
            UserIds = userIds;
        }

        /// <summary>
        /// Gets or sets the time off request ids you'd like to filter on.
        /// </summary>
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("ids")]
        public IEnumerable<long> Ids { get; set; }

        /// <summary>
        /// Gets or sets the user ids you'd like to filter on. Only time off requests linked to these users will be returned.
        /// </summary>
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("user_ids")]
        public IEnumerable<long> UserIds { get; set; }
    }
}
