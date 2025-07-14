using WMS.Dtos;

namespace WMS.Dtos
{
    public class CurrencyDto : EntityGuidDto
    {
        public required string Name { get; set; }
        public required string Code { get; set; }
        public required int CountryId { get; set; }
    }

    public class CurrencyCreateDto : EntityGuidDto
    {
        public required string Name { get; set; }
        public required string Code { get; set; }
        public required int CountryId { get; set; }
    }

    public class CurrencyEditDto : EntityGuidDto
    {
        public required string Name { get; set; }
        public required string Code { get; set; }
        public required int CountryId { get; set; }
    }

    public class CurrencyCompactDto : EntityGuidDto
    {
        public required string Name { get; set; }
        public required string Code { get; set; }
    }
}
