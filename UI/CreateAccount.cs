using EZBank.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EZBank.UI
{
    public partial class CreateAccount : Form
    {

        //This class lets a user provide Data for creating new accounts
        //creation needs to be handled in the caller - this class only collects data and sends it back

        public Account Acc { get; set; }
        public CreateAccount(int customerId = -1)
        {
            InitializeComponent();

            //We dont necessarily need a customerId to create a account but if one is supplied well use it here
            if (customerId != -1)
            {
                txtCustomerId.Text = customerId.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Validate user input
            if (!int.TryParse(txtCustomerId.Text, out int customerId))
                customerId = -1;

            if (!int.TryParse(txtAccountId.Text, out int accountId))
                return;

            if (!decimal.TryParse(txtStartingBalance.Text, out decimal startingBalance))
                startingBalance = 0;

            
            //Create Account object for data transfer
            Account acc = new Account(
                accountId: accountId,
                startingBalance: startingBalance,
                iban: txtIBAN.Text,
                customerID: customerId
                );

            Acc = acc;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Nevermind
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
