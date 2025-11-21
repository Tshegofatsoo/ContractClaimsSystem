namespace ContractClaimsSystem.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string FullName { get; internal set; }
    }
}
