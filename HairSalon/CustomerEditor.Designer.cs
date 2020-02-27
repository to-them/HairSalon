namespace HairSalon
{
    partial class CustomerEditor
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtZipCode = new System.Windows.Forms.TextBox();
            this.cbxStates = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pbxCustomer = new System.Windows.Forms.PictureBox();
            this.btnPicture = new System.Windows.Forms.Button();
            this.lblPicturePath = new System.Windows.Forms.Label();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(79, 13);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(207, 20);
            this.txtName.TabIndex = 1;
            // 
            // txtTelephone
            // 
            this.txtTelephone.Location = new System.Drawing.Point(79, 39);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(207, 20);
            this.txtTelephone.TabIndex = 2;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(79, 65);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(207, 20);
            this.txtEmail.TabIndex = 3;
            // 
            // txtStreet
            // 
            this.txtStreet.Location = new System.Drawing.Point(79, 91);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(207, 20);
            this.txtStreet.TabIndex = 4;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(79, 117);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(207, 20);
            this.txtCity.TabIndex = 5;
            // 
            // txtZipCode
            // 
            this.txtZipCode.Location = new System.Drawing.Point(214, 143);
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Size = new System.Drawing.Size(72, 20);
            this.txtZipCode.TabIndex = 6;
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
            this.cbxStates.Location = new System.Drawing.Point(79, 142);
            this.cbxStates.Name = "cbxStates";
            this.cbxStates.Size = new System.Drawing.Size(57, 21);
            this.cbxStates.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Telephone:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Email:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Street:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "City:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "State:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(155, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Zip Code:";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(277, 205);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 14;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(358, 205);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // pbxCustomer
            // 
            this.pbxCustomer.Location = new System.Drawing.Point(292, 13);
            this.pbxCustomer.Name = "pbxCustomer";
            this.pbxCustomer.Size = new System.Drawing.Size(142, 124);
            this.pbxCustomer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxCustomer.TabIndex = 16;
            this.pbxCustomer.TabStop = false;
            // 
            // btnPicture
            // 
            this.btnPicture.Location = new System.Drawing.Point(292, 142);
            this.btnPicture.Name = "btnPicture";
            this.btnPicture.Size = new System.Drawing.Size(141, 23);
            this.btnPicture.TabIndex = 17;
            this.btnPicture.Text = "Select Customer Picture...";
            this.btnPicture.UseVisualStyleBackColor = true;
            this.btnPicture.Click += new System.EventHandler(this.btnPicture_Click);
            // 
            // lblPicturePath
            // 
            this.lblPicturePath.AutoSize = true;
            this.lblPicturePath.Location = new System.Drawing.Point(12, 183);
            this.lblPicturePath.Name = "lblPicturePath";
            this.lblPicturePath.Size = new System.Drawing.Size(65, 13);
            this.lblPicturePath.TabIndex = 18;
            this.lblPicturePath.Text = "Picture Path";
            // 
            // dlgOpenFile
            // 
            this.dlgOpenFile.DefaultExt = "jpg";
            this.dlgOpenFile.FileName = "openFileDialog1";
            this.dlgOpenFile.Filter = "JPEG Files (*.jpg,*.jpeg)|*.jpg|GIF Files (*.gif)|*.gif|Bitmap Files (*.bmp)|*.bm" +
                "p|PNG Files (*.png)|*.png";
            this.dlgOpenFile.Title = "Select Customer Picture...";
            // 
            // CustomerEditor
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(445, 240);
            this.Controls.Add(this.lblPicturePath);
            this.Controls.Add(this.btnPicture);
            this.Controls.Add(this.pbxCustomer);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxStates);
            this.Controls.Add(this.txtZipCode);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.txtStreet);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtTelephone);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerEditor";
            this.ShowInTaskbar = false;
            this.Text = "Customer Editor";
            ((System.ComponentModel.ISupportInitialize)(this.pbxCustomer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.TextBox txtTelephone;
        public System.Windows.Forms.TextBox txtEmail;
        public System.Windows.Forms.TextBox txtStreet;
        public System.Windows.Forms.TextBox txtCity;
        public System.Windows.Forms.ComboBox cbxStates;
        public System.Windows.Forms.TextBox txtZipCode;
        private System.Windows.Forms.PictureBox pbxCustomer;
        private System.Windows.Forms.Button btnPicture;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
        public System.Windows.Forms.Label lblPicturePath;
    }
}