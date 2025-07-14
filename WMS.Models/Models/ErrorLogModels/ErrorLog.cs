namespace WMS.Models
{
    public class ErrorLog : EntityGuid
    {
        public int? UserID { get; set; }
        public required string Class { get; set; }
        public required string Method { get; set; }
        public required string ErrorMessage { get; set; }
    }
}
