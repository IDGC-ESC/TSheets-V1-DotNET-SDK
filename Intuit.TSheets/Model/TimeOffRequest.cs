using System;
using System.Collections.Generic;
using System.Linq;
using Intuit.TSheets.Client.Serialization.Attributes;
using Intuit.TSheets.Client.Serialization.Converters;
using Intuit.TSheets.Model.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NJsonSchema.Annotations;
using NJsonSchema;

namespace Intuit.TSheets.Model
{
    [DataEntity]
    [JsonObject]
    public class TimeOffRequest : IIdentifiable
    {
        public TimeOffRequest()
        {
        }

        public TimeOffRequest(IEnumerable<long> requestEntryIds)
        {
            RequestEntries = requestEntryIds?.ToList();
        }

        /// <summary>
        /// Gets the id of the time off request.
        /// </summary>
        [NoSerializeOnCreate]
        [JsonProperty("id")]
        public long Id { get; internal set; }

        /// <summary>
        /// Gets or sets the id for the user that this timesheet belongs to.
        /// </summary>
        [JsonProperty("user_id")]
        public long UserID { get; set; }

        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("time_off_request_notes")]
        public IEnumerable<long> RequestNotes { get; internal set; }

        [JsonConverter(typeof(EnumerableToCsvConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("time_off_request_entries")]
        public IEnumerable<long> RequestEntries { get; internal set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("status")]
        public TimeOffRequestStatus Status { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("created")]
        public DateTimeOffset Created { get; internal set; }

        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("last_modified")]
        public DateTimeOffset LastModified { get; internal set; }
    }
}
