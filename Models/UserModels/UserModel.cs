namespace Models.UserModels
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public virtual UserProfileModel UserProfile { get; set; }
    }
}
