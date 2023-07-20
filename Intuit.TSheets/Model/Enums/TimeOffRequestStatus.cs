using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Intuit.TSheets.Model.Enums
{
    public enum TimeOffRequestStatus
    {
        [EnumMember(Value = "pending")]
        Pending,

        [EnumMember(Value = "approved")]
        Approved,

        [EnumMember(Value = "denied")]
        Denied,

        [EnumMember(Value = "canceled")]
        Canceled
    }
}
