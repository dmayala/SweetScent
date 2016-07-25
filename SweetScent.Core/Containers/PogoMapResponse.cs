using POGOProtos.Map.Fort;
using POGOProtos.Map.Pokemon;
using System.Collections.Generic;

namespace SweetScent.Core.Containers
{
    public class PogoMapResponse
    {
        public IEnumerable<FortData> Forts { get; private set; }
        public IEnumerable<MapPokemon> Pokemon { get; private set; }

        public PogoMapResponse(IEnumerable<FortData> Forts, IEnumerable<MapPokemon> Pokemon)
        {
            this.Forts = Forts;
            this.Pokemon = Pokemon;
        }
    }
}
