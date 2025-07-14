namespace WMS.Models
{
    public class User : EntityGuid
    {
        public required string Username { get; set; }
        public required string PasswordHash { get; set; } 
        public required string Role { get; set; } 
        public required string Email { get; set; }
    }
}