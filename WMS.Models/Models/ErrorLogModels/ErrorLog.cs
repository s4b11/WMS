using WMS.Core.Models;
using System;

namespace WMS.Models.Models
{
    public class ErrorLog : EntityGuid
    {
        public int? UserID { get; set; }
        public string Class { get; set; }
        public string Method { get; set; }
        public string ErrorMessage { get; set; }
    }
}
