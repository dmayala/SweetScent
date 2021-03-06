﻿using CoreLocation;
using SweetScent.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Realms;
using SweetScent.Core.Models;

namespace SweetScent.iOS.Utils
{
    public static class MapLoaderUtil
    {
        public static async Task Run(IList<CLLocationCoordinate2D> scanMap, Func<Task> callback, CancellationToken ct = default(CancellationToken))
        {
            var pogoService = App.Container.Resolve<IPogoService>();

            int pos = 1;
            foreach (var loc in scanMap)
            {
                pogoService.SetInitialLocation(loc.Latitude, loc.Longitude);
                var mapData = await pogoService.GetMapData(ct);
                var collectionPokemon = mapData.Pokemon;

                await Task.Run(() =>
                {
                    using (var realm = Realm.GetInstance())
                    {
                        using (var transaction = realm.BeginWrite())
                        {
                            foreach (var pokemon in collectionPokemon)
                            {
                                var myPokemon = realm.CreateObject<Pokemon>();
                                myPokemon.EncounterId = (long)pokemon.EncounterId;
                                myPokemon.Name = pokemon.PokemonId.ToString();
                                myPokemon.Expires = pokemon.ExpirationTimestampMs;
                                myPokemon.Latitude = pokemon.Latitude;
                                myPokemon.Longitude = pokemon.Longitude;
                                myPokemon.Number = (int)pokemon.PokemonId;
                            }

                            transaction.Commit();
                        }
                    }
                });

                await callback.Invoke();
                pos++;
                await Task.Delay(5000);
            }
        }
    }
}
