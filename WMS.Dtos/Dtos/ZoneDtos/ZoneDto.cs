using WMS.Dtos;

namespace WMS.Dtos
{
    public class ZoneDto : EntityGuidDto
    {
        public required string Name { get; set; }
        public required string Short { get; set; }
        public required string TransExistFlag { get; set; }
    }

    public class ZoneCreateDto : EntityGuidDto
    {
        public required string Name { get; set; }
        public required string Short { get; set; }
    }

    public class ZoneEditDto : EntityGuidDto
    {
        public required string Name { get; set; }
        public required string Short { get; set; }
    }

    public class ZoneCompactDto : EntityGuidDto
    {
        public required string Name { get; set; }
        public required string Short { get; set; }
    }
}
