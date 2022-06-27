
namespace HotelBooking.Core.Configuration
{
    public class JwtConfiguration
    {
        public const string JwtConfigurations = "JwtConfigurations";

        public string Audience { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string PublicKeyFilePath { get; set; } = string.Empty;
        public string PrivateKeyFilePath { get; set; } = string.Empty;
    }
}
