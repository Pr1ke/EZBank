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
        public Transaction Transaction { get; set; }
        public CreateTransaction(DataTable transactionType)
        {
            InitializeComponent();
            cbTransactionType.DataSource = transactionType;
            cbTransactionType.DisplayMember = "TransactionType";
            cbTransactionType.ValueMember = "TransactionTypeId";
            cbTransactionType.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Transaction = new Transaction(
                date: dtpTransactionDate.Value,
                amount: decimal.Parse(txtTransactionAmount.Text),
                purpose: txtPurpose.Text,
                iban: txtIBAN.Text,
                typeId: (int)cbTransactionType.SelectedValue);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
