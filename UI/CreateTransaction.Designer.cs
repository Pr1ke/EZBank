namespace EZBank.UI
{
    partial class CreateTransaction
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
            this.dtpTransactionDate = new System.Windows.Forms.DateTimePicker();
            this.lblTransactionDate = new System.Windows.Forms.Label();
            this.lblTransactionAmount = new System.Windows.Forms.Label();
            this.txtTransactionAmount = new System.Windows.Forms.TextBox();
            this.txtPurpose = new System.Windows.Forms.TextBox();
            this.lblPurpose = new System.Windows.Forms.Label();
            this.lblIBAN = new System.Windows.Forms.Label();
            this.txtIBAN = new System.Windows.Forms.TextBox();
            this.lblTransactionType = new System.Windows.Forms.Label();
            this.cbTransactionType = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtpTransactionDate
            // 
            this.dtpTransactionDate.Location = new System.Drawing.Point(16, 33);
            this.dtpTransactionDate.Name = "dtpTransactionDate";
            this.dtpTransactionDate.Size = new System.Drawing.Size(217, 20);
            this.dtpTransactionDate.TabIndex = 0;
            // 
            // lblTransactionDate
            // 
            this.lblTransactionDate.AutoSize = true;
            this.lblTransactionDate.Location = new System.Drawing.Point(16, 13);
            this.lblTransactionDate.Name = "lblTransactionDate";
            this.lblTransactionDate.Size = new System.Drawing.Size(87, 13);
            this.lblTransactionDate.TabIndex = 1;
            this.lblTransactionDate.Text = "Transaction date";
            // 
            // lblTransactionAmount
            // 
            this.lblTransactionAmount.AutoSize = true;
            this.lblTransactionAmount.Location = new System.Drawing.Point(16, 56);
            this.lblTransactionAmount.Name = "lblTransactionAmount";
            this.lblTransactionAmount.Size = new System.Drawing.Size(101, 13);
            this.lblTransactionAmount.TabIndex = 2;
            this.lblTransactionAmount.Text = "Transaction amount";
            // 
            // txtTransactionAmount
            // 
            this.txtTransactionAmount.Location = new System.Drawing.Point(16, 73);
            this.txtTransactionAmount.Name = "txtTransactionAmount";
            this.txtTransactionAmount.Size = new System.Drawing.Size(217, 20);
            this.txtTransactionAmount.TabIndex = 3;
            // 
            // txtPurpose
            // 
            this.txtPurpose.Location = new System.Drawing.Point(16, 112);
            this.txtPurpose.Name = "txtPurpose";
            this.txtPurpose.Size = new System.Drawing.Size(217, 20);
            this.txtPurpose.TabIndex = 4;
            // 
            // lblPurpose
            // 
            this.lblPurpose.AutoSize = true;
            this.lblPurpose.Location = new System.Drawing.Point(16, 96);
            this.lblPurpose.Name = "lblPurpose";
            this.lblPurpose.Size = new System.Drawing.Size(46, 13);
            this.lblPurpose.TabIndex = 5;
            this.lblPurpose.Text = "Purpose";
            // 
            // lblIBAN
            // 
            this.lblIBAN.AutoSize = true;
            this.lblIBAN.Location = new System.Drawing.Point(16, 135);
            this.lblIBAN.Name = "lblIBAN";
            this.lblIBAN.Size = new System.Drawing.Size(32, 13);
            this.lblIBAN.TabIndex = 6;
            this.lblIBAN.Text = "IBAN";
            // 
            // txtIBAN
            // 
            this.txtIBAN.Location = new System.Drawing.Point(19, 151);
            this.txtIBAN.Name = "txtIBAN";
            this.txtIBAN.Size = new System.Drawing.Size(214, 20);
            this.txtIBAN.TabIndex = 7;
            // 
            // lblTransactionType
            // 
            this.lblTransactionType.AutoSize = true;
            this.lblTransactionType.Location = new System.Drawing.Point(16, 174);
            this.lblTransactionType.Name = "lblTransactionType";
            this.lblTransactionType.Size = new System.Drawing.Size(86, 13);
            this.lblTransactionType.TabIndex = 8;
            this.lblTransactionType.Text = "Transaction type";
            // 
            // cbTransactionType
            // 
            this.cbTransactionType.FormattingEnabled = true;
            this.cbTransactionType.Location = new System.Drawing.Point(19, 190);
            this.cbTransactionType.Name = "cbTransactionType";
            this.cbTransactionType.Size = new System.Drawing.Size(214, 21);
            this.cbTransactionType.TabIndex = 9;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(19, 217);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(214, 47);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(19, 270);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(214, 47);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // CreateTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 331);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbTransactionType);
            this.Controls.Add(this.lblTransactionType);
            this.Controls.Add(this.txtIBAN);
            this.Controls.Add(this.lblIBAN);
            this.Controls.Add(this.lblPurpose);
            this.Controls.Add(this.txtPurpose);
            this.Controls.Add(this.txtTransactionAmount);
            this.Controls.Add(this.lblTransactionAmount);
            this.Controls.Add(this.lblTransactionDate);
            this.Controls.Add(this.dtpTransactionDate);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateTransaction";
            this.ShowIcon = false;
            this.Text = "CreateTransaction";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpTransactionDate;
        private System.Windows.Forms.Label lblTransactionDate;
        private System.Windows.Forms.Label lblTransactionAmount;
        private System.Windows.Forms.TextBox txtTransactionAmount;
        private System.Windows.Forms.TextBox txtPurpose;
        private System.Windows.Forms.Label lblPurpose;
        private System.Windows.Forms.Label lblIBAN;
        private System.Windows.Forms.TextBox txtIBAN;
        private System.Windows.Forms.Label lblTransactionType;
        private System.Windows.Forms.ComboBox cbTransactionType;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}