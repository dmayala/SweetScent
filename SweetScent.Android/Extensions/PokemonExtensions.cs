using Android.Content;
using Android.Gms.Maps.Model;
using SweetScent.Utils;
using System;

namespace SweetScent.Core.Models
{
    public static class PokemonExtensions
    {
        public static MarkerOptions GetMarker(this Pokemon pokemon, Context context)
        {
            // Grab correct icon for Pokemon
            var uri = "p" + pokemon.Number;
            int resourceID = context.Resources.GetIdentifier(uri, "drawable", context.PackageName);

            // Find the duration
            var expirationDate = DateTimeOffset.FromUnixTimeMilliseconds(pokemon.Expires).UtcDateTime;
            var duration = expirationDate.Subtract(DateTime.Now);
            var timeOut = string.Format("{0:D2}:{1:D2}", duration.Minutes, duration.Seconds);

            int scale = 2;

            var bitmap = DrawableUtils.WriteTextOnDrawable(resourceID, timeOut, scale, context);

            var point = new LatLng(pokemon.Latitude, pokemon.Longitude);
            var marker = new MarkerOptions()
                .SetIcon(BitmapDescriptorFactory.FromBitmap(bitmap))
                .SetPosition(point)
                .SetTitle(pokemon.Name)
                .SetSnippet(timeOut);

            return marker;
        }
    }
}