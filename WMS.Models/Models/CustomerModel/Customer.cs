namespace WMS.Models
{
    public class Customer : EntityGuid
    {
        public required string Name { get; set; }
        public required string Code { get; set; }
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
        public string? URL { get; set; }
        public int BaseCurr { get; set; }
        public string? ECCNO { get; set; }
        public string? TINNO { get; set; }
        public DateTime? TINDATE { get; set; }
        public string? CSTNO { get; set; }
        public DateTime? CSTDATE { get; set; }

        //Generated Fields and session values
        public int UserID { get; set; }
        public int CompanyId { get; set; }
        public char TransExistFlag { get; set; }
    }
}
