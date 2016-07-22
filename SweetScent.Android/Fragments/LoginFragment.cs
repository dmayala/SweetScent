using Android.OS;
using Android.Support.V4.App;
using Android.Views;

namespace SweetScent.Fragments
{
    public class LoginFragment : Fragment
    {

        public static LoginFragment NewInstance()
        {
            return new LoginFragment();
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var v = inflater.Inflate(Resource.Layout.fragment_login, container, false);
            return v;
        }
    }
}