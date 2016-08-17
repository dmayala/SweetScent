using SweetScent.Core.Services;
using System;
using UIKit;
using Microsoft.Practices.Unity;

namespace SweetScent.iOS
{
    public partial class LoginController : UIViewController
    {
        private IPogoService _pogoService;

        public LoginController (IntPtr handle) : base (handle)
        {
            _pogoService = App.Container.Resolve<IPogoService>();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            LoginButton.TouchUpInside += OnClickLoginButton;
        }

        private async void OnClickLoginButton(object sender, EventArgs e)
        {
            PerformSegue("LoginSuccessSegue", this);
            //try
            //{
            //    await _pogoService.LoginAsync(UsernameField.Text, PasswordField.Text);
            //    PerformSegue("LoginSuccessSegue", this);
            //}
            //catch (Exception ex)
            //{
            //    var alert = new UIAlertView()
            //    {
            //        Title = "Login Error",
            //        Message = ex.Message
            //    };
            //    alert.AddButton("OK");
            //    alert.Show();
            //}
        }
    }
}