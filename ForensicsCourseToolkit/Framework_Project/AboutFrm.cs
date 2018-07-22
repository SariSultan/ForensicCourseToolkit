using System.Windows.Forms;

namespace ForensicsCourseToolkit
{
    public partial class AboutFrm : Form
    {
        public AboutFrm()
        {
            InitializeComponent();
            versionLbl.Text = $"v{Application.ProductVersion}";
        }
    }
}