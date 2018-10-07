using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessManager
{
    public partial class ManageFile : Form
    {
        public ManageFile(string FullName)
        {
            InitializeComponent();
            textBox1.Text = FullName;
            this.FullName = FullName;
        }
        string FullName;
        private void button1_Click(object sender, EventArgs e)
        {
            string a = "";
            bool deleted = false;
            try
            {
                File.Delete(FullName);
                deleted = true;
            }
            catch
            {
                try
                {
                    Proc.KillByFile(FullName, out a);
                    File.Delete(FullName);
                    deleted = true;
                }
                catch { }
            }
            if(deleted)
            MessageBox.Show("deleted");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string a = "";
            string newName = FullName.Split('\\')[FullName.Split('\\').Length - 1];
            try
            {
                File.Copy(FullName, newName);
                MessageBox.Show("copied");
                this.Close();
            }
            catch { MessageBox.Show("File was deleted"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }
    }
}
