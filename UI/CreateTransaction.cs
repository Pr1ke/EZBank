using EZBank.Classes;
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
    public partial class CreateTransaction : Form
    {
        //This class lets a user provide Data for creating new transactions
        //creation needs to be handled in the caller - this class only collects data and sends it back

        public Transaction Transaction { get; set; }
        public CreateTransaction(DataTable transactionType)
        {
            InitializeComponent();

            //Lets load the transcation types and show them in a user friendly manner,
            //So "Deposit" instead of "0"
            cbTransactionType.DataSource = transactionType;
            cbTransactionType.DisplayMember = "TransactionType";
            cbTransactionType.ValueMember = "TransactionTypeId";
            cbTransactionType.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Lets create the transaction object and send it back

            Transaction = new Transaction(
                date: dtpTransactionDate.Value,
                amount: decimal.Parse(txtTransactionAmount.Text),
                purpose: txtPurpose.Text,
                iban: txtIBAN.Text,
                typeId: (int)cbTransactionType.SelectedValue);

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
