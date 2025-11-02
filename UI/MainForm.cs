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
    public partial class MainForm : Form
    {
        private IDBServerConnection _serverConnection;
        DataTable _customerDataTable = new DataTable();
        DataTable _accountDataTable = new DataTable();
        DataTable _transactionDataTable = new DataTable();

        public MainForm()
        {
            using (var loginForm = new Login())
            {
                var result = loginForm.ShowDialog();
                if (result != DialogResult.OK)
                {
                    return;
                }
                _serverConnection = loginForm.GetDBServerConnection();
            }

            InitializeComponent();
            dgvCustomers.DataSource = _customerDataTable;
            dgvAccounts.DataSource = _accountDataTable;
            dgvTransactions.DataSource = _transactionDataTable;          
            LoadData();
        }

        private void LoadData()
        {
            //Clear the Datatables and refill them from DB because we have Autoincrement Keys which would otherwise not be Updated
            _customerDataTable.Clear();
            _accountDataTable.Clear();
            _transactionDataTable.Clear();

            _serverConnection.FillCustomerData(_customerDataTable);
            _serverConnection.FillAccountData(_accountDataTable);
            _serverConnection.FillTransactionData(_transactionDataTable);
        }

        private void SaveData()
        {
            _serverConnection.UpdateCustomerData(_customerDataTable);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
            LoadData();
        }

        private void btnLinkAccount_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null || dgvAccounts.CurrentRow == null)
                return;

            if (!int.TryParse(dgvCustomers.CurrentRow.Cells["CustomerId"].Value?.ToString(), out int customerId))
                return;

            if (!int.TryParse(dgvAccounts.CurrentRow.Cells["AccountId"].Value?.ToString(), out int accountId))
                return;

            if (!int.TryParse(dgvAccounts.CurrentRow.Cells["CustomerId"].Value?.ToString(), out int previousCustomerId))
                accountId = 0;

            if (previousCustomerId == customerId)
                return;

            if (previousCustomerId != 0)
            {
                DialogResult dialogResult = MessageBox.Show("This Account is currently linked to Customer " + previousCustomerId + ", do you want to Link it to Customer " + customerId + "?", "Link Customer", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }

            _serverConnection.LinkAccount(accountId, customerId);
            dgvAccounts.Refresh();

        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(dgvAccounts.CurrentRow.Cells["AccountId"].Value?.ToString(), out int accountId))
                return;

            DataTable transactionTypeDataTable = new DataTable();
            _serverConnection.FillTransactionTypeData(transactionTypeDataTable);
            using (CreateTransaction transactionForm = new CreateTransaction(transactionTypeDataTable))
            {
                var result = transactionForm.ShowDialog();
                if (result != DialogResult.OK)
                {
                    return;
                }
                Transaction transaction = transactionForm.Transaction;
                transaction.AccountID = accountId;
                _serverConnection.CreateTransaction(transactionForm.Transaction);
                _serverConnection.FillTransactionData(_transactionDataTable);
            }


        }

        private void btnDeleteTransaction_Click(object sender, EventArgs e)
        {
            if (dgvTransactions.CurrentRow == null)
                return;

            if (!int.TryParse(dgvTransactions.CurrentRow.Cells["TransactionId"].Value?.ToString(), out int transactionId))
                return;

            _serverConnection.DeleteTransaction(transactionId);
            _serverConnection.FillTransactionData(_transactionDataTable);

        }

        private void btnAccountcreate_Click(object sender, EventArgs e)
        {

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
                _serverConnection.FillAccountData(_accountDataTable);
            }
        }
    }
}
