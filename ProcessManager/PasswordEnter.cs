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
    public partial class PasswordEnter : Form
    {
        private void SetColors(BackColorTheme theme)
        {
            if(theme == BackColorTheme.DARK)
            {
                this.BackColor = Color.FromArgb(15,15,15);
                textBox1.BackColor = BackColor;
                textBox2.BackColor = BackColor;
                textBox1.ForeColor = Color.FromArgb(255,255,255);
                textBox2.ForeColor = Color.FromArgb(255, 255, 255);
                button1.BackColor = textBox1.BackColor;
                button1.ForeColor = Color.FromArgb(255, 255, 255);
                label1.ForeColor = Color.FromArgb(255, 255, 255); 
                label2.ForeColor = Color.FromArgb(255, 255, 255);
            }
            //dont need else 
        }
        public PasswordEnter(BackColorTheme theme)
        {
            InitializeComponent();
            SetColors(theme);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == textBox2.Text) && (textBox1.Text != ""))
            {
                Form1.passworld = textBox1.Text;
                Form1.PassworldEntered = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Password is not correct");
                textBox2.Text = "";
                textBox1.Text = "";
                textBox1.Focus();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }
    }
}
