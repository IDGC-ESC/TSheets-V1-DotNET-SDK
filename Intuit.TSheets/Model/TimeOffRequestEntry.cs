using System;
using Intuit.TSheets.Model.Enums;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using Intuit.TSheets.Client.Serialization.Converters;
using Intuit.TSheets.Client.Serialization.Attributes;

namespace Intuit.TSheets.Model
{
    [DataEntity]
    [JsonObject]
    public class TimeOffRequestEntry : IIdentifiable
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("time_off_request_id")]
        public long TimeOffRequestId { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("status")]
        public TimeOffRequestStatus Status { get; set; }

        [JsonProperty("approver_user_id")]
        public long ApproverUserId { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("entry_method")]
        public TimeOffRequestEntryMethod EntryMethod { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }

        [JsonProperty("tz_string")]
        public string TimeZoneString { get; set; }

        [JsonProperty("jobcode_id")]
        public long JobcodeId { get; set; }

        [JsonProperty("user_id")]
        public long UserId { get; set; }

        [JsonProperty("approved_timesheet_id")]
        public long ApprovedTimesheetId { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("last_modified")]
        public DateTimeOffset LastModified { get; set; }

        [JsonConverter(typeof(DateFormatConverter))]
        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("start_time")]
        public DateTimeOffset StartTime { get; set; }

        [JsonConverter(typeof(DateTimeFormatConverter))]
        [JsonProperty("end_time")]
        public DateTimeOffset EndTime { get; set; }
    }
}
