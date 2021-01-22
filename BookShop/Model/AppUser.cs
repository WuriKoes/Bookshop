namespace BookShop.Model
{
    public class AppUser
    {
        public int Id { get; set; }
        
        public string UserName { get; set; }

        public byte[] PassworHash { get; set; }

        public byte[] PasswordSalt { get; set; }

    }
}