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
    /// Filter for narrowing down the results of a call to retrieve <see cref="TimeOffRequestEntry"/> entities.
    /// </summary>
    [JsonObject]
    public class TimeOffRequestEntryFilter : EntityFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimeOffRequestEntryFilter"/> class.
        /// </summary>
        public TimeOffRequestEntryFilter()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeOffRequestEntryFilter"/> class,
        /// with minimal required parameters to perform a retrieval operation.
        /// </summary>
        /// <param name="ids">
        /// The time off request entry ids you'd like to filter on.
        /// </param>
        public TimeOffRequestEntryFilter(IEnumerable<long> ids)
        {
            Ids = ids;
        }

        /// <summary>
        /// Gets or sets the time off request entry ids you'd like to filter on.
        /// </summary>
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("ids")]
        public IEnumerable<long> Ids { get; set; }

        /// <summary>
        /// Gets or sets the time off request ids you'd like to filter on.
        /// </summary>
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("time_off_request_ids")]
        public IEnumerable<long> TimeOffRequestIds { get; set; }

        /// <summary>
        /// Gets or sets the user ids you'd like to filter on. Only time off request entry entries linked to these users will be returned.
        /// </summary>
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("approver_user_ids")]
        public IEnumerable<long> ApproverUserIds { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("status")]
        public TimeOffRequestStatus Status { get; set; }

        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("start_time")]
        public DateTimeOffset StartTime { get; set; }

        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("end_time")]
        public DateTimeOffset EndTime { get; set; }

        /// <summary>
        /// Gets or sets the jobcode ids you'd like to filter on.
        /// </summary>
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("jobcode_ids")]
        public IEnumerable<long> JobcodeIds { get; set; }

        /// <summary>
        /// Gets or sets the user ids you'd like to filter on.
        /// </summary>
        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("user_ids")]
        public IEnumerable<long> UserIds { get; set; }
    }
}
