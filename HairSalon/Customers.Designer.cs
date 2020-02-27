namespace HairSalon
{
    partial class Customers
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
            this.lvwCustomers = new System.Windows.Forms.ListView();
            this.colID = new System.Windows.Forms.ColumnHeader();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPicture = new System.Windows.Forms.Button();
            this.pbxCustomer = new System.Windows.Forms.PictureBox();
            this.btnStateLookup = new System.Windows.Forms.Button();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxStates = new System.Windows.Forms.ComboBox();
            this.txtZipCode = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPicturePath = new System.Windows.Forms.Label();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.btnFriendlyPrint = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // lvwCustomers
            // 
            this.lvwCustomers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colName,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvwCustomers.FullRowSelect = true;
            this.lvwCustomers.GridLines = true;
            this.lvwCustomers.Location = new System.Drawing.Point(12, 12);
            this.lvwCustomers.Name = "lvwCustomers";
            this.lvwCustomers.Size = new System.Drawing.Size(616, 175);
            this.lvwCustomers.TabIndex = 0;
            this.lvwCustomers.UseCompatibleStateImageBehavior = false;
            this.lvwCustomers.View = System.Windows.Forms.View.Details;
            this.lvwCustomers.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvwCustomers_ItemSelectionChanged);
            // 
            // colID
            // 
            this.colID.Text = "ID";
            this.colID.Width = 30;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 100;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Phone";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "E-mail";
            this.columnHeader2.Width = 110;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Street";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "City";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "State";
            this.columnHeader5.Width = 40;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Zip";
            this.columnHeader6.Width = 50;
            // 
            // btnClose
            // 
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(499, 252);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 31;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFriendlyPrint);
            this.groupBox1.Controls.Add(this.btnPicture);
            this.groupBox1.Controls.Add(this.pbxCustomer);
            this.groupBox1.Controls.Add(this.btnStateLookup);
            this.groupBox1.Controls.Add(this.lblCustomerID);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbxStates);
            this.groupBox1.Controls.Add(this.txtZipCode);
            this.groupBox1.Controls.Add(this.txtCity);
            this.groupBox1.Controls.Add(this.txtStreet);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.txtTelephone);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 202);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(616, 290);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Details";
            // 
            // btnPicture
            // 
            this.btnPicture.Location = new System.Drawing.Point(376, 202);
            this.btnPicture.Name = "btnPicture";
            this.btnPicture.Size = new System.Drawing.Size(198, 23);
            this.btnPicture.TabIndex = 42;
            this.btnPicture.Text = "Select Customer Picture...";
            this.btnPicture.UseVisualStyleBackColor = true;
            this.btnPicture.Click += new System.EventHandler(this.btnPicture_Click);
            // 
            // pbxCustomer
            // 
            this.pbxCustomer.Location = new System.Drawing.Point(376, 19);
            this.pbxCustomer.Name = "pbxCustomer";
            this.pbxCustomer.Size = new System.Drawing.Size(198, 177);
            this.pbxCustomer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxCustomer.TabIndex = 41;
            this.pbxCustomer.TabStop = false;
            // 
            // btnStateLookup
            // 
            this.btnStateLookup.Location = new System.Drawing.Point(297, 252);
            this.btnStateLookup.Name = "btnStateLookup";
            this.btnStateLookup.Size = new System.Drawing.Size(87, 23);
            this.btnStateLookup.TabIndex = 40;
            this.btnStateLookup.Text = "State Lookup";
            this.btnStateLookup.UseVisualStyleBackColor = true;
            this.btnStateLookup.Click += new System.EventHandler(this.btnStateLookup_Click);
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblCustomerID.Location = new System.Drawing.Point(76, 212);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(72, 13);
            this.lblCustomerID.TabIndex = 39;
            this.lblCustomerID.Text = "lblCustomerID";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(160, 252);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(131, 23);
            this.btnReset.TabIndex = 29;
            this.btnReset.Text = "Add New Customer..";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(79, 252);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(184, 166);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Zip Code:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "State:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "City:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Street:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Email:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Telephone:";
            // 
            // cbxStates
            // 
            this.cbxStates.FormattingEnabled = true;
            this.cbxStates.Items.AddRange(new object[] {
            "AL ",
            "AK ",
            "AZ ",
            "AR ",
            "CA ",
            "CO ",
            "CL",
            "DE ",
            "DC ",
            "FL ",
            "GA ",
            "HI ",
            "ID ",
            "IL ",
            "IN ",
            "IA ",
            "KS ",
            "KY ",
            "LA ",
            "ME ",
            "MD ",
            "MA ",
            "MI ",
            "MN ",
            "MS ",
            "MO ",
            "MT ",
            "NE",
            "NV ",
            "NH ",
            "NJ",
            "NM ",
            "NY ",
            "NC ",
            "ND ",
            "OH ",
            "OK ",
            "OR ",
            "PA ",
            "RI ",
            "SC ",
            "SD ",
            "TN ",
            "TX ",
            "UT ",
            "VT ",
            "VA ",
            "WA ",
            "WV ",
            "WI ",
            "WY"});
            this.cbxStates.Location = new System.Drawing.Point(106, 163);
            this.cbxStates.Name = "cbxStates";
            this.cbxStates.Size = new System.Drawing.Size(47, 21);
            this.cbxStates.TabIndex = 25;
            // 
            // txtZipCode
            // 
            this.txtZipCode.Location = new System.Drawing.Point(243, 163);
            this.txtZipCode.MaxLength = 5;
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Size = new System.Drawing.Size(75, 20);
            this.txtZipCode.TabIndex = 26;
            this.txtZipCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(106, 137);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(212, 20);
            this.txtCity.TabIndex = 24;
            // 
            // txtStreet
            // 
            this.txtStreet.Location = new System.Drawing.Point(106, 111);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(212, 20);
            this.txtStreet.TabIndex = 23;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(106, 85);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(212, 20);
            this.txtEmail.TabIndex = 22;
            // 
            // txtTelephone
            // 
            this.txtTelephone.Location = new System.Drawing.Point(106, 59);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(212, 20);
            this.txtTelephone.TabIndex = 21;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(106, 33);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(212, 20);
            this.txtName.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Name:";
            // 
            // lblPicturePath
            // 
            this.lblPicturePath.AutoSize = true;
            this.lblPicturePath.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblPicturePath.Location = new System.Drawing.Point(12, 496);
            this.lblPicturePath.Name = "lblPicturePath";
            this.lblPicturePath.Size = new System.Drawing.Size(21, 13);
            this.lblPicturePath.TabIndex = 37;
            this.lblPicturePath.Text = "pic";
            // 
            // btnFriendlyPrint
            // 
            this.btnFriendlyPrint.Location = new System.Drawing.Point(391, 251);
            this.btnFriendlyPrint.Name = "btnFriendlyPrint";
            this.btnFriendlyPrint.Size = new System.Drawing.Size(75, 23);
            this.btnFriendlyPrint.TabIndex = 43;
            this.btnFriendlyPrint.Text = "Friendly Print";
            this.btnFriendlyPrint.UseVisualStyleBackColor = true;
            this.btnFriendlyPrint.Click += new System.EventHandler(this.btnFriendlyPrint_Click);
            // 
            // Customers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 518);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lvwCustomers);
            this.Controls.Add(this.lblPicturePath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Customers";
            this.ShowInTaskbar = false;
            this.Text = "Customers";
            this.Load += new System.EventHandler(this.Customers_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCustomer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwCustomers;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label lblPicturePath;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cbxStates;
        public System.Windows.Forms.TextBox txtZipCode;
        public System.Windows.Forms.TextBox txtCity;
        public System.Windows.Forms.TextBox txtStreet;
        public System.Windows.Forms.TextBox txtEmail;
        public System.Windows.Forms.TextBox txtTelephone;
        public System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.Label lblCustomerID;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button btnStateLookup;
        private System.Windows.Forms.Button btnPicture;
        private System.Windows.Forms.PictureBox pbxCustomer;
        private System.Windows.Forms.Button btnFriendlyPrint;
    }
}