using Foundation;
using QQ.Binding.iOS;
using System;
using UIKit;

namespace QQLoginiOS
{
    public partial class ViewController : UIViewController
    {
        private TencentOAuth _tencentOAuth;
        private LoginDelegate _delegate;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            _delegate = new LoginDelegate();
            _delegate.LoginSuccess += (s, e) => {
                var x = _tencentOAuth.UserInfo;
            };
            _tencentOAuth = new TencentOAuth("1106970090", _delegate);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void Login(UIButton sender)
        {
            //var permissions = ["get_user_info", "get_simple_userinfo"];
            var permissions = new NSString[] { Constants.kOPEN_PERMISSION_GET_OTHER_INFO, Constants.kOPEN_PERMISSION_GET_SIMPLE_USER_INFO };
            _tencentOAuth.Authorize(permissions);
        }
    }

    public class LoginDelegate : TencentSessionDelegate
    {
        public EventHandler LoginSuccess;

        public override void TencentDidLogin()
        {
            LoginSuccess?.Invoke(this, new EventArgs());
        }

        public override void TencentDidNotLogin(bool cancelled)
        {
        }

        public override void TencentDidNotNetWork()
        {
        }

        public override void GetUserInfoResponse(APIResponse response)
        {
        }
    }
}