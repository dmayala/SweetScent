using Foundation;
using System;
using UIKit;
using CoreLocation;
using MapKit;
using System.Collections.Generic;
using System.Threading;
using SweetScent.Core.Services;
using Microsoft.Practices.Unity;
using System.Threading.Tasks;
using SweetScent.iOS.Utils;
using Realms;
using SweetScent.Core.Models;
using System.Linq;

namespace SweetScent.iOS
{
    public partial class MapsController : UIViewController, IMKMapViewDelegate
    {
        private IPogoService _pogoService;
        private Realm _realm;

        private List<CLLocationCoordinate2D> _scanMap = new List<CLLocationCoordinate2D>();
        private MKUserLocation _currentLocation;

        private bool isSearching = false;
        private CancellationTokenSource cts;

        private Dictionary<long, IMKAnnotation> _pokemonAnnotations = new Dictionary<long, IMKAnnotation>();

        public MapsController (IntPtr handle) : base (handle)
        {
            _pogoService = App.Container.Resolve<IPogoService>();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            MapView.ShowsUserLocation = true;
            MapView.DidUpdateUserLocation += MapView_DidUpdateUserLocation;
        }

        private void MapView_DidUpdateUserLocation(object sender, MKUserLocationEventArgs e)
        {
            _currentLocation = MapView.UserLocation;
            var region = MKCoordinateRegion.FromDistance(_currentLocation.Coordinate, 1500, 1500);
            MapView.SetRegion(region, animated: true);
        }

        private void OnClickSearchButton(object sender, EventArgs e)
        {
            if (!isSearching)
            {
                isSearching = true;
                if (_currentLocation != null)
                {
                    var coordinates = _currentLocation.Coordinate;
                    cts = new CancellationTokenSource();
                    _pogoService.SetInitialLocation(coordinates.Latitude, coordinates.Longitude);
                    ScanMapAsync();
                }
            }
            else
            {
                cts.Cancel();
                cts = null;
                isSearching = false;
            }

        }

        private async Task RefreshMapAsync()
        {
            try
            {
                var curScreen = MapView.VisibleMapRect;
                var pokemonCollection = _realm.All<Pokemon>().ToList();
                foreach (var pokemon in pokemonCollection)
                {
                    var encounterId = pokemon.EncounterId;

                    if (curScreen.Contains(new MKMapPoint(pokemon.Latitude, pokemon.Longitude)))
                    {
                        var expirationDate = DateTimeOffset.FromUnixTimeMilliseconds(pokemon.Expires).UtcDateTime;
                        bool isNotExpired = expirationDate.Subtract(DateTime.UtcNow).Ticks > 0;

                        if (isNotExpired)
                        {
                            if (_pokemonAnnotations.ContainsKey(encounterId))
                            {
                                var marker = _pokemonAnnotations[encounterId];
                                if (marker != null)
                                {
                                    pokemon.UpdateAnnotation(marker);
                                }
                            }
                            else
                            {
                                MapView.AddAnnotation(pokemon.GetAnnotation());
                                _pokemonAnnotations.Add(pokemon.EncounterId, pokemon.GetAnnotation());
                            }
                        }
                        else
                        {
                            if (_pokemonAnnotations.ContainsKey(encounterId))
                            {
                                _pokemonAnnotations[encounterId].Dispose();
                                _pokemonAnnotations.Remove(encounterId);
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
                        if (_pokemonAnnotations[encounterId] != null)
                            _pokemonAnnotations[encounterId].Dispose();

                        _pokemonAnnotations.Remove(encounterId);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private async Task ScanMapAsync()
        {
            var scanValue = 4;
            _scanMap = GenerationUtils.MakeHexScanMap(_currentLocation.Coordinate, scanValue, 1, new List<CLLocationCoordinate2D>());
            try
            {
                await MapLoaderUtil.Run(_scanMap, RefreshMapAsync, cts.Token);
            }
            finally
            {
                // ShowProgressBar(false);
            }
        }

        [Export("viewForAnnotation:")]
        public MKAnnotationView ViewForAnnotation(IMKAnnotation annotation)
        {
            // To do
            return null;
        }
    }
}