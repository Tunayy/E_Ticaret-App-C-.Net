namespace E_Commerce.Entities
{
    public class JwtSettings
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expiration { get; set; }

    }
}
