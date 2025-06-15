using System;
using System.Drawing;
using System.Windows.Forms;

namespace HumanResorce
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.DeepSkyBlue;
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            // Không cần Timer nữa
        }
    }
}
