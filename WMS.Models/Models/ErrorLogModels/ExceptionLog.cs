namespace WMS.Models
{
    public class ExceptionLog : EntityGuid
    {
        public required string ErrorMessage { get; set; }
        public int? UserId { get; set; }
        public required string ActionName { get; set; }
        public required string ControllerName { get; set; }
        public required string IpAddress { get; set; }
    }
}
