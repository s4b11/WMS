using WMS.Dtos;

namespace WMS.Dtos
{
    public class UomDto : EntityGuidDto
    {
        public required string Name { get; set; }
        public required string Short { get; set; }
        public required string TransExistFlag { get; set; }
    }

    public class UomCreateDto : EntityGuidDto
    {
        public required string Name { get; set; }
        public required string Short { get; set; }
    }

    public class UomEditDto : EntityGuidDto
    {
        public required string Name { get; set; }
        public required string Short { get; set; }
    }

    public class UomCompactDto : EntityGuidDto
    {
        public required string Name { get; set; }
        public required string Short { get; set; }
    }
}