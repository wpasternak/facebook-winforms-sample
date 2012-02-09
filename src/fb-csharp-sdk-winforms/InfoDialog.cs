
namespace fb_csharp_sdk_winforms
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Facebook;

    public partial class InfoDialog : Form
    {
        private readonly TaskScheduler _ui;
        private readonly string _accessToken;

        public InfoDialog(string accessToken)
        {
            _accessToken = accessToken;
            _ui = TaskScheduler.FromCurrentSynchronizationContext();
            InitializeComponent();
        }

        private void InfoDialog_Load(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var fb = new FacebookClient();

            var logoutUrl = fb.GetLogoutUrl(new
                                                {
                                                    next = "https://www.facebook.com/connect/login_success.html",
                                                    access_token = _accessToken
                                                });
            var webBrowser = new WebBrowser();
            webBrowser.Navigated += (o, args) =>
                                        {
                                            if (args.Url.AbsoluteUri == "https://www.facebook.com/connect/login_success.html")
                                                Close();
                                        };

            webBrowser.Navigate(logoutUrl.AbsoluteUri);
        }

    }
}
