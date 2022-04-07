using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveApp_API.Models
{
    public class LeaveViewModel
    {
        public User UserDetail { get; set; }
        public Leave LeaveDetail { get; set; }
    }
}
