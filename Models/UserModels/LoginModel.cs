namespace Models.UserModels
{
    public class LoginModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public UserModel AuthentificationData { get; set; }
    }
}
