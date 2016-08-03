using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Locations;
using Android.Content;
using SweetScent.Core.Services;
using System;
using Android.Views;
using Android.Support.V4.App;
using Com.Lilarcor.Cheeseknife;
using Android.Support.Design.Widget;
using Microsoft.Practices.Unity;
using System.Threading;
using Realms;
using SweetScent.Core.Models;
using System.Threading.Tasks;
using SweetScent.Utils;
using System.Linq;
using System.Collections.Generic;

namespace SweetScent.Fragments
{
    public class MapsFragment : Fragment, IOnMapReadyCallback
    {
        private SupportMapFragment _mapFragment;
        private GoogleMap _map;
        private LocationManager _locationManager;
        private Location _currentLocation;
        private List<LatLng> _scanMap = new List<LatLng>();

        private Realm _realm;
        private IPogoService _pogoService;

        [InjectView(Resource.Id.maps_search_button)]
        private FloatingActionButton _searchBtn;
        [InjectView(Resource.Id.maps_progress_bar)]
        private Android.Widget.ProgressBar _progressBar;

        private bool isSearching = false;
        private CancellationTokenSource cts;

        private Dictionary<long, Marker> _pokemonMarkers = new Dictionary<long, Marker>();

        public static MapsFragment NewInstance()
        {
            return new MapsFragment();
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            _locationManager = Activity.GetSystemService(Context.LocationService) as LocationManager;
            _pogoService = App.Container.Resolve<IPogoService>();
            _realm = Realm.GetInstance();
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

        public void OnMapReady(GoogleMap googleMap)
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

        private async Task RefreshMapAsync()
        {
            try
            {
                var curScreen = _map.Projection.VisibleRegion.LatLngBounds;
                var pokemonCollection = _realm.All<Pokemon>().ToList();
                foreach (var pokemon in pokemonCollection)
                {
                    var encounterId = pokemon.EncounterId;

                    if (curScreen.Contains(new LatLng(pokemon.Latitude, pokemon.Longitude)))
                    {
                        var expirationDate = DateTimeOffset.FromUnixTimeMilliseconds(pokemon.Expires).UtcDateTime;
                        bool isNotExpired = expirationDate.Subtract(DateTime.UtcNow).Ticks > 0;

                        if (isNotExpired)
                        {
                            if (_pokemonMarkers.ContainsKey(encounterId))
                            {
                                var marker = _pokemonMarkers[encounterId];
                                if (marker != null)
                                {
                                    pokemon.UpdateMarker(marker, Context);
                                }
                            }
                            else
                            {
                                _pokemonMarkers.Add(pokemon.EncounterId, _map.AddMarker(pokemon.GetMarker(Context)));
                            }
                        }
                        else
                        {
                            if (_pokemonMarkers.ContainsKey(encounterId))
                            {
                                _pokemonMarkers[encounterId].Remove();
                                _pokemonMarkers.Remove(encounterId);
                            }

                            await Task.Run(() =>
                            {
                                using (var realm = Realm.GetInstance())
                                {
                                    var expiredPokemon = realm.All<Pokemon>().First(p => p.EncounterId == encounterId);

                                    using (var trans = realm.BeginWrite())
                                    {
                                        realm.Remove(expiredPokemon);
                                        trans.Commit();
                                    }
                                }
                            });

                        }
                    }
                    else
                    {
                        if (_pokemonMarkers[encounterId] != null)
                            _pokemonMarkers[encounterId].Remove();

                        _pokemonMarkers.Remove(encounterId);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private async Task ScanMapAsync()
        {
            ShowProgressBar(true);

            var scanValue = 4;
            _scanMap = GenerationUtils.MakeHexScanMap(_map.CameraPosition.Target, scanValue, 1, new List<LatLng>());
            try
            {
                await MapLoaderUtil.Run(_scanMap, RefreshMapAsync, cts.Token);
            }
            finally
            {
                ShowProgressBar(false);
            }
        }

        private void ShowProgressBar(bool status)
        {
            if (status)
            {
                _progressBar.Visibility = ViewStates.Visible;
                _searchBtn.SetImageDrawable(Context.GetDrawable(Resource.Drawable.ic_pause_white_24dp));
            }
            else
            {
                _progressBar.Visibility = ViewStates.Invisible;
                _searchBtn.SetImageDrawable(Context.GetDrawable(Resource.Drawable.ic_track_changes_white_24dp));
            }
        }

        [InjectOnClick(Resource.Id.maps_search_button)]
        private void OnClickSearchButton(object sender, EventArgs e)
        {
            if (!isSearching)
            {
                isSearching = true;
                if (_currentLocation != null)
                {
                    cts = new CancellationTokenSource();
                    _pogoService.SetInitialLocation(_currentLocation.Latitude, _currentLocation.Longitude, _currentLocation.Altitude);
                    ScanMapAsync();
                }
            } else
            {
                cts.Cancel();
                cts = null;
                isSearching = false;
            }

        }
    }
}
