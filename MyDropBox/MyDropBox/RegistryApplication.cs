using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyDropBox.ServiceReference1;

namespace MyDropBox
{
    public partial class RegistryApplication : Form
    {
        public RegistryApplication()
        {
            InitializeComponent();
        }

        private void registry_Click(object sender, EventArgs e)
        {
            if (password.Text.Equals(passwordConfirm.Text))
            {
                IRegistryContract service = new RegistryContractClient();
                Client client = new Client();
                client.name = name.Text;
                client.surname = surname.Text;
                client.login = login.Text;
                client.password = password.Text;
                client.birthDate = birthDate.Value.Date;

                string rezult = service.Registry(client);
                MessageBox.Show(rezult);
                if (rezult.Equals("You have successfully registered"))
                    this.Close();

            }
            else
            {
                MessageBox.Show("passwords don't match");
            }

        }
    }
}
