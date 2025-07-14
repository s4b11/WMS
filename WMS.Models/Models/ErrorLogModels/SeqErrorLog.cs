namespace WMS.Models
{
    public class SeqErrorLog : EntityGuid
    {
        public required int Seed { get; set; } = 1;
        public required int Incr { get; set; } = 1;
        public long? Curval { get; set; }
    }
}
