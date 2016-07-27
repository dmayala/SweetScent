using PokemonGo.RocketAPI.Enums;

namespace SweetScent.Core
{
    internal class SettingsMap : PokemonGo.RocketAPI.ISettings
    {
        public SettingsMap(ISettings _settings)
        {
            AuthType = (AuthType) _settings.AuthType;
            DefaultAltitude = _settings.DefaultAltitude;
            DefaultLatitude = _settings.DefaultLatitude;
            DefaultLongitude = _settings.DefaultLongitude;
            GoogleRefreshToken = _settings.GoogleRefreshToken;
            PtcPassword = _settings.PtcPassword;
            PtcUsername = _settings.PtcUsername;
        }

        public AuthType AuthType { get; set; }

        public double DefaultAltitude { get; set; }

        public double DefaultLatitude { get; set; }

        public double DefaultLongitude { get; set; }

        public string GoogleRefreshToken { get; set; }

        public string PtcPassword { get; set; }

        public string PtcUsername { get; set; }
    }
}