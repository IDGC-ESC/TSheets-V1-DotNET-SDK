using System;
using System.Collections.Generic;
using System.Linq;
using Intuit.TSheets.Client.Serialization.Attributes;
using Intuit.TSheets.Client.Serialization.Converters;
using Newtonsoft.Json;

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

        [JsonProperty("time_off_request_notes")]
        public IReadOnlyList<long> RequestNotes { get; set; } = Array.Empty<long>();

        [JsonProperty("time_off_request_entries")]
        public IReadOnlyList<long> RequestEntries { get; set; } = Array.Empty<long>();

        [JsonProperty("status")]
        public string Status { get; set; } = null!;

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
