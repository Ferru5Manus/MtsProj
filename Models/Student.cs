namespace Dance
{
    public class Student : User
    {
        public int Uid { get ; set  ; }
        public int SchoolId { get; set; }
        public int ParentId { get ; set ; }
        public string Name { get  ; set  ; }
        public string QrUrl { get  ; set  ; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int DanceCoinAmount { get ; set ; }
        public List<string> Achievements { get; set; }
        public int Likes { get; set; }
        public string Role = "Student";
    }
}
