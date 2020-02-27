using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HairSalon
{
    public partial class CustomerEditor : Form
    {
        public CustomerEditor()
        {
            InitializeComponent();
        }

        private void btnPicture_Click(object sender, EventArgs e)
        {
            if (dlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                lblPicturePath.Text = dlgOpenFile.FileName;
                pbxCustomer.Image = Image.FromFile(lblPicturePath.Text);
            }
        }
    }
}
