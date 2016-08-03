using Android.Content;
using Android.Gms.Maps.Model;
using SweetScent.Utils;
using System;

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

        private static Android.Graphics.Bitmap GetIcon(this Pokemon pokemon, Context context)
        {
            // Grab correct icon for Pokemon
            var uri = "p" + pokemon.Number;
            int resourceID = context.Resources.GetIdentifier(uri, "drawable", context.PackageName);

            int scale = 2;

            // Grab duration
            var timeOut = pokemon.GetExpirationTime();

            var bitmap = DrawableUtils.WriteTextOnDrawable(resourceID, timeOut, scale, context);
            return bitmap;
        }

        public static MarkerOptions GetMarker(this Pokemon pokemon, Context context)
        {
            var point = new LatLng(pokemon.Latitude, pokemon.Longitude);
            var marker = new MarkerOptions()
                .SetIcon(BitmapDescriptorFactory.FromBitmap(pokemon.GetIcon(context)))
                .SetPosition(point)
                .SetTitle(pokemon.Name)
                .SetSnippet(pokemon.GetExpirationTime());

            return marker;
        }

        public static Marker UpdateMarker(this Pokemon pokemon, Marker marker, Context context)
        {
            marker.SetIcon(BitmapDescriptorFactory.FromBitmap(pokemon.GetIcon(context)));
            marker.Snippet = pokemon.GetExpirationTime();
            return marker;
        }
    }
}