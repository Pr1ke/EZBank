using EZBank.Interfaces;
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
            _serverConnection.UpdateAccountData(_accountDataTable);
            _serverConnection.UpdateTransactionData(_transactionDataTable);
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

            if (!int.TryParse(dgvAccounts.CurrentRow.Cells["CustomerId"].Value?.ToString(), out int previousCustomerId))
                previousCustomerId = 0;

            if (previousCustomerId == customerId)
                return;

            if (previousCustomerId != 0)
            {
                DialogResult dialogResult = MessageBox.Show("This Account is currently linked to Customer " + previousCustomerId + ", do you want to Link it to Customer " + customerId + "?", "Link Customer" ,MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }

            _accountDataTable.Rows[dgvAccounts.CurrentRow.Index]["CustomerId"] = customerId;
            _serverConnection.UpdateAccountData(_accountDataTable);
            dgvAccounts.Refresh();
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {

        }
    }
}
