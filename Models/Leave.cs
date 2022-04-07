using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LeaveApp_API.Models
{
    public partial class Leave
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? LeaveDays { get; set; }
        public int? LeaveLeft { get; set; }
        public string TypeOfLeave { get; set; }
        public string Reason { get; set; }
    }
}
