using PokemonGo.RocketAPI.GeneratedCode;
using System.Collections.Generic;

namespace SweetScent.Core.Containers
{
    public class PogoMapResponse
    {
        private IEnumerable<FortData> Forts;
        private IEnumerable<MapPokemon> Pokemon;

        public PogoMapResponse(IEnumerable<FortData> Forts, IEnumerable<MapPokemon> Pokemon)
        {
            this.Forts = Forts;
            this.Pokemon = Pokemon;
        }
    }
}
