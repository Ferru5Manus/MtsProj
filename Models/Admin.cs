namespace Dance
{
    public class Admin : User
    {
        public int Uid { get  ; set ; }
        public int SchoolId { get; set; }
        public string Name { get  ; set  ; }
        public string QrUrl { get  ; set  ; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Role = "Admin";
    }
}
