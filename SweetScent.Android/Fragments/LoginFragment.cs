using Android.Content.PM;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;
using Com.Lilarcor.Cheeseknife;
using SweetScent.Activities;
using System;
using Android.Runtime;
using Android.Support.Design.Widget;

namespace SweetScent.Fragments
{
    public class LoginFragment : Fragment
    {
        const int RequestLocationId = 0;

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
            GetPermissions();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var v = inflater.Inflate(Resource.Layout.fragment_login, container, false);
            Cheeseknife.Inject(this, v);
            return v;
        }

        private void GetPermissions()
        {
            if (ContextCompat.CheckSelfPermission(Activity, Android.Manifest.Permission.AccessFineLocation) != (int)Permission.Granted)
            {
                RequestPermissions(new String[]{
                    Android.Manifest.Permission.AccessCoarseLocation,
                    Android.Manifest.Permission.AccessFineLocation}, RequestLocationId);
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            switch (requestCode) {
                case RequestLocationId:
                {
                    if (grantResults[0] == Permission.Granted)
                    {
                        //Permission Granted
                        var snack = Snackbar.Make(View, "Location permission is available, getting lat/long.", Snackbar.LengthShort);
                        snack.Show();
                    }
                    else
                    {
                        //Permission Denied :(
                        var snack = Snackbar.Make(View, "Location permission is denied.", Snackbar.LengthShort);
                        snack.Show();
                    }
                }
                break;
            }
        }

        [InjectOnClick(Resource.Id.login_button)]
        private void OnClickLoginButton(object sender, EventArgs e)
        {
            var intent = MapsActivity.NewIntent(Context);
            StartActivity(intent);
        }
    }
}