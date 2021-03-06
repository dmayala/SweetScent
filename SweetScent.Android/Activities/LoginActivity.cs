using Android.App;
using Android.Content;
using SweetScent.Fragments;

namespace SweetScent.Activities
{
    [Activity(MainLauncher = true, Icon = "@drawable/icon")]
    public class LoginActivity : SingleFragmentActivity
    {
        public static Intent NewIntent(Context context)
        {
            return new Intent(context, typeof(LoginActivity));
        }

        protected override Android.Support.V4.App.Fragment CreateFragment()
        {
            return LoginFragment.NewInstance();
        }
    }
}
