using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Locations;
using Android.Content;
using SweetScent.Core.Services;
using System.Threading.Tasks;
using SweetScent.Utils;
using System;
using Android.Views;
using Android.Support.V4.App;
using Com.Lilarcor.Cheeseknife;
using Android.Support.Design.Widget;
using Microsoft.Practices.Unity;

namespace SweetScent.Fragments
{
    public class MapsFragment : Fragment, IOnMapReadyCallback
    {
        private SupportMapFragment _mapFragment;
        private GoogleMap _map;
        private LocationManager _locationManager;
        private IPogoService _pogoService;
        private Location _currentLocation;

        [InjectView(Resource.Id.maps_search_button)]
        private FloatingActionButton _searchBtn;
        [InjectView(Resource.Id.maps_progress_bar)]
        private Android.Widget.ProgressBar _progressBar;

        public static MapsFragment NewInstance()
        {
            return new MapsFragment();
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            _locationManager = Activity.GetSystemService(Context.LocationService) as LocationManager;
            _pogoService = App.Container.Resolve<IPogoService>();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var v = inflater.Inflate(Resource.Layout.fragment_maps, container, false);
            Cheeseknife.Inject(this, v);
            return v;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            _mapFragment = (SupportMapFragment) ChildFragmentManager.FindFragmentById(Resource.Id.map);
            if (_mapFragment == null)
            {
                _mapFragment = SupportMapFragment.NewInstance();
                ChildFragmentManager.BeginTransaction()
                    .Replace(Resource.Id.map, _mapFragment)
                    .Commit();
            }
            _mapFragment.GetMapAsync(this);
        }

        public async void OnMapReady(GoogleMap googleMap)
        {
            _map = googleMap;
            _map.MyLocationEnabled = true;

            var criteria = new Criteria();
            var provider = _locationManager.GetBestProvider(criteria, true);
            _currentLocation = _locationManager.GetLastKnownLocation(provider);
            CenterCamera();
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

        [InjectOnClick(Resource.Id.maps_search_button)]
        private void OnClickSearchButton(object sender, EventArgs e)
        {
            if (_currentLocation != null)
            {
                _pogoService.SetInitialLocation(_currentLocation.Latitude, _currentLocation.Longitude, _currentLocation.Altitude);
                LoadPogoMapAsync();
            }
        }

        private async void LoadPogoMapAsync()
        {
            ShowProgressBar(true);

            var mapData = await _pogoService.GetMapData();

            foreach (var pokemon in mapData.Pokemon)
            {
                // Grab correct icon for Pokemon
                var uri = "p" + (int) pokemon.PokemonId;
                int resourceID = Context.Resources.GetIdentifier(uri, "drawable", Context.PackageName);

                // Find the duration
                var expirationDate = DateTimeOffset.FromUnixTimeMilliseconds(pokemon.ExpirationTimestampMs).UtcDateTime;
                var duration = expirationDate.Subtract(DateTime.Now);
                var timeOut = string.Format("{0:D2}:{1:D2}", duration.Minutes, duration.Seconds);

                int scale = 2;

                var bitmap = DrawableUtils.WriteTextOnDrawable(resourceID, timeOut, scale, Context);

                var point = new LatLng(pokemon.Latitude, pokemon.Longitude);
                var marker = new MarkerOptions()
                    .SetIcon(BitmapDescriptorFactory.FromBitmap(bitmap))
                    .SetPosition(point)
                    .SetTitle(pokemon.PokemonId.ToString())
                    .SetSnippet(timeOut);
                _map.AddMarker(marker);
            }
            ShowProgressBar(false);
        }

        private void ShowProgressBar(bool status)
        {
            if (status)
            {
                _progressBar.Visibility = ViewStates.Visible;
                _searchBtn.SetImageDrawable(Context.GetDrawable(Resource.Drawable.ic_pause_white_24dp));
                _searchBtn.Enabled = false;
            }
            else
            {
                _progressBar.Visibility = ViewStates.Invisible;
                _searchBtn.SetImageDrawable(Context.GetDrawable(Resource.Drawable.ic_track_changes_white_24dp));
                _searchBtn.Enabled = true;
            }
        }
    }
}
