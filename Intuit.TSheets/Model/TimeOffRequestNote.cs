using System;
using System.Collections.Generic;
using Intuit.TSheets.Client.Serialization.Attributes;
using Intuit.TSheets.Client.Serialization.Converters;
using Newtonsoft.Json;

namespace Intuit.TSheets.Model
{
    [JsonObject]
    public class TimeOffRequestNote : IIdentifiable
    {
        /// <summary>
        /// Gets the id of the time off request.
        /// </summary>
        [NoSerializeOnCreate]
        [JsonProperty("id")]
        public long Id { get; internal set; }

        [JsonProperty("time_off_request_id")]
        public IReadOnlyList<long> RequestID { get; internal set; }

        /// <summary>
        /// Gets or sets the id for the user that this timesheet belongs to.
        /// </summary>
        [JsonProperty("user_id")]
        public long UserID { get; internal set; }

        [JsonProperty("active")]
        public bool Active { get; internal set; }

        [JsonProperty("note")]
        public string Note { get; set; } = null!;

        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("created")]
        public DateTimeOffset Created { get; internal set; }

        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("last_modified")]
        public DateTimeOffset LastModified { get; internal set; }
    }
}
