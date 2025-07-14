using WMS.Core.Models;

namespace WMS.Models.Models.UomModel
{
    public class Uom : EntityGuid
    {
        public required string Name { get; set; }
        public required string Short { get; set; }
        public required string TransExistFlag { get; set; }
    }
}