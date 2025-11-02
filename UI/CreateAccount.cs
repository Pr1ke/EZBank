using EZBank.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EZBank.UI
{
    public partial class CreateAccount : Form
    {
        public Account Acc { get; set; }
        public CreateAccount(int customerId = -1)
        {
            InitializeComponent();
            if (customerId != -1)
            {
                txtCustomerId.Text = customerId.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCustomerId.Text, out int customerId))
                customerId = -1;

            if (!int.TryParse(txtAccountId.Text, out int accountId))
                return;

            if (!decimal.TryParse(txtStartingBalance.Text, out decimal startingBalance))
                startingBalance = 0;

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
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
