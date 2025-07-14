namespace WMS.Models
{
    public class Zone : EntityGuid
    {
        public required string Name { get; set; }
        public required string Short { get; set; }
        public required string TransExistFlag { get; set; }

    }
}