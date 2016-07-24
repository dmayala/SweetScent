using PokemonGo.RocketAPI;
using SweetScent.Core.Containers;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace SweetScent.Core.Services
{
    public class PogoService : IPogoService
    {
        private ISettings _settings;
        private Client _client;

        public PogoService(ISettings settings)
        {
            _settings = settings;
            _client = new Client(_settings);
        }

        public async Task<PogoMapResponse> GetMapData()
        {
            try
            {
                var mapObjects = await _client.GetMapObjects();
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
