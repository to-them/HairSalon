namespace HairSalon
{
    partial class StateLookup
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
            this.lvwUStates = new System.Windows.Forms.ListView();
            this.btnOK = new System.Windows.Forms.Button();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lvwUStates
            // 
            this.lvwUStates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3});
            this.lvwUStates.Location = new System.Drawing.Point(12, 12);
            this.lvwUStates.Name = "lvwUStates";
            this.lvwUStates.Size = new System.Drawing.Size(162, 301);
            this.lvwUStates.TabIndex = 0;
            this.lvwUStates.UseCompatibleStateImageBehavior = false;
            this.lvwUStates.View = System.Windows.Forms.View.Details;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(120, 319);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(54, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Code";
            this.columnHeader2.Width = 40;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "State";
            this.columnHeader3.Width = 100;
            // 
            // StateLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(189, 351);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lvwUStates);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StateLookup";
            this.ShowInTaskbar = false;
            this.Text = "State Lookup";
            this.Load += new System.EventHandler(this.StateLookup_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwUStates;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}