namespace EZBank
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpMain = new System.Windows.Forms.GroupBox();
            this.grpTransactions = new System.Windows.Forms.GroupBox();
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.grpAccounts = new System.Windows.Forms.GroupBox();
            this.dgvAccounts = new System.Windows.Forms.DataGridView();
            this.grpCustomers = new System.Windows.Forms.GroupBox();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLinkAccount = new System.Windows.Forms.Button();
            this.grpMain.SuspendLayout();
            this.grpTransactions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.grpAccounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).BeginInit();
            this.grpCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.grpTransactions);
            this.grpMain.Controls.Add(this.grpAccounts);
            this.grpMain.Controls.Add(this.grpCustomers);
            this.grpMain.Location = new System.Drawing.Point(13, 13);
            this.grpMain.Name = "grpMain";
            this.grpMain.Size = new System.Drawing.Size(875, 750);
            this.grpMain.TabIndex = 0;
            this.grpMain.TabStop = false;
            // 
            // grpTransactions
            // 
            this.grpTransactions.Controls.Add(this.dgvTransactions);
            this.grpTransactions.Location = new System.Drawing.Point(10, 526);
            this.grpTransactions.Name = "grpTransactions";
            this.grpTransactions.Size = new System.Drawing.Size(865, 224);
            this.grpTransactions.TabIndex = 2;
            this.grpTransactions.TabStop = false;
            this.grpTransactions.Text = "Transactions";
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransactions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTransactions.Location = new System.Drawing.Point(3, 16);
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.Size = new System.Drawing.Size(859, 205);
            this.dgvTransactions.TabIndex = 0;
            // 
            // grpAccounts
            // 
            this.grpAccounts.Controls.Add(this.dgvAccounts);
            this.grpAccounts.Location = new System.Drawing.Point(10, 286);
            this.grpAccounts.Name = "grpAccounts";
            this.grpAccounts.Size = new System.Drawing.Size(865, 234);
            this.grpAccounts.TabIndex = 1;
            this.grpAccounts.TabStop = false;
            this.grpAccounts.Text = "Accounts";
            // 
            // dgvAccounts
            // 
            this.dgvAccounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAccounts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAccounts.Location = new System.Drawing.Point(3, 16);
            this.dgvAccounts.Name = "dgvAccounts";
            this.dgvAccounts.Size = new System.Drawing.Size(859, 215);
            this.dgvAccounts.TabIndex = 0;
            // 
            // grpCustomers
            // 
            this.grpCustomers.Controls.Add(this.dgvCustomers);
            this.grpCustomers.Location = new System.Drawing.Point(13, 19);
            this.grpCustomers.Name = "grpCustomers";
            this.grpCustomers.Size = new System.Drawing.Size(862, 260);
            this.grpCustomers.TabIndex = 0;
            this.grpCustomers.TabStop = false;
            this.grpCustomers.Text = "Customers";
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomers.Location = new System.Drawing.Point(3, 16);
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.Size = new System.Drawing.Size(856, 241);
            this.dgvCustomers.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(894, 48);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(154, 53);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLinkAccount
            // 
            this.btnLinkAccount.Location = new System.Drawing.Point(894, 315);
            this.btnLinkAccount.Name = "btnLinkAccount";
            this.btnLinkAccount.Size = new System.Drawing.Size(154, 53);
            this.btnLinkAccount.TabIndex = 2;
            this.btnLinkAccount.Text = "Link Account";
            this.btnLinkAccount.UseVisualStyleBackColor = true;
            this.btnLinkAccount.Click += new System.EventHandler(this.btnLinkAccount_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 779);
            this.Controls.Add(this.btnLinkAccount);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpMain);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.grpMain.ResumeLayout(false);
            this.grpTransactions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.grpAccounts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).EndInit();
            this.grpCustomers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMain;
        private System.Windows.Forms.GroupBox grpTransactions;
        private System.Windows.Forms.GroupBox grpAccounts;
        private System.Windows.Forms.DataGridView dgvAccounts;
        private System.Windows.Forms.GroupBox grpCustomers;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.Button btnLinkAccount;
    }
}

