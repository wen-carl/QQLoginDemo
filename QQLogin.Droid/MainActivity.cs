using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Com.Tencent.Connect;
using Com.Tencent.Connect.Common;
using Com.Tencent.Tauth;
using Java.Lang;
using Org.Json;

namespace QQLogin.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IUiListener
    {
        private Tencent _tencent;
        private LoginType _loginType = LoginType.None;

        private TextView _tv;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            _tv = FindViewById<TextView>(Resource.Id.textView1);

            _tencent = Tencent.CreateInstance("1106970090", this.ApplicationContext);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            if (requestCode == Constants.RequestLogin)
            {
                Tencent.OnActivityResultData(requestCode, (int)resultCode, data, this);
            }
            base.OnActivityResult(requestCode, resultCode, data);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            //Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
            //    .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();

            _tencent.Logout(this);
            _loginType = LoginType.Login;
            _tencent.Login(this, "all", this);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void OnCancel()
        {
            Console.WriteLine("OnCancel");
            _tv.Text = "OnCancel";
        }

        public void OnComplete(Java.Lang.Object p0)
        {
            Console.WriteLine(p0.ToString());
            _tv.Text = p0.ToString();

            switch (_loginType)
            {
                case LoginType.Login:
                    try
                    {
                        var json1 = new JSONObject(p0.ToString());
                        var openid = json1.GetString("openid");
                        var token = json1.GetString("access_token");
                        var time = json1.GetString("expires_in");
                        _tencent.OpenId = openid;
                        _tencent.SetAccessToken(token, time);
                    }
                    catch(JSONException e)
                    {
                        e.PrintStackTrace();
                    }
                    
                    var userInfo = new UserInfo(this, _tencent.QQToken);
                    _loginType = LoginType.UserInfo;
                    userInfo.GetUserInfo(this);
                    break;
                case LoginType.UserInfo:
                    var json2 = new JSONObject(p0.ToString());
                    break;
                case LoginType.None:
                default:
                    break;
            }
        }

        public void OnError(UiError p0)
        {
            Console.WriteLine(p0.ToString());
            _tv.Text = "OnError: " + p0.ToString();
        }
    }

    public enum LoginType
    {
        None,
        Login,
        UserInfo
    }
}

