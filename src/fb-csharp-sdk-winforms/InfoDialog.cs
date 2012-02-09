
namespace fb_csharp_sdk_winforms
{
    using System.Threading.Tasks;
    using System.Windows.Forms;

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

        private void InfoDialog_Load(object sender, System.EventArgs e)
        {

        }

    }
}
