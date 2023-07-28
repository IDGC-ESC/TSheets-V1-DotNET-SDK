using System;
using System.Collections.Generic;
using Intuit.TSheets.Client.Serialization.Attributes;
using Intuit.TSheets.Client.Serialization.Converters;
using Intuit.TSheets.Model.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NJsonSchema;
using NJsonSchema.Annotations;

namespace Intuit.TSheets.Model
{
    [DataEntity]
    [JsonObject]
    public class TimeOffRequest : IIdentifiable
    {
        /// <summary>
        /// Gets the id of the time off request.
        /// </summary>
        [NoSerializeOnCreate]
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the id for the user that this timesheet belongs to.
        /// </summary>
        [JsonProperty("user_id")]
        public long UserId { get; set; }

        //[JsonConverter(typeof(EnumerableToCsvConverter))]
        //[JsonSchema(JsonObjectType.Array)]
        [JsonProperty("time_off_request_notes")]
        public IList<long> RequestNotes { get; set; }

        //[JsonConverter(typeof(EnumerableToCsvConverter))]
        //[JsonSchema(JsonObjectType.Array)]
        [JsonProperty("time_off_request_entries")]
        public IList<long> RequestEntries { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonSchema(JsonObjectType.String)]
        [JsonProperty("status")]
        public TimeOffRequestStatus Status { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("last_modified")]
        public DateTimeOffset LastModified { get; set; }
    }
}
