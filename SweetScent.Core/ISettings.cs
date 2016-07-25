using AllEnum;
using SweetScent.Core.Enums;
using System.Collections.Generic;

namespace SweetScent.Core
{
    public interface ISettings
    {
        AuthType AuthType { get; }
        double DefaultAltitude { get; }
        double DefaultLatitude { get; }
        double DefaultLongitude { get; }
        string GoogleRefreshToken { get; set; }
        string PtcPassword { get; }
        string PtcUsername { get; }
    }
}
