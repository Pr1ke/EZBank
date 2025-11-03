using EZBank.Classes;
using EZBank.Helpers;
using EZBank.Interfaces;
using EZBank.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EZBank
{

    //This Class contains the main UI for the EZBank Application

    public partial class MainForm : Form
    {
        private IDBServerConnection _serverConnection;
        DataTable _customerDataTable = new DataTable();
        DataTable _accountDataTable = new DataTable();
        DataTable _transactionDataTable = new DataTable();

        public MainForm()
        {
            //Lets the User provide the connection details
            using (var loginForm = new Login())
            {
                var result = loginForm.ShowDialog();
                if (result != DialogResult.OK)
                {
                    //We cant display any data without DB connection so well exit
                    Environment.Exit(0);
                }

                _serverConnection = loginForm.ServerConnection;
            }

            InitializeComponent();     
            LoadData();
        }

        private void LoadData()
        {
            //async Just-in-time loading would be better, but well just reload everything for now

            dgvCustomers.DataSource = null;
            dgvAccounts.DataSource = null;
            dgvTransactions.DataSource = null;

            //Clear the Datatables and refill them from DB because we have Autoincrement Keys which would otherwise not be Updated
            _customerDataTable.Clear();
            _accountDataTable.Clear();
            _transactionDataTable.Clear();

            _serverConnection.FillCustomerData(_customerDataTable);
            _serverConnection.FillAccountData(_accountDataTable);
            _serverConnection.FillTransactionData(_transactionDataTable);

            dgvCustomers.DataSource = _customerDataTable;
            dgvAccounts.DataSource = _accountDataTable;
            dgvTransactions.DataSource = _transactionDataTable;

            dgvAccounts.Refresh();
            dgvCustomers.Refresh();
            dgvTransactions.Refresh();

        }

        private void btnAdressSave_Click(object sender, EventArgs e)
        {
            _serverConnection.UpdateCustomerData(_customerDataTable);
            LoadData();
        }

        private void btnLinkAccount_Click(object sender, EventArgs e)
        {
            //Lets the User link or relink a account to a customer

            //Lets start with some validation first
            if (dgvCustomers.CurrentRow == null || dgvAccounts.CurrentRow == null)
                return;

            if (!int.TryParse(dgvCustomers.CurrentRow.Cells["CustomerId"].Value?.ToString(), out int customerId))
                return; 

            if (!int.TryParse(dgvAccounts.CurrentRow.Cells["AccountId"].Value?.ToString(), out int accountId))
                return;

            if (!int.TryParse(dgvAccounts.CurrentRow.Cells["CustomerId"].Value?.ToString(), out int previousCustomerId))
                accountId = 0;

            if (previousCustomerId == customerId)
                return;   //No change necessary

            //Ask Customer if they want to change an existing connection
            if (previousCustomerId != 0)
            {
                DialogResult dialogResult = MessageBox.Show("This Account is currently linked to Customer " + previousCustomerId + ", do you want to Link it to Customer " + customerId + "?", "Link Customer", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }

            //Perform the operation
            _serverConnection.LinkAccount(accountId, customerId);
            LoadData();
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            //This button lets the user create a new transaction

            if (!int.TryParse(dgvAccounts.CurrentRow.Cells["AccountId"].Value?.ToString(), out int accountId))
                return;

            //Get the transaction types from the DB to fill the dropdown selection
            DataTable transactionTypeDataTable = new DataTable();
            _serverConnection.FillTransactionTypeData(transactionTypeDataTable);

            //Ask User to define transaction details
            using (CreateTransaction transactionForm = new CreateTransaction(transactionTypeDataTable))
            {
                var result = transactionForm.ShowDialog();
                if (result != DialogResult.OK)
                {
                    return; //User canceled
                }


                Transaction transaction = transactionForm.Transaction;
                transaction.AccountID = accountId; //Link selected account to transaction
                _serverConnection.CreateTransaction(transactionForm.Transaction);
                LoadData();
            }


        }

        private void btnDeleteTransaction_Click(object sender, EventArgs e)
        {
            //This button lets the user "delete" a transaction
            //Deletion in this context means, the DeletedBy field gets filled with the current User
            //This causes the transaction to be not shown by default in the transaction DataGridView.

            //If someone made some nefarious transactions and deleted them,
            //the other users can still see the transactions once they enable the checkbox and find the culprit.

            if (dgvTransactions.CurrentRow == null)
                return;

            if (!int.TryParse(dgvTransactions.CurrentRow.Cells["TransactionId"].Value?.ToString(), out int transactionId))
                return;


            _serverConnection.DeleteTransaction(transactionId);
            LoadData();

        }

        private void btnAccountcreate_Click(object sender, EventArgs e)
        {
            
            //This button lets the User create a new Account

            if (!int.TryParse(dgvCustomers.CurrentRow.Cells["CustomerId"].Value?.ToString(), out int customerId))
                customerId = -1;

            using (CreateAccount accountForm = new CreateAccount(customerId))
            {
                var result = accountForm.ShowDialog();
                if (result != DialogResult.OK)
                {
                    return;
                }
                _serverConnection.CreateAccount(accountForm.Acc);
                decimal startingBalance = accountForm.Acc.StartingBalance;

                //If the account is supposed to already have a starting balance, well need to create a transaction for it.
                if (startingBalance != 0)
                {
                    Transaction openingBalanceTransaction = new Transaction(startingBalance);
                    openingBalanceTransaction.AccountID = accountForm.Acc.AccountId;
                    _serverConnection.CreateTransaction(openingBalanceTransaction);
                }

                LoadData();
            }
        }

        private void chkDeletedTransactions_CheckedChanged(object sender, EventArgs e)
        {
            _serverConnection.ShowDeletedTransactionChanged(chkDeletedTransactions.Checked);
            //The deletedBy Column gets shown only when the checkbox is enabled,
            //Thus we need to clear the DataTable to generate new Headers.
            _transactionDataTable = new DataTable();
            LoadData();
        }
    }
}
