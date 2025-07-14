namespace WMS.Models
{
    public class Carrier : EntityGuid
    {        

        public required string Name { get; set; }
        public required string Type { get; set; }
        public required string Addr1 { get; set; }  
        public string? Addr2 { get; set; }              
        public required string City { get; set; }
        public required int CountryId { get; set; }
        public required int StateId { get; set; }
        public required string Pin { get; set; }         
        public string? CpName { get; set; }         
        public string? Email { get; set; }           
        public required string Phone { get; set; }       
        public required string Mobile { get; set; }   
        public string? LstRegnno { get; set; }              
        public DateTime? LstRegndate { get; set; }       
        public string? CstRegnno { get; set; }             
        public DateTime? CstRegndate { get; set; }          
        public string? StRegnno { get; set; }           
        public DateTime? StRegndate { get; set; }

        //Generated Fields and session values
        public required int CustomerId { get; set; }
        public string? TransExistFlag { get; set; }      
    }
}
