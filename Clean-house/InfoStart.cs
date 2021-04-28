using System.Windows.Forms;

namespace Clean_house
{
    public partial class InfoStart : Form
    {
        public InfoStart()
        {
            InitializeComponent();
        }

        private void GoMainFormButton_Click(object sender, System.EventArgs e)
        {
            Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void QuitButton_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }
    }
}
