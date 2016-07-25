using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using SweetScent.Core.Containers;
using Android.Locations;
using Android.Content;
using System.Linq;
using SweetScent.Core.Services;
using System.Threading.Tasks;

namespace SweetScent.Fragments
{
    public class MapsFragment : SupportMapFragment, IOnMapReadyCallback
    {
        private GoogleMap _map;
        private LocationManager _locationManager;
        private IPogoService _pogoService;
        private PogoMapResponse _pogoResponse;

        private Location _currentLocation;

        public static new MapsFragment NewInstance()
        {
            return new MapsFragment();
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            _locationManager = Activity.GetSystemService(Context.LocationService) as LocationManager;
            GetMapAsync(this);
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            _map = googleMap;
            _map.MyLocationEnabled = true;

            var criteria = new Criteria();
            var provider = _locationManager.GetBestProvider(criteria, true);
            _currentLocation = _locationManager.GetLastKnownLocation(provider);
            _pogoService = new PogoService(new Settings() {
                DefaultLatitude = _currentLocation.Latitude,
                DefaultLongitude = _currentLocation.Longitude,
                DefaultAltitude = _currentLocation.Altitude
            });

            CenterCamera();
            LoadPogoMap();
        }

        private void CenterCamera()
        {
            if (_currentLocation != null)
            {
                var target = new LatLng(_currentLocation.Latitude, _currentLocation.Longitude);

                var cameraUpdate = new CameraPosition.Builder()
                    .Zoom(15)
                    .Target(target)
                    .Build();

                _map.AnimateCamera(CameraUpdateFactory.NewCameraPosition(cameraUpdate));
            }
        }

        private async Task LoadPogoMap()
        {
            var mapData = await _pogoService.GetMapData();
            
            foreach (var pokemon in mapData.Pokemon)
            {
                var point = new LatLng(pokemon.Latitude, pokemon.Longitude);
                var marker = new MarkerOptions()
                    .SetPosition(point)
                    .SetTitle(pokemon.PokemonId.ToString());
                _map.AddMarker(marker);
            }
        }
    }
}
