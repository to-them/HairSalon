namespace HairSalon
{
    partial class Reports
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
            this.lvwReports = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.lblTotalTaxAmt = new System.Windows.Forms.Label();
            this.lblTotalAmtPaid = new System.Windows.Forms.Label();
            this.lblTotalBalance = new System.Windows.Forms.Label();
            this.btnFriendlyPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvwReports
            // 
            this.lvwReports.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lvwReports.GridLines = true;
            this.lvwReports.Location = new System.Drawing.Point(12, 12);
            this.lvwReports.Name = "lvwReports";
            this.lvwReports.Size = new System.Drawing.Size(637, 344);
            this.lvwReports.TabIndex = 0;
            this.lvwReports.UseCompatibleStateImageBehavior = false;
            this.lvwReports.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Receipt #";
            this.columnHeader1.Width = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Date";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Customer";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "style";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Price";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Tax Amt";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Amt Paid";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Balance";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(593, 405);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(56, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(246, 371);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Total Year-to-Date:";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Location = new System.Drawing.Point(392, 371);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(28, 13);
            this.lblTotalPrice.TabIndex = 3;
            this.lblTotalPrice.Text = "0.00";
            // 
            // lblTotalTaxAmt
            // 
            this.lblTotalTaxAmt.AutoSize = true;
            this.lblTotalTaxAmt.Location = new System.Drawing.Point(452, 371);
            this.lblTotalTaxAmt.Name = "lblTotalTaxAmt";
            this.lblTotalTaxAmt.Size = new System.Drawing.Size(28, 13);
            this.lblTotalTaxAmt.TabIndex = 4;
            this.lblTotalTaxAmt.Text = "0.00";
            // 
            // lblTotalAmtPaid
            // 
            this.lblTotalAmtPaid.AutoSize = true;
            this.lblTotalAmtPaid.Location = new System.Drawing.Point(516, 371);
            this.lblTotalAmtPaid.Name = "lblTotalAmtPaid";
            this.lblTotalAmtPaid.Size = new System.Drawing.Size(28, 13);
            this.lblTotalAmtPaid.TabIndex = 5;
            this.lblTotalAmtPaid.Text = "0.00";
            // 
            // lblTotalBalance
            // 
            this.lblTotalBalance.AutoSize = true;
            this.lblTotalBalance.Location = new System.Drawing.Point(575, 371);
            this.lblTotalBalance.Name = "lblTotalBalance";
            this.lblTotalBalance.Size = new System.Drawing.Size(28, 13);
            this.lblTotalBalance.TabIndex = 6;
            this.lblTotalBalance.Text = "0.00";
            // 
            // btnFriendlyPrint
            // 
            this.btnFriendlyPrint.Location = new System.Drawing.Point(512, 405);
            this.btnFriendlyPrint.Name = "btnFriendlyPrint";
            this.btnFriendlyPrint.Size = new System.Drawing.Size(75, 23);
            this.btnFriendlyPrint.TabIndex = 7;
            this.btnFriendlyPrint.Text = "Friendly Print";
            this.btnFriendlyPrint.UseVisualStyleBackColor = true;
            this.btnFriendlyPrint.Click += new System.EventHandler(this.btnFriendlyPrint_Click);
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 440);
            this.Controls.Add(this.btnFriendlyPrint);
            this.Controls.Add(this.lblTotalBalance);
            this.Controls.Add(this.lblTotalAmtPaid);
            this.Controls.Add(this.lblTotalTaxAmt);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lvwReports);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Reports";
            this.ShowInTaskbar = false;
            this.Text = "Receipts";
            this.Load += new System.EventHandler(this.Reports_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwReports;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label lblTotalTaxAmt;
        private System.Windows.Forms.Label lblTotalAmtPaid;
        private System.Windows.Forms.Label lblTotalBalance;
        private System.Windows.Forms.Button btnFriendlyPrint;
    }
}