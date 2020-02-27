using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace HairSalon
{
    
    public partial class Main : Form
    {
        //For text file data
        //int iFilename;
        //bool IsNewOrder;
        //string Filename;

        decimal price = 0.00M, taxrate = 0.00M, 
                taxamt = 0.00M, subtotal = 0.00M, 
                amtpaid = 0.00M, balance = 0.00M;

        Dictionary<string, Customer> lstCustomers;
        Dictionary<string, Receipt> lstReceipts;

        private int m_rid;
        private int rid
        {
            get { return (m_rid); }
            set { m_rid = value; }
        }

        public Main()
        {
            InitializeComponent();
            Utilities.setCompanyInfo();
            this.Text = Utilities.Company;
            lblCopyright.Text = Utilities.Copyright;
        }

        private void lnkAyitechSolutions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://ayitech.com");
        }

        private void Main_Load(object sender, EventArgs e)
        {
            mnuFileNew_Click(sender, e);    //new order
            ShowCustomers();
            getReceiptNumber();
        }

        //get receipt number
        private void getReceiptNumber()
        {
            //create new id
            Receipt rec = new Receipt();
            lstReceipts = new Dictionary<string, Receipt>();
            BinaryFormatter bfmReceipts = new BinaryFormatter();

            string strFilename = @"" + Utilities.Receipts + "\\receipts" + Utilities.Ext;

            if (File.Exists(strFilename))
            {
                FileStream stmReceipts = new FileStream(strFilename, FileMode.Open, FileAccess.Read, FileShare.Read);
                try
                {
                    // Retrieve the list of receipts from file
                    lstReceipts = (Dictionary<string, Receipt>)
                    bfmReceipts.Deserialize(stmReceipts);
                }
                finally
                {
                    stmReceipts.Close();
                }
            }

            
            if (lstReceipts.Count > 0)
            {
                int i = 1;
                foreach (KeyValuePair<string, Receipt> kvp in lstReceipts)
                {
                    if (i == lstReceipts.Count)
                    {
                        string dKey = kvp.Key;
                        m_rid = Convert.ToInt32(dKey) + 1;
                    }
                    i++;

                }
            }
            else
            {
                m_rid = 1001;
            }

            txtReceiptNumber.Text = rid.ToString();

        }

        internal void ShowCustomers()
        {
            //customers
            lstCustomers = new Dictionary<string, Customer>();
            BinaryFormatter bfmCustomers = new BinaryFormatter();

            string strFilename = @"" + Utilities.Customers + "\\customers" + Utilities.Ext;

            if (File.Exists(strFilename))
            {
                FileStream stmCustomers = new FileStream(strFilename,FileMode.Open,FileAccess.Read,FileShare.Read);

                try
                {
                    // Retrieve the list of customers from file
                    lstCustomers = (Dictionary<string, Customer>)
                    bfmCustomers.Deserialize(stmCustomers);
                }
                finally
                {
                    stmCustomers.Close();
                }
            }

            if (lstCustomers.Count == 0)
                return;

            lvwCustomers.Items.Clear();
            int i = 1;

            foreach (KeyValuePair<string, Customer> kvp in lstCustomers)
            {
                
                ListViewItem lviCustomer = new ListViewItem(kvp.Key);
                Customer cust = kvp.Value;
                
                lviCustomer.SubItems.Add(cust.m_Name);
                /*
                lviCustomer.SubItems.Add(cust.m_Telephone);
                lviCustomer.SubItems.Add(cust.m_Email);
                lviCustomer.SubItems.Add(cust.m_Street);
                lviCustomer.SubItems.Add(cust.m_City);
                lviCustomer.SubItems.Add(cust.m_State);
                lviCustomer.SubItems.Add(cust.m_ZipCode);
                */

                if (i % 2 == 0)
                {
                    lviCustomer.BackColor = Color.Navy;
                    lviCustomer.ForeColor = Color.White;
                }
                else
                {
                    lviCustomer.BackColor = Color.Blue;
                    lviCustomer.ForeColor = Color.White;
                }
                
                lvwCustomers.Items.Add(lviCustomer);

                i++;
            }

        }

        //new order
        internal void NewOrder()
        {
             ///////////////////
            //Using text file//
            //////////////////
            /* this has been replaced using dictionary
            // We will store our files in the following folder
            var strDirectory = @"" + Utilities.Receipts;

            var dirInfo = Directory.CreateDirectory(strDirectory);

            // Get the list of files, if any, from our directory
            var fleList = dirInfo.GetFiles();

            // If there is no file in the directory,
            // then we will use 1000 as the first file name
            if (fleList.Length == 0)
            {
                iFilename = 1000;
            }
            else // If there was at least one file in the directory
            {
                // Get a reference to the last file
                FileInfo fleLast = fleList[fleList.Length - 1];
                // Get the name of the last file without its extension
                string fwe = Path.GetFileNameWithoutExtension(fleLast.FullName);
                // Increment the name of the file by 1
                try
                {
                    iFilename = int.Parse(fwe) + 1;
                }
                catch (FormatException)
                {
                }
            }

            // Update our global name of the file
            Filename = strDirectory + "\\" + iFilename.ToString() + Utilities.Ext;
            txtReceiptNumber.Text = iFilename.ToString();
            */

            Reset();
            getReceiptNumber();

        }

        //save order
        internal void SaveOrder()
        {
            // We will store our files in the following folder    
            string strDirectory = @"" + Utilities.Receipts;
            DirectoryInfo dirInfo = Directory.CreateDirectory(strDirectory);

            ///////////////////
            //Using text file//
            //////////////////
            /* replaced with dictionary
            // Get the list of files, if any, from our directory
            FileInfo[] fleList = dirInfo.GetFiles();

            // If this is a new cleaning order,
            // get ready to create a name for the file
            if (IsNewOrder == true)
            {
                // If there is no file in the directory,
                // then we will use 1000 as the first file name
                if (fleList.Length == 0)
                {
                    iFilename = 1000;
                }
                else // If there was at least one file in the directory
                {
                    // Get a reference to the last file
                    FileInfo fleLast = fleList[fleList.Length - 1];
                    // Get the name of the last file without its extension
                    string fwe = Path.GetFileNameWithoutExtension(fleLast.FullName);
                    // Increment the name of the file by 1
                    iFilename = int.Parse(fwe) + 1;
                }

                // Update our global name of the file
                Filename = strDirectory + "\\" + iFilename.ToString() + Utilities.Ext;
                txtReceiptNumber.Text = iFilename.ToString();

                IsNewOrder = false;
            } // If a cleaning order was already opened, we will simply update it
            else
                Filename = @"" + Utilities.Receipts + "\\" + txtReceiptNumber.Text + Utilities.Ext;

            StreamWriter sw = new StreamWriter(Filename);

            try
            {
                //Job Identification
                sw.WriteLine(cbxStyles.Text);
                sw.WriteLine(txtCustomerName.Text);
                sw.WriteLine(txtCustomerPhone.Text);
                sw.WriteLine(dtpDate.Value.ToString("D"));

                //Job Summary
                sw.WriteLine(txtPrice.Text);
                sw.WriteLine(txtTaxRate.Text);
                sw.WriteLine(txtTaxAmount.Text);
                sw.WriteLine(txtSubTotal.Text);
                sw.WriteLine(txtAmountPaid.Text);
                sw.WriteLine(txtBalance.Text);
                sw.WriteLine();
            }
            finally
            {
                sw.Close();
            }
            */

            ////////////////////
            //Using Dictionary//
            ///////////////////

            if (!valIdentification())
            {
                return;
            }
            else
            {
                //create
                Receipt rec = new Receipt();

                //Job Identification
                rec.m_ReceiptNum = txtReceiptNumber.Text;
                rec.m_Style = cbxStyles.Text;
                rec.m_Customer = txtCustomerName.Text;
                rec.m_Phone = txtCustomerPhone.Text;
                rec.m_Date = dtpDate.Text;

                //Job Summary
                rec.m_Price = txtPrice.Text;
                rec.m_TaxRate = txtTaxRate.Text;
                rec.m_TaxAmt = txtTaxAmount.Text;
                rec.m_SubTotal = txtSubTotal.Text;
                rec.m_AmtPaid = txtAmountPaid.Text;
                rec.m_Balance = txtBalance.Text;

                //Get list of receipts
                // check if there is already one with the current receipt number
                // If there is already a receipt number like that...
                if (lstReceipts.ContainsKey(txtReceiptNumber.Text) == true)
                {
                    //simply update its value
                    lstReceipts[txtReceiptNumber.Text] = rec;
                }
                else
                {
                    // If there is no order with that receipt,
                    // then create a new rental order
                    lstReceipts.Add(txtReceiptNumber.Text, rec);
                }

                //get receipts file
                string strFilename = strDirectory + "\\receipts" + Utilities.Ext;
                FileStream fs = new FileStream(strFilename, FileMode.Create, FileAccess.Write, FileShare.Write);
                BinaryFormatter bf = new BinaryFormatter();
                try
                {
                    bf.Serialize(fs, lstReceipts);
                    MessageBox.Show("Work order has been saved.", Utilities.MsgBoxHead);
                }
                finally
                {
                    fs.Close();
                }
                
            }

        }

        private bool valIdentification()
        {
            string error = "";

            if (txtCustomerName.Text == "")
            {
                error += "Please enter customer name! \n";
                txtCustomerName.Focus();
            }
            if (cbxStyles.Text == "")
            {
                error += "Please select hair style! \n";
                cbxStyles.Focus();
            }
            if (txtReceiptNumber.Text == "")
            {
                error += "The receipt number is missing \n";
            }
            if (txtReceiptNumber.Text.Length > 0)
            {
                try
                {
                    m_rid = int.Parse(txtReceiptNumber.Text);
                }
                catch (FormatException)
                {
                    error += "You must provide a valid receipt number \n Only integer is required.";
                    txtReceiptNumber.Focus();
                }
            }
            
            if (error != "")
            {
                MessageBox.Show(error, Utilities.MsgBoxHead);
                return false;
            }
            return true;
        }

        //open order
        internal void OpenOrder()
        {
            ///////////////////
            //Using text file//
            //////////////////
            /*
            if (txtReceiptNumber.Text == "")
                return;
            else
            {
                try
                {
                    IsNewOrder = false;
                    Filename = @"" + Utilities.Receipts + "\\" + txtReceiptNumber.Text + Utilities.Ext;

                    StreamReader sr = new StreamReader(Filename);

                    try
                    {

                        //Job Identification
                        cbxStyles.Text = sr.ReadLine();
                        txtCustomerName.Text = sr.ReadLine();
                        txtCustomerPhone.Text = sr.ReadLine();
                        dtpDate.Value = DateTime.Parse(sr.ReadLine());

                        //Job Summary
                        txtPrice.Text = sr.ReadLine();
                        txtTaxRate.Text = sr.ReadLine();
                        txtTaxAmount.Text = sr.ReadLine();
                        txtSubTotal.Text = sr.ReadLine();
                        txtAmountPaid.Text = sr.ReadLine();
                        txtBalance.Text = sr.ReadLine();

                        //btnDelete.Enabled = true; //Removed - not neccessary now

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
            */

            ////////////////////
            //Using Dictionary//
            ///////////////////
            //lstReceipts = new Dictionary<string, Receipt>();
            Receipt rec = null;

            if (txtReceiptNumber.Text == "")
            {
                MessageBox.Show("You must enter a receipt number");
                return;
            }

            if(lstReceipts.TryGetValue(txtReceiptNumber.Text, out rec))
            {
                //Job Identification
                cbxStyles.Text = rec.m_Style;
                txtCustomerName.Text = rec.m_Customer;
                txtCustomerPhone.Text = rec.m_Phone;
                dtpDate.Text = rec.m_Date;

                //Job Summary
                txtPrice.Text = rec.m_Price;
                txtTaxRate.Text = rec.m_TaxRate;
                txtTaxAmount.Text = rec.m_TaxAmt;
                txtSubTotal.Text = rec.m_SubTotal;
                txtAmountPaid.Text = rec.m_AmtPaid;
                txtBalance.Text = rec.m_Balance;

                //btnDelete.Enabled = true; //Removed - not neccessary now
            }
            else
            {
                MessageBox.Show("There is no work order with that receipt number", Utilities.MsgBoxHead);
                return;
            }

        }

        //reset form
        internal void Reset()
        {
            //ShowCustomers();

            //Job Identification
            cbxStyles.Text = "";
            txtCustomerName.Text = "";
            txtCustomerPhone.Text = "";
            dtpDate.Value = DateTime.Today;

            //Job Summary
            txtPrice.Text = "0.00";
            txtTaxRate.Text = Utilities.TaxRate;
            txtTaxAmount.Text = "0.00";
            txtSubTotal.Text = "0.00";
            txtAmountPaid.Text = "0.00";
            txtBalance.Text = "0.00";

            txtCustomerName.Focus();
            //btnDelete.Enabled = false;    //Removed - not neccessary now

        }

        //delete order
        internal void DeleteOrder()
        {
            MessageBox.Show("Delete method still under construction...", Utilities.MsgBoxHead);
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuFileNew_Click(object sender, EventArgs e)
        {
            NewOrder();
            getReceiptNumber();
        }

        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            OpenOrder();
        }

        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            CalSubTotal();
            CalBalance();
            SaveOrder();
        }

        private void mnuFilePrint_Click(object sender, EventArgs e)
        {
            if (dlgPrint.ShowDialog() == DialogResult.OK)
            {
                docPrint.Print();
            }
        }

        //validate for sub total
        private bool valSubTotal()
        {
            string error = "";
            try
            {
                price = decimal.Parse(this.txtPrice.Text);
            }
            catch (FormatException)
            {
                error += "Please enter a valid Price! \n";
            }
            try
            {
                taxrate = decimal.Parse(this.txtTaxRate.Text);
            }
            catch (FormatException)
            {
                error += "Please enter a valid Tax Rate! \n";
            }
            try
            {
                taxamt = decimal.Parse(this.txtTaxAmount.Text);
            }
            catch (FormatException)
            {
                error += "Please enter a valid Tax Amount! \n";
            }
            if (error != "")
            {
                MessageBox.Show(error, Utilities.MsgBoxHead);
                return false;
            }
            return true;
        }

        internal void CalSubTotal()
        {
            if (!valSubTotal())
                return;
            else
            {
                taxamt = price * (taxrate / 100);
                subtotal = price + taxamt;
                txtTaxAmount.Text = taxamt.ToString("F");
                txtSubTotal.Text = subtotal.ToString("F");
            }

        }

        private void txtPrice_Leave(object sender, EventArgs e)
        { 
           CalSubTotal();
        }

        private void txtTaxRate_Leave(object sender, EventArgs e)
        {
            CalSubTotal();
        }

        private bool valAmountPaid()
        {
            string error = "";
            try
            {
                amtpaid = decimal.Parse(this.txtAmountPaid.Text);
            }
            catch (FormatException)
            {
                error += "Please enter a valid Amount Paid! \n";
            }
            if (error != "")
            {
                MessageBox.Show(error, Utilities.MsgBoxHead);
                return false;
            }
            return true;
        }

        internal void CalBalance()
        {
            if (!valAmountPaid())
                return;
            else
            {
                balance = amtpaid - subtotal;
                txtBalance.Text = balance.ToString("F");
            }

        }

        private void txtAmountPaid_Leave(object sender, EventArgs e)
        {
            CalSubTotal();
            CalBalance();

            //if (txtAmountPaid.Modified == true)
                SaveOrder();

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenOrder();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewOrder();
            getReceiptNumber();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void docPrint_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Business Address
            System.Drawing.Font fntString = new Font("Times New Roman", 18, FontStyle.Bold);
            e.Graphics.DrawString(Utilities.Company, fntString, Brushes.Black, 50, 50);

            fntString = new System.Drawing.Font("Times New Roman", 11, FontStyle.Regular);
            e.Graphics.DrawString(Utilities.Street, fntString, Brushes.Black, 50, 90);

            string strDisplay = Utilities.City + " " +
                                 Utilities.State + " " +
                                 Utilities.ZipCode;
            fntString = new System.Drawing.Font("Times New Roman", 11, FontStyle.Regular);
            e.Graphics.DrawString(strDisplay, fntString, Brushes.Black, 50, 110);

            fntString = new System.Drawing.Font("Times New Roman", 11, FontStyle.Regular);
            e.Graphics.DrawString(Utilities.Telephone, fntString, Brushes.Black, 50, 130);

            fntString = new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular);
            e.Graphics.DrawString(DateTime.Now.ToLongDateString(), fntString, Brushes.Black, 50, 170);

            //Logo - Ref:http://www.csharpkey.com/visualcsharp/gdi/printing.htm
            //Image logo = Image.FromFile(Utilities.Logo);
            //e.Graphics.DrawImage(logo, 620.00F, 60.00F);

            //Heading
            fntString = new Font("Arial", 16, FontStyle.Bold);
            e.Graphics.DrawString("Work Order", fntString, Brushes.Black, 320, 220);

            //reference
            fntString = new System.Drawing.Font("Times New Roman", 11, FontStyle.Bold);
            e.Graphics.DrawString("Receipt #: ", fntString, Brushes.Black, 100, 280);
            fntString = new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular);
            e.Graphics.DrawString(txtReceiptNumber.Text, fntString, Brushes.Black, 180, 280);
            //e.Graphics.DrawLine(new Pen(Color.Black, 1), 100, 240, 380, 240);

            //customer info
            fntString = new Font("Arial", 12, FontStyle.Bold);
            //e.Graphics.FillRectangle(Brushes.Gray, new Rectangle(100, 300, 620, 20));
            //e.Graphics.DrawRectangle(Pens.Black, new Rectangle(100, 300, 620, 20));
            e.Graphics.DrawString("Customer Information", fntString, Brushes.Black, 100, 320);

            fntString = new Font("Times New Roman", 11, FontStyle.Bold);
            e.Graphics.DrawString("Name: ", fntString, Brushes.Black, 100, 350);
            e.Graphics.DrawString("Telephone: ", fntString, Brushes.Black, 420, 350);
            fntString = new Font("Times New Roman", 12, FontStyle.Regular);
            e.Graphics.DrawString(txtCustomerName.Text, fntString, Brushes.Black, 180, 350);
            e.Graphics.DrawString(txtCustomerPhone.Text, fntString, Brushes.Black, 510, 350);
            //e.Graphics.DrawLine(new Pen(Color.Black, 1), 100, 320, 720, 320);

            //Order Summary
            fntString = new Font("Arial", 12, FontStyle.Bold);
            e.Graphics.DrawString("Order Evaluation", fntString, Brushes.Black, 100, 460);

            StringFormat fmtString = new StringFormat();
            fmtString.Alignment = StringAlignment.Far;

            fntString = new Font("Times New Roman", 11, FontStyle.Bold);
            e.Graphics.DrawString("Hair Style:", fntString, Brushes.Black, 100, 490);
            fntString = new Font("Times New Roman", 11, FontStyle.Regular);
            e.Graphics.DrawString(cbxStyles.Text, fntString, Brushes.Black, 200, 490);
            //e.Graphics.DrawLine(new Pen(Color.Black, 1), 100, 760, 380, 760);

            fntString = new Font("Times New Roman", 11, FontStyle.Bold);
            e.Graphics.DrawString("Price:", fntString, Brushes.Black, 420, 490);
            fntString = new Font("Times New Roman", 11, FontStyle.Regular);
            e.Graphics.DrawString(txtPrice.Text, fntString, Brushes.Black, 580, 490, fmtString);
            //e.Graphics.DrawLine(new Pen(Color.Black, 1), 420, 760, 720, 760);

            fntString = new Font("Times New Roman", 11, FontStyle.Bold);
            e.Graphics.DrawString("Tax Rate:", fntString, Brushes.Black, 100, 520);
            fntString = new Font("Times New Roman", 11, FontStyle.Regular);
            e.Graphics.DrawString(txtTaxRate.Text, fntString, Brushes.Black, 240, 520, fmtString);
            e.Graphics.DrawString("%", fntString, Brushes.Black, 240, 520);

            fntString = new Font("Times New Roman", 11, FontStyle.Bold);
            e.Graphics.DrawString("Tax Amount:", fntString, Brushes.Black, 420, 520);
            fntString = new Font("Times New Roman", 11, FontStyle.Regular);
            e.Graphics.DrawString(txtTaxAmount.Text, fntString, Brushes.Black, 580, 520, fmtString);
            //e.Graphics.DrawLine(new Pen(Color.Black, 1), 420, 790, 720, 790);

            fntString = new Font("Times New Roman", 11, FontStyle.Bold);
            e.Graphics.DrawString("Total Charge:", fntString, Brushes.Black, 420, 550);
            fntString = new Font("Times New Roman", 11, FontStyle.Regular);
            e.Graphics.DrawString(txtSubTotal.Text, fntString, Brushes.Black, 580, 550, fmtString);
            //e.Graphics.DrawLine(new Pen(Color.Black, 1), 420, 820, 720, 820);

            fntString = new Font("Times New Roman", 11, FontStyle.Bold);
            e.Graphics.DrawString("Amount Paid:", fntString, Brushes.Black, 420, 580);
            fntString = new Font("Times New Roman", 11, FontStyle.Regular);
            e.Graphics.DrawString(txtAmountPaid.Text, fntString, Brushes.Black, 580, 580, fmtString);

            e.Graphics.DrawLine(new Pen(Color.Black, 1), 420, 610, 590, 610);

            fntString = new Font("Times New Roman", 11, FontStyle.Bold);
            e.Graphics.DrawString("Balance Due:", fntString, Brushes.Black, 420, 620);
            fntString = new Font("Times New Roman", 11, FontStyle.Regular);
            e.Graphics.DrawString(txtBalance.Text, fntString, Brushes.Black, 580, 620, fmtString);

            e.Graphics.DrawLine(new Pen(Color.Black, 1), 420, 650, 590, 650);

            //baseline
            //e.Graphics.DrawLine(new Pen(Color.Black, 1), 80, 880, 750, 880);
            //e.Graphics.DrawLine(new Pen(Color.Black, 2), 80, 883, 750, 883);
            if (Utilities.Website.Length > 0)
            {
                strDisplay = "Visit us at " + Utilities.Website + " for more information.";
            }
            else
            {
                strDisplay = "";
            }

            fntString = new Font("Times New Roman", 11, FontStyle.Regular);
            e.Graphics.DrawString(strDisplay, fntString, Brushes.Black, 220, 950);

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dlgPrint.ShowDialog() == DialogResult.OK)
            {
                docPrint.Print();
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            dlgPrintPreview.ShowDialog();
        }

        private void mnuToolsCustomers_Click(object sender, EventArgs e)
        {
            Customers cust = new Customers();
            cust.ShowDialog();
        }

        private void mnuToolsReceipts_Click(object sender, EventArgs e)
        {
            Reports rpt = new Reports();
            rpt.ShowDialog();
        }

        private void btnResfreshCustomers_Click(object sender, EventArgs e)
        {
            ShowCustomers();
        }

        private void lvwCustomers_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Customer cust = new Customer();
            string itm = e.Item.Text;
            foreach (KeyValuePair<string, Customer> kvp in lstCustomers)
            {
                string dkey = kvp.Key;
                if (dkey == itm)
                {
                    cust = kvp.Value;
                    txtCustomerName.Text = cust.m_Name;
                    txtCustomerPhone.Text = cust.m_Telephone;
                    break;
                }

            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            CalSubTotal();
            CalBalance();

            //if (txtAmountPaid.Modified == true)
             SaveOrder();
        }

        private void mnuToolsCompany_Click(object sender, EventArgs e)
        {
            CompanyInfo com = new CompanyInfo();
            com.ShowDialog();
        }

        
    }
}
