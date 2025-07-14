using WMS.Core.Models;

namespace WMS.Models.Models.CurrencyModel
{
    public class Currency : EntityGuid
    {
        public required string Name { get; set; }        
        public required string Code { get; set; }         
        public int? CountryId { get; set; }               
    }
}
