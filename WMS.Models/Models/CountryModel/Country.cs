namespace WMS.Models
{
    public class Country : EntityGuid
    {
        public required string CountryName { get; set; }
        public required string CountryCode { get; set; }

    }
}