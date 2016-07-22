using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.App;

namespace SweetScent.Activities
{
    public abstract class SingleFragmentActivity : AppCompatActivity
    {
        protected abstract Fragment CreateFragment();

        protected virtual int GetLayoutResId()
        {
            return Resource.Layout.activity_fragment;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(GetLayoutResId());

            var fragment = SupportFragmentManager.FindFragmentById(Resource.Id.fragment_container);
            if (fragment == null)
            {
                fragment = CreateFragment();
                SupportFragmentManager.BeginTransaction()
                                      .Add(Resource.Id.fragment_container, fragment)
                                      .Commit();
            }
        }
    }
}