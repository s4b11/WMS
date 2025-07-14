using WMS.Core.Models;

namespace WMS.Models.Models
{
    public class SeqErrorLog : EntityGuid
    {
        public int Seed { get; set; } = 1;
        public int Incr { get; set; } = 1;
        public long? Curval { get; set; }
    }
}
