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

        private void btnSave_Click(object sender, EventArgs e)
        {
            _serverConnection.UpdateCustomerData(_customerDataTable);
            _serverConnection.UpdateAccountData(_accountDataTable);
            _serverConnection.UpdateTransactionData(_transactionDataTable);
            LoadData();
        }
    }
}
