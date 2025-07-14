namespace WMS.Models
{
    public class Currency : EntityGuid
    {
        public required string Name { get; set; }        
        public required string Code { get; set; }         
        public int? CountryId { get; set; }               
    }
}
