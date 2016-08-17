using CoreLocation;
using MapKit;
using SweetScent.Core.Models;

namespace SweetScent.iOS.Annotations
{
    public class PokemonAnnotation : MKPointAnnotation
    {
        public Pokemon Pokemon { get; private set; }

        public PokemonAnnotation(Pokemon pokemon)
        {
            Pokemon = pokemon;
            Coordinate = new CLLocationCoordinate2D(pokemon.Latitude, pokemon.Longitude);
        }
    }
}
