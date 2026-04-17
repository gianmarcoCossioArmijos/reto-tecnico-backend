namespace RetoTecnico.Model
{
    public class UserLoginResponse
    {
        public string Username { get; set; }

        public string AccessToken { get; set; }

        public int Expiration { get; set; } 
    }
}
