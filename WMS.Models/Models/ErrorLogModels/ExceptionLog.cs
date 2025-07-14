using WMS.Core.Models;
using System;

namespace WMS.Models.Models
{
    public class ExceptionLog : EntityGuid
    {
        public string ErrorMessage { get; set; }
        public int? UserId { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public string IpAddress { get; set; }
    }
}
