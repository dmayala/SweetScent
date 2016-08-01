using Microsoft.Practices.Unity;
using Realms;
using SweetScent.Core.Services;
using System.Threading.Tasks;
using SweetScent.Core.Models;
using System.Threading;

namespace SweetScent.Utils
{
    public static class MapLoaderUtil
    {
        public static async Task Run(CancellationToken ct = default(CancellationToken))
        {
            var pogoService = App.Container.Resolve<IPogoService>();
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
        }
    }
}