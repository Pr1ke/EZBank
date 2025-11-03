namespace EZBank.UI
{
    partial class CreateAccount
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblPurpose = new System.Windows.Forms.Label();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.txtIBAN = new System.Windows.Forms.TextBox();
            this.lblIBAN = new System.Windows.Forms.Label();
            this.lblStartingBalance = new System.Windows.Forms.Label();
            this.txtStartingBalance = new System.Windows.Forms.TextBox();
            this.lblAccountId = new System.Windows.Forms.Label();
            this.txtAccountId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(11, 221);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(217, 47);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(11, 168);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(217, 47);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblPurpose
            // 
            this.lblPurpose.AutoSize = true;
            this.lblPurpose.Location = new System.Drawing.Point(12, 87);
            this.lblPurpose.Name = "lblPurpose";
            this.lblPurpose.Size = new System.Drawing.Size(62, 13);
            this.lblPurpose.TabIndex = 17;
            this.lblPurpose.Text = "CustomerID";
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Location = new System.Drawing.Point(11, 103);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.Size = new System.Drawing.Size(217, 20);
            this.txtCustomerId.TabIndex = 16;
            // 
            // txtIBAN
            // 
            this.txtIBAN.Location = new System.Drawing.Point(11, 64);
            this.txtIBAN.Name = "txtIBAN";
            this.txtIBAN.Size = new System.Drawing.Size(217, 20);
            this.txtIBAN.TabIndex = 15;
            // 
            // lblIBAN
            // 
            this.lblIBAN.AutoSize = true;
            this.lblIBAN.Location = new System.Drawing.Point(12, 48);
            this.lblIBAN.Name = "lblIBAN";
            this.lblIBAN.Size = new System.Drawing.Size(32, 13);
            this.lblIBAN.TabIndex = 13;
            this.lblIBAN.Text = "IBAN";
            // 
            // lblStartingBalance
            // 
            this.lblStartingBalance.AutoSize = true;
            this.lblStartingBalance.Location = new System.Drawing.Point(12, 126);
            this.lblStartingBalance.Name = "lblStartingBalance";
            this.lblStartingBalance.Size = new System.Drawing.Size(84, 13);
            this.lblStartingBalance.TabIndex = 24;
            this.lblStartingBalance.Text = "Starting balance";
            // 
            // txtStartingBalance
            // 
            this.txtStartingBalance.Location = new System.Drawing.Point(11, 142);
            this.txtStartingBalance.Name = "txtStartingBalance";
            this.txtStartingBalance.Size = new System.Drawing.Size(217, 20);
            this.txtStartingBalance.TabIndex = 25;
            // 
            // lblAccountId
            // 
            this.lblAccountId.AutoSize = true;
            this.lblAccountId.Location = new System.Drawing.Point(12, 9);
            this.lblAccountId.Name = "lblAccountId";
            this.lblAccountId.Size = new System.Drawing.Size(56, 13);
            this.lblAccountId.TabIndex = 26;
            this.lblAccountId.Text = "AccountId";
            // 
            // txtAccountId
            // 
            this.txtAccountId.Location = new System.Drawing.Point(11, 25);
            this.txtAccountId.Name = "txtAccountId";
            this.txtAccountId.Size = new System.Drawing.Size(217, 20);
            this.txtAccountId.TabIndex = 27;
            // 
            // CreateAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 280);
            this.Controls.Add(this.txtAccountId);
            this.Controls.Add(this.lblAccountId);
            this.Controls.Add(this.txtStartingBalance);
            this.Controls.Add(this.lblStartingBalance);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblPurpose);
            this.Controls.Add(this.txtCustomerId);
            this.Controls.Add(this.txtIBAN);
            this.Controls.Add(this.lblIBAN);
            this.Name = "CreateAccount";
            this.Text = "CreateAccount";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblPurpose;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.TextBox txtIBAN;
        private System.Windows.Forms.Label lblIBAN;
        private System.Windows.Forms.Label lblStartingBalance;
        private System.Windows.Forms.TextBox txtStartingBalance;
        private System.Windows.Forms.Label lblAccountId;
        private System.Windows.Forms.TextBox txtAccountId;
    }
}