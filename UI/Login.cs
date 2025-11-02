using EZBank.Classes;
using EZBank.Helpers;
using EZBank.Interfaces;
using System;
using System.Windows.Forms;

namespace EZBank
{
    public partial class Login : Form
    {

        IDBServerConnection _serverConnection;

        public IDBServerConnection GetDBServerConnection()
        {
            return _serverConnection;
        }


        public Login()
        {
            InitializeComponent();
            txtServer.Text = Properties.Settings.Default.Servername; 
            txtUser.Text = Properties.Settings.Default.Username;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Session session = new Session(txtServer.Text, txtUser.Text, txtPassword.Text);
            IDBServerConnection ServerConnection = new MSSQLServerConnectionFactory().CreateConnection(); //Check IDBServerConnection for Documentation on the Interface
            if (!ServerConnection.ValidateConnection(session))
            {
                MessageBox.Show("Login Failed.");
                return;
            }
            _serverConnection = ServerConnection;
            this.DialogResult = DialogResult.OK;

            //Small QOL Improvement
            Properties.Settings.Default.Servername = txtServer.Text;
            Properties.Settings.Default.Username = txtUser.Text;
            Properties.Settings.Default.Save();
            this.Close();
        }
    
    }
}
