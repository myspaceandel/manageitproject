using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDropBox
{
    public partial class AuthenticationApplication : Form
    {
        DropBox f;
        public AuthenticationApplication(DropBox f)
        {
            InitializeComponent();
            this.f = f;
        }

        private void SignIn_Click(object sender, EventArgs e)
        {
            f.login = login.Text;
            f.password = password.Text;
            this.Close();
        }

        private void Registry_Click(object sender, EventArgs e)
        {
            RegistryApplication registryApp = new RegistryApplication();
            registryApp.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f.isExit = true;
            Application.Exit();
        }
    }
}
