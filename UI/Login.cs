using EZBank.Classes;
using EZBank.Helpers;
using EZBank.Interfaces;
using System;
using System.Windows.Forms;

namespace EZBank
{
    public partial class Login : Form
    {

        //This class lets a user provide Data for accessing the DB
        //If the data is correct, this class will create the server connection and return to its caller.

        public IDBServerConnection ServerConnection;
        public Login()
        {
            InitializeComponent();

            //Maybe we have some saved details from last session
            txtServer.Text = Properties.Settings.Default.Servername; 
            txtUser.Text = Properties.Settings.Default.Username;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Nevermind
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Session session = new Session(txtServer.Text, txtUser.Text, txtPassword.Text);

            //Check IDBServerConnection for Documentation on the Interface
            IDBServerConnection ServerConnection = new MSSQLServerConnectionFactory().CreateConnection(); 
            if (!ServerConnection.ValidateConnection(session))
            {
                MessageBox.Show("Login Failed.");
                return;
            }
            this.ServerConnection = ServerConnection;
            this.DialogResult = DialogResult.OK;

            //Lets save the login details for next time
            Properties.Settings.Default.Servername = txtServer.Text;
            Properties.Settings.Default.Username = txtUser.Text;
            Properties.Settings.Default.Save();
            this.Close();
        }
    
    }
}
