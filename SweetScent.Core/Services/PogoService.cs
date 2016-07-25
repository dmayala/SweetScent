using PokemonGo.RocketAPI;
using SweetScent.Core.Containers;
using System.Threading.Tasks;
using System.Linq;
using System;
using POGOProtos.Map.Fort;
using POGOProtos.Map.Pokemon;
using System.Collections.Generic;

namespace SweetScent.Core.Services
{
    public class PogoService : IPogoService
    {
        private Client _client;
        private ISettings _settings;

        public PogoService(ISettings settings)
        {
            AutoMapper.Mapper.CreateMap<PokemonGo.RocketAPI.GeneratedCode.MapPokemon, MapPokemon>();
            AutoMapper.Mapper.CreateMap<PokemonGo.RocketAPI.GeneratedCode.FortData, FortData>();

            _settings = settings;
            _client = new Client(new SettingsMap(_settings));
        }

        public async Task<PogoMapResponse> GetMapData()
        {
            try
            {
                await _client.DoPtcLogin(_settings.PtcUsername, _settings.PtcPassword);
                await _client.SetServer();

                var mapObjects = await _client.GetMapObjects();
                var pokeObj = mapObjects.MapCells.SelectMany(m => m.CatchablePokemons);
                var pokemon = AutoMapper.Mapper.Map<IEnumerable<MapPokemon>>(pokeObj);
                var forts = AutoMapper.Mapper.Map<IEnumerable<FortData>>(mapObjects.MapCells.SelectMany(m => m.Forts));

                return new PogoMapResponse(forts, pokemon);
            }
            catch (Exception ex)
            {
                
            }

            return default(PogoMapResponse);
        }
    }
}
