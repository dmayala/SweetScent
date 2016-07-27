using SweetScent.Core.Containers;
using System.Threading.Tasks;
using System.Linq;
using System;
using PokemonGo.RocketAPI;

namespace SweetScent.Core.Services
{
    public class PogoService : IPogoService
    {
        private Client _client;
        private ISettings _settings;

        public PogoService(ISettings settings)
        {
            _settings = settings;
            _client = new Client(new SettingsMap(_settings));
        }

        public async Task<PogoMapResponse> GetMapData()
        {
            try
            {
                await _client.Login.DoPtcLogin();

                var mapObjects = await _client.Map.GetMapObjects();
                var pokemon = mapObjects.MapCells.SelectMany(m => m.CatchablePokemons);
                var forts = mapObjects.MapCells.SelectMany(m => m.Forts);

                return new PogoMapResponse(forts, pokemon);
            }
            catch (Exception ex)
            {
                
            }

            return default(PogoMapResponse);
        }
    }
}
