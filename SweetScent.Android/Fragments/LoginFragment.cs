using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Com.Lilarcor.Cheeseknife;
using SweetScent.Activities;
using System;

namespace SweetScent.Fragments
{
    public class LoginFragment : Fragment
    {
        [InjectView(Resource.Id.login_username)]
        private EditText _username;
        [InjectView(Resource.Id.login_password)]
        private EditText _password;
        [InjectView(Resource.Id.login_button)]
        private Button _loginBtn;

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
            Cheeseknife.Inject(this, v);
            return v;
        }

        [InjectOnClick(Resource.Id.login_button)]
        private void OnClickLoginButton(object sender, EventArgs e)
        {
            var intent = MapsActivity.NewIntent(Context);
            StartActivity(intent);
        }
    }
}