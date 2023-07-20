using System.Runtime.Serialization;

namespace Intuit.TSheets.Model.Enums
{
    public enum TimeOffRequestEntryMethod
    {
        /// <summary>
        /// Manual time off request entries have a date and a duration (in seconds). 
        /// </summary>
        [EnumMember(Value = "manual")]
        Manual,

        /// <summary>
        /// Regular time off request entries have a start/end time (duration is calculated by TSheets) for determining availability in Schedule.
        /// </summary>
        [EnumMember(Value = "regular")]
        Regular
    }
}
