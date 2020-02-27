using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using AllPurpose_Lib;

namespace HairSalon
{
    public partial class CompanyInfo : Form
    {
        int iFilename;
        bool IsNewOrder;
        string Filename;

        public CompanyInfo()
        {
            InitializeComponent();
        }

        private void CompanyInfo_Load(object sender, EventArgs e)
        {
            // We will store our files in the following folder    
            string strDirectory = @"" + Utilities.CompanyInfo;
            DirectoryInfo dirInfo = Directory.CreateDirectory(strDirectory);

            // Get the list of files, if any, from our directory
            var fleList = dirInfo.GetFiles();

            // If there is no file in the directory,
            // then we will use 1000 as the first file name
            if (fleList.Length == 0)
            {
                return;
            }
            else // If there was at least one file in the directory
            {
                ShowCompanyInfo();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!valInput())
            {
                return;
            }
            else
            {
                SaveCompanyInfo();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Open
        internal void ShowCompanyInfo()
        {
            try
            {
                Filename = @"" + Utilities.CompanyInfo + "\\company" + Utilities.Ext;
                StreamReader sr = new StreamReader(Filename);

                try
                {
                    //Company Information
                    txtName.Text = sr.ReadLine();
                    txtStreet.Text = sr.ReadLine();
                    txtCity.Text = sr.ReadLine();
                    txtState.Text = sr.ReadLine();
                    txtZip.Text = sr.ReadLine();
                    txtTelephone.Text = sr.ReadLine();
                    txtEmail.Text = sr.ReadLine();
                    txtWebsite.Text = sr.ReadLine();
                    txtCopyright.Text = sr.ReadLine();
                    txtTaxRate.Text = sr.ReadLine();
                    lblLastUpdate.Text = sr.ReadLine();

                }
                finally
                {
                    sr.Close();
                }

            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("There is no job order " +
                    "with that receipt number", Utilities.MsgBoxHead);
            }

        }

        //Save 
        internal void SaveCompanyInfo()
        {
            // We will store our files in the following folder    
            string strDirectory = @"" + Utilities.CompanyInfo;
            DirectoryInfo dirInfo = Directory.CreateDirectory(strDirectory);

            Filename = @"" + Utilities.CompanyInfo + "\\company" + Utilities.Ext;

            StreamWriter sw = new StreamWriter(Filename);

            try
            {
                //Company Information
                sw.WriteLine(txtName.Text);
                sw.WriteLine(txtStreet.Text);
                sw.WriteLine(txtCity.Text);
                sw.WriteLine(txtState.Text);
                sw.WriteLine(txtZip.Text);
                sw.WriteLine(txtTelephone.Text);
                sw.WriteLine(txtEmail.Text);
                sw.WriteLine(txtWebsite.Text);
                sw.WriteLine(txtCopyright.Text);
                sw.WriteLine(txtTaxRate.Text);
                sw.WriteLine("Last Update: " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString());
                sw.WriteLine();

                MessageBox.Show("Company Information has been saved.", Utilities.MsgBoxHead);
            }
            finally
            {
                sw.Close();
                Utilities.setCompanyInfo();
            }

        }

        private bool valInput()
        {
            GeneralValidations gv = new GeneralValidations();
            string reqd = string.Empty;
            double dOutput = 0;
            if (!gv.isAstring(txtName.Text))
            {
                reqd += "Please provide company name! \n";
            }

            if (!Double.TryParse(txtTaxRate.Text, out dOutput))
            {
                reqd += "Please enter a valid tax rate! \n";
            }

            if (txtEmail.Text.Length > 0)
            {
                if (!gv.isValidEmail(txtEmail.Text))
                {
                    reqd += "A valid email address is required \n";
                }
            }

            if (txtWebsite.Text.Length > 0)
            {
                if (!gv.isWebsite(txtWebsite.Text))
                {
                    reqd += "A valid web address is required \n";
                }
            }

            if (reqd != "")
            {
                MessageBox.Show(reqd, Utilities.MsgBoxHead, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }


    }
}
