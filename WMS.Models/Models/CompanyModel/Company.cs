using WMS.Core.Models;

namespace WMS.Models.Models.CompanyModel
{
    public class Company : EntityGuid
    {
        public required string Name { get; set; }
        public required string Code { get; set; }
        public required string Addr1 { get; set; }
        public string? Addr2 { get; set; }
        public required string City { get; set; }
        public required int StateId { get; set; }
        public required string Pin { get; set; }
        public required int CountryId { get; set; }
        public required string ContactPerson { get; set; }
        public required string Phone { get; set; }
        public required string CPMobile { get; set; }
        public required string EmailID { get; set; }
        public required string CPEmailID { get; set; }
        public string? URL { get; set; }
        public required int BaseCurr { get; set; }
        public string? ECCNO { get; set; }
        public string? TINNO { get; set; }
        public DateTime? TINDATE { get; set; }
        public string? CSTNO { get; set; }
        public DateTime? CSTDATE { get; set; }
        public required int UserID { get; set; }
        public string? _3PLFlag { get; set; }
        public string? TransExistFlag { get; set; }
        public required byte[] Image { get; set; }
        public required string ImagePath { get; set; }
        public required string ImageName { get; set; }
    }
}