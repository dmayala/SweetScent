using Android.App;
using Android.Runtime;
using Microsoft.Practices.Unity;
using SweetScent.Core;
using SweetScent.Core.Services;
using System;

namespace SweetScent
{
    [Application]
    public class App : Application
    {
        public static UnityContainer Container { get; set; }

        public App(IntPtr h, JniHandleOwnership jho) : base(h, jho)
        {
        }

        public override void OnCreate()
        {
            Container = new UnityContainer();
            Container.RegisterType<ISettings, Settings>();
            Container.RegisterInstance<IPogoService>(Container.Resolve<PogoService>());

            base.OnCreate();
        }
    }
}