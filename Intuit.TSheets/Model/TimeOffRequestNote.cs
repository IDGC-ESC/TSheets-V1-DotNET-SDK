using System;
using Intuit.TSheets.Client.Serialization.Attributes;
using Intuit.TSheets.Client.Serialization.Converters;
using Newtonsoft.Json;

namespace Intuit.TSheets.Model
{
    [DataEntity]
    [JsonObject]
    public class TimeOffRequestNote : IIdentifiable
    {
        /// <summary>
        /// Gets the id of the time off request.
        /// </summary>
        [NoSerializeOnCreate]
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("time_off_request_id")]
        public long RequestID { get; set; }

        /// <summary>
        /// Gets or sets the id for the user that this timesheet belongs to.
        /// </summary>
        [JsonProperty("user_id")]
        public long UserID { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("last_modified")]
        public DateTimeOffset LastModified { get; set; }
    }
}
