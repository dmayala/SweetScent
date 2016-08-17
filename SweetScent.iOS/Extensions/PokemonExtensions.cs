using CoreLocation;
using MapKit;
using System;
using UIKit;

namespace SweetScent.Core.Models
{
    public static class PokemonExtensions
    {
        private static string GetExpirationTime(this Pokemon pokemon)
        {
            var expirationDate = DateTimeOffset.FromUnixTimeMilliseconds(pokemon.Expires).UtcDateTime;
            var duration = expirationDate.Subtract(DateTime.UtcNow);
            var timeOut = string.Format("{0:D2}:{1:D2}", duration.Minutes, duration.Seconds);
            return timeOut;
        }

        private static UIImage GetIcon(this Pokemon pokemon)
        {
            // Grab correct icon for Pokemon
            return UIImage.FromFile($"Pokemon_{pokemon.Number}");
        }

        public static IMKAnnotation UpdateAnnotation(this Pokemon pokemon, IMKAnnotation annotation)
        {
            return annotation;
        }


        public static IMKAnnotation GetAnnotation(this Pokemon pokemon)
        {
            var point = new CLLocationCoordinate2D(pokemon.Latitude, pokemon.Longitude);
            var pointAnnotation = new MKPointAnnotation() { Coordinate = point };
            return pointAnnotation;
        }

        public static MKAnnotationView GetAnnotationView(this Pokemon pokemon, IMKAnnotation annotation)
        {
            var annotationView = new MKAnnotationView(annotation, "pin")
            {
                Image = pokemon.GetIcon()
            };

            return annotationView;
        }
    }
}