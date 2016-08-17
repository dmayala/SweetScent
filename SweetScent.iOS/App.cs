using Microsoft.Practices.Unity;
using SweetScent.Core;
using SweetScent.Core.Services;
using CoreLocation;

namespace SweetScent.iOS
{
    public static class App
    {
        public static UnityContainer Container { get; set; }

        public static void Initialize()
        {
            Container = new UnityContainer();
            Container.RegisterType<ISettings, Settings>();
            Container.RegisterInstance<IPogoService>(Container.Resolve<PogoService>());
            Container.RegisterInstance(new CLLocationManager());
        }
    }
}
