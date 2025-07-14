using WMS.Core.Models;

namespace WMS.Models.Models.CountryModel
{
    public class Country : EntityGuid
    {
        public required string CountryName { get; set; }
        public required string CountryCode { get; set; }

    }
}