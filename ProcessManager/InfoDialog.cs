using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessManager
{
    public partial class InfoDialog : Form
    {
        private void SetBackColor(BackColorTheme theme)
        {
            if (theme == BackColorTheme.DARK)
            {
                this.BackColor = Color.FromArgb(17, 17, 17);
                text.ForeColor = Color.FromArgb(255,255,255);
                btn_ok.ForeColor = Color.FromArgb(255,255,255);
                btn_ok.BackColor = Color.FromArgb(17, 17, 17);
                btn_showAll.ForeColor = btn_ok.ForeColor;
                btn_showAll.BackColor = btn_ok.BackColor;
            }
            else if (theme == BackColorTheme.LIGHT)
            {
                this.BackColor = Color.FromArgb(255, 255, 255);
            }
        }

        public InfoDialog(string text, BackColorTheme theme)
        {
            InitializeComponent();
            this.text.Text = text;
            SetBackColor(theme);
        }

        public InfoDialog(string text, string caption, BackColorTheme theme)
        {
            InitializeComponent();
            this.text.Text = text;
            this.Text = caption;
            SetBackColor(theme);
        }

        private void Ok_click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void InfoDialog_Load(object sender, EventArgs e)
        {
            //this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void btn_showAll_Click(object sender, EventArgs e)
        {
            MessageBox.Show(text.Text);
        }
    }
}
