using Android.Gms.Common.Apis;
using Android.Gms.Maps;
using Android.OS;

namespace SweetScent.Fragments
{
    public class MapsFragment : SupportMapFragment
    {
        private GoogleApiClient _mapsClient;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
    }
}