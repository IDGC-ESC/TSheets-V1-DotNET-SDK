namespace Intuit.TSheets.Model.Filters
{
    using System.Collections.Generic;
    using Intuit.TSheets.Client.Serialization.Converters;
    using Newtonsoft.Json;
    using NJsonSchema;
    using NJsonSchema.Annotations;

    /// <summary>
    /// Filter for narrowing down the results of a call to retrieve <see cref="TimeOffRequest"/> entities.
    /// </summary>
    [JsonObject]
    public class TimeOffRequestFilter : EntityFilter
    {
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
