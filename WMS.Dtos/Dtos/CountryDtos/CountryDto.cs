namespace WMS.Dtos
{
    public class CountryDto : EntityGuidDto
    {
        public required string CountryName { get; set; }
        public required string CountryCode { get; set; }
    }

    public class CountryCreateDto : EntityGuidDto
    {
        public required string CountryName { get; set; }
        public required string CountryCode { get; set; }
    }

    public class CountryEditDto : EntityGuidDto
    {
        public required string CountryName { get; set; }
        public required string CountryCode { get; set; }
    }

    public class CountryCompactDto : EntityGuidDto
    {
        public required string CountryName { get; set; }
        public required string CountryCode { get; set; }
    }
}