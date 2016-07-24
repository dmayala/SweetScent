using Android.App;
using Android.Content;
using SweetScent.Fragments;

namespace SweetScent.Activities
{
    [Activity]
    public class MapsActivity : SingleFragmentActivity
    {
        public static Intent NewIntent(Context context)
        {
            var i = new Intent(context, typeof(MapsActivity));
            return i;
        }

        protected override Android.Support.V4.App.Fragment CreateFragment()
        {
            return MapsFragment.NewInstance();
        }
    }
}
