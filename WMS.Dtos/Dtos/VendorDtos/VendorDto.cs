namespace WMS.Dtos
{
    public class VendorDto : EntityGuidDto
    {
        public required string Name { get; set; }
        public required string Code { get; set; }
        public required char FDType { get; set; }
        public required string Addr1 { get; set; }
        public string? Addr2 { get; set; }
        public required string City { get; set; }
        public required int CountryId { get; set; }
        public required int StateId { get; set; }
        public required string Pin { get; set; }
        public required string EmailID { get; set; }
        public required string Phone { get; set; }
        public required string ContactPerson { get; set; }
        public required string CPEmailID { get; set; }
        public required string CPMobile { get; set; }
        public string? Url { get; set; }
        public required int BaseCurr { get; set; }
        public string? ECCNo { get; set; }
        public string? TINNo { get; set; }
        public DateTime? TINDate { get; set; }
        public string? CSTNo { get; set; }
        public DateTime? CSTDate { get; set; }
        public required int UserID { get; set; }
        public int? CustomerId { get; set; }
        public char? TransExist { get; set; }
    }

    public class VendorCreateDto : EntityGuidDto
    {
        public required string Name { get; set; }
        public required string Code { get; set; }
        public required char FDType { get; set; }
        public required string Addr1 { get; set; }
        public string? Addr2 { get; set; }
        public required string City { get; set; }
        public required int CountryId { get; set; }
        public required int StateId { get; set; }
        public required string Pin { get; set; }
        public required string EmailID { get; set; }
        public required string Phone { get; set; }
        public required string ContactPerson { get; set; }
        public required string CPEmailID { get; set; }
        public required string CPMobile { get; set; }
        public string? Url { get; set; }
        public required int BaseCurr { get; set; }
        public string? ECCNo { get; set; }
        public string? TINNo { get; set; }
        public DateTime? TINDate { get; set; }
        public string? CSTNo { get; set; }
        public DateTime? CSTDate { get; set; }
        public required int UserID { get; set; }
        public int? CustomerId { get; set; }
    }

    public class VendorEditDto : EntityGuidDto
    {
        public required string Name { get; set; }
        public required string Code { get; set; }
        public required char FDType { get; set; }
        public required string Addr1 { get; set; }
        public string? Addr2 { get; set; }
        public required string City { get; set; }
        public required int CountryId { get; set; }
        public required int StateId { get; set; }
        public required string Pin { get; set; }
        public required string EmailID { get; set; }
        public required string Phone { get; set; }
        public required string ContactPerson { get; set; }
        public required string CPEmailID { get; set; }
        public required string CPMobile { get; set; }
        public string? Url { get; set; }
        public required int BaseCurr { get; set; }
        public string? ECCNo { get; set; }
        public string? TINNo { get; set; }
        public DateTime? TINDate { get; set; }
        public string? CSTNo { get; set; }
        public DateTime? CSTDate { get; set; }
        public required int UserID { get; set; }
        public int? CustomerId { get; set; }
    }

    public class VendorCompactDto : EntityGuidDto
    {
        public required string Name { get; set; }
        public required string Code { get; set; }
        public char FDType { get; set; }
        public string City { get; set; } = string.Empty;
        public string? Phone { get; set; }
    }
}
