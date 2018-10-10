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
    public partial class PasswordConfirm : Form
    {
        private void SetColors(BackColorTheme theme)
        {
            if (theme == BackColorTheme.DARK)
            {
                this.BackColor = Color.FromArgb(15, 15, 15);
                textBox1.BackColor = BackColor;
                textBox1.ForeColor = Color.FromArgb(255, 255, 255);
                button1.BackColor = textBox1.BackColor;
                button1.ForeColor = Color.FromArgb(255, 255, 255);
                label1.ForeColor = Color.FromArgb(255, 255, 255); 
            }
            //dont need else 
        }
        public PasswordConfirm(BackColorTheme theme)
        {
            InitializeComponent();
            SetColors(theme);
        }
        public bool PasswordEntered = false;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (((((((textBox1.Text != "")))))))
            {
                Form1.passworld = textBox1.Text;
                PasswordEntered = true;
                this.Close();
            }
            else
                MessageBox.Show("Password is not correct");
        }
    }
}
