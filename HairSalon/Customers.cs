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
using RKLib.ExportData;

namespace HairSalon
{
    public partial class Customers : Form
    {
        Dictionary<string, Customer> lstCustomers;
        bool isUpdate = false;

        private int m_cid;  //to generate new customer id
        private int cid
        {
            get { return (m_cid); }
            set { m_cid = value; }
        }

        private string m_selectedKey;   //for selected customer on listview
        private string selectedKey
        {
            get { return (m_selectedKey); }
            set { m_selectedKey = value; }
        }

        private string m_imagepath;     //for customer picture path
        private string imagepath
        {
            get { return (m_imagepath); }
            set { m_imagepath = value; }
        }

        private string m_tempath = "";     //for customer picture path temp
        private string tempath
        {
            get { return (m_tempath); }
            set { m_tempath = value; }
        }

        public Customers()
        {
            InitializeComponent();
            this.Text = Utilities.Company + " - Customers";
            Utilities.setDefaultPicture(Utilities.DefaultPicture);
        }

        private void Customers_Load(object sender, EventArgs e)
        {
            ShowCustomers();
            //isSaveUpdate(isUpdate);
            getCustomerID();
            ExportToExcel();
        }

        //Export Customers data to excel
        private void ExportToExcel()
        {
            try
            {
                string fpath = Utilities.ExcelCustomers;

                // Specify the column list to export
                int[] iColumns = { 0, 1, 2, 3, 4, 5, 6 };

                // Export the details of specified columns to CSV
                RKLib.ExportData.Export objExport = new Export("Win");
                objExport.ExportDetails(Utilities.ExportCustomers(), iColumns, Export.ExportFormat.Excel, fpath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, Utilities.MsgBoxHead);
            }

        }

        /*
        private void isSaveUpdate(bool isUpdate)
        {
            if (isUpdate == true)
                btnSave.Text = "Update";
            else
                btnSave.Text = "Save";
        }
        */

        private void getCustomerID()
        {
            //create new id
            Customer cust = new Customer();
            lstCustomers = new Dictionary<string, Customer>();

            BinaryFormatter bfmCustomers = new BinaryFormatter();
            string strFilename = @"" + Utilities.Customers + "\\customers" + Utilities.Ext;

            if (File.Exists(strFilename))
            {
                FileStream stmCustomers = new FileStream(strFilename, FileMode.Open, FileAccess.Read, FileShare.Read);
                try
                {
                    // Retrieve the list of receipts from file
                    lstCustomers = (Dictionary<string, Customer>)
                    bfmCustomers.Deserialize(stmCustomers);
                }
                finally
                {
                    stmCustomers.Close();
                }

            }

            if (lstCustomers.Count > 0)
            {
                int i = 1;
                foreach (KeyValuePair<string, Customer> kvp in lstCustomers)
                {
                    if (i == lstCustomers.Count)
                    {
                        string dKey = kvp.Key;
                        m_cid = Convert.ToInt32(dKey) + 1;

                    }
                    i++;

                }
            }
            else
            {
                m_cid = 1;
            }
            //get default image to avoid compiler warning
            m_imagepath = Utilities.DefaultPicture;
            lblCustomerID.Text = "New Customer id: " + cid;

        }

        internal void ShowCustomers()
        {
            lstCustomers = new Dictionary<string, Customer>();
            BinaryFormatter bfmCustomers = new BinaryFormatter();

            string strFilename = @"" + Utilities.Customers + "\\customers" + Utilities.Ext;

            if (File.Exists(strFilename))
            {
                FileStream stmCustomers = new FileStream(strFilename, FileMode.Open, FileAccess.Read, FileShare.Read);
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
                string cid = kvp.Key;
                lviCustomer.SubItems.Add(cust.m_Name);
                lviCustomer.SubItems.Add(cust.m_Telephone);
                lviCustomer.SubItems.Add(cust.m_Email);
                lviCustomer.SubItems.Add(cust.m_Street);
                lviCustomer.SubItems.Add(cust.m_City);
                lviCustomer.SubItems.Add(cust.m_State);
                lviCustomer.SubItems.Add(cust.m_ZipCode);

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

        //reset form
        internal void Reset()
        {
            txtName.Text = "";
            txtTelephone.Text = "";
            txtEmail.Text = "";
            txtStreet.Text = "";
            txtCity.Text = "";
            cbxStates.Text = "";
            txtZipCode.Text = "";
            m_imagepath = "";
            lblPicturePath.Text = imagepath;
            pbxCustomer.Image = null;
            isUpdate = false;
            //isSaveUpdate(isUpdate);
            m_selectedKey = "";
            m_tempath = "";
            //btnDelete.Enabled = false;
        }

        //this will open new customer form 
        /*
        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            CustomerEditor editor = new CustomerEditor();
            Directory.CreateDirectory(@"" + Utilities.Customers);

            if (editor.ShowDialog() == DialogResult.OK)
            {
                if (editor.txtName.Text == "")
                {
                    MessageBox.Show("You must provide the customer's name");
                    return;
                }

                string strFilename = @"" + Utilities.Customers + "\\customers" + Utilities.Ext;

                Customer cust = new Customer();

                //cust.m_Name = editor.txtName.Text;
                cust.m_Telephone = editor.txtTelephone.Text;
                cust.m_Email = editor.txtEmail.Text;
                cust.m_Street = editor.txtStreet.Text;
                cust.m_City = editor.txtCity.Text;
                cust.m_State = editor.cbxStates.Text;
                cust.m_ZipCode = editor.txtZipCode.Text;
                lstCustomers.Add(editor.txtName.Text, cust);

                FileStream bcrStream = new FileStream(strFilename,
                                                      FileMode.Create,
                                                      FileAccess.Write,
                                                      FileShare.Write);
                BinaryFormatter bcrBinary = new BinaryFormatter();
                bcrBinary.Serialize(bcrStream, lstCustomers);
                bcrStream.Close();

                ShowCustomers();
            }

        }
        */

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool isDupCustomerInsert(string newcustomer)
        {
            Customer cust = new Customer();
            lstCustomers = new Dictionary<string, Customer>();

            BinaryFormatter bfmCustomers = new BinaryFormatter();
            string strFilename = @"" + Utilities.Customers + "\\customers" + Utilities.Ext;

            if (File.Exists(strFilename))
            {
                FileStream stmCustomers = new FileStream(strFilename, FileMode.Open, FileAccess.Read, FileShare.Read);
                try
                {
                    // Retrieve the list of receipts from file
                    lstCustomers = (Dictionary<string, Customer>)
                    bfmCustomers.Deserialize(stmCustomers);
                }
                finally
                {
                    stmCustomers.Close();
                }

            }

            if (lstCustomers.Count > 0)
            {
                foreach (KeyValuePair<string, Customer> kvp in lstCustomers)
                {
                    cust = kvp.Value;
                    if (cust.m_Name.ToLower() == newcustomer.ToLower())
                    {
                        MessageBox.Show("Customer name already exist! \n" +
                            "Enter a different name to identify customer.", Utilities.MsgBoxHead);
                        return true;
                    }

                }
            }
            return false;
        }

        private bool isDupCustomerUpdate(string cid, string customer)
        {
            Customer cust = new Customer();
            lstCustomers = new Dictionary<string, Customer>();

            BinaryFormatter bfmCustomers = new BinaryFormatter();
            string strFilename = @"" + Utilities.Customers + "\\customers" + Utilities.Ext;

            if (File.Exists(strFilename))
            {
                FileStream stmCustomers = new FileStream(strFilename, FileMode.Open, FileAccess.Read, FileShare.Read);
                try
                {
                    // Retrieve the list of receipts from file
                    lstCustomers = (Dictionary<string, Customer>)
                    bfmCustomers.Deserialize(stmCustomers);
                }
                finally
                {
                    stmCustomers.Close();
                }

            }

            if (lstCustomers.Count > 0)
            {
                foreach (KeyValuePair<string, Customer> kvp in lstCustomers)
                {
                    string id = kvp.Key;
                    cust = kvp.Value;
                    if (((cust.m_Name.ToLower() == customer.ToLower())) && (id != cid))
                    {
                        MessageBox.Show("Customer name already exist! \n" +
                            "Enter a different name to identify customer.", Utilities.MsgBoxHead);
                        return true;
                    }

                }
            }
            return false;
        }
        

        //validate save
        internal bool valSave()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("You must provide the customer's name", Utilities.MsgBoxHead);
                return false;
            }
            if (txtEmail.Text.Length > 0)
            {
                string str = txtEmail.Text;
                if ((str.IndexOf(".") > 2) && (str.IndexOf("@") > 0))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("You must enter a valid email address", Utilities.MsgBoxHead);
                    return false;
                }
            }

            return true;

        }

        //save 
        internal void SaveCustomer()
        {
            //this uses number id as the key
            //this will also update
            //if no picture selected use default to prevent warning
            //then update image later

            if (!valSave())
                return;
            else
            {
                Directory.CreateDirectory(@"" + Utilities.Customers);
                string strFilename = @"" + Utilities.Customers + "\\customers" + Utilities.Ext;
                Customer cust = new Customer();

                try
                {
                    
                    cust.m_Name = txtName.Text;
                    cust.m_Telephone = txtTelephone.Text;
                    cust.m_Email = txtEmail.Text;
                    cust.m_Street = txtStreet.Text;
                    cust.m_City = txtCity.Text;
                    cust.m_State = cbxStates.Text;
                    cust.m_ZipCode = txtZipCode.Text;
                    
                    string picnewname = "";
                    FileInfo flePicture = new FileInfo(imagepath);
                    if (tempath.Length > 0)
                    {
                        if (tempath == imagepath)
                        {
                            picnewname = tempath;
                        }
                        else
                        {
                            picnewname = @"" + Utilities.Customers + "\\" + txtName.Text + Utilities.RandomNumber(1, 100) + flePicture.Extension;
                            flePicture.CopyTo(picnewname);
                        }

                    }
                    else
                    {
                        picnewname = @"" + Utilities.Customers + "\\" + txtName.Text + flePicture.Extension;
                        //if picture exist don't copy
                        if (!File.Exists(picnewname))
                        {
                            flePicture.CopyTo(picnewname);
                        }
                        else
                        {
                            picnewname = imagepath;
                        }
                    }
                    cust.m_Picture = picnewname;
                    
                    cust.m_CustomerID = cid.ToString();

                    // Get the list of orders and 
                    // check if there is already one with the current receipt number
                    // If there is already a receipt number like that...
                    if (lstCustomers.ContainsKey(cust.m_CustomerID) == true)
                    {
                        // Simply update its value
                        //check for name duplication
                        if (isDupCustomerUpdate(cust.m_CustomerID, txtName.Text))
                            return;
                        else
                            lstCustomers[cust.m_CustomerID] = cust;
                    }
                    else
                    {
                        // If there is no order with that receipt,
                        // then create a new job order
                        //check for name duplication
                        if (isDupCustomerInsert(txtName.Text))
                            return;
                        else
                            lstCustomers.Add(cust.m_CustomerID, cust);
                    }

                    FileStream bcrStream = new FileStream(strFilename,FileMode.Create,FileAccess.ReadWrite,FileShare.ReadWrite);
                    BinaryFormatter bcrBinary = new BinaryFormatter();

                    bcrBinary.Serialize(bcrStream, lstCustomers);
                    bcrStream.Close();
                    ExportToExcel();

                    //Reset();
                    ShowCustomers();
                    MessageBox.Show("Customer has been saved.", Utilities.MsgBoxHead);

                }
                catch (SystemException ex)
                {
                    MessageBox.Show(ex.Message, Utilities.MsgBoxHead);
                }

            }

            //-----------------------------------------------------------------------------------
            //this uses customer's name as the key
            /*
            if (!valSave())
                return;
            else
            {
                Directory.CreateDirectory(@"" + Utilities.Customers);
                string strFilename = @"" + Utilities.Customers + "\\customers" + Utilities.Ext;
                Customer cust = new Customer();

                try
                {
                    cust.m_Telephone = txtTelephone.Text;
                    cust.m_Email = txtEmail.Text;
                    cust.m_Street = txtStreet.Text;
                    cust.m_City = txtCity.Text;
                    cust.m_State = cbxStates.Text;
                    cust.m_ZipCode = txtZipCode.Text;
                    if (lblPicturePath.Text.Length != 0)
                    {
                        FileInfo flePicture = new FileInfo(lblPicturePath.Text);
                        flePicture.CopyTo(@"" + Utilities.Customers + "\\" +
                                          txtName.Text +
                                          flePicture.Extension);
                        cust.m_Picture = @"" + Utilities.Customers + "\\" +
                                          txtName.Text +
                                          flePicture.Extension;

                    }
                    lstCustomers.Add(txtName.Text, cust);   

                    FileStream bcrStream = new FileStream(strFilename,
                                                          FileMode.Create,
                                                          FileAccess.Write,
                                                          FileShare.Write);
                    BinaryFormatter bcrBinary = new BinaryFormatter();

                    bcrBinary.Serialize(bcrStream, lstCustomers);
                    bcrStream.Close();

                    Reset();
                    ShowCustomers();

                }
                catch (SystemException ex)
                {
                    MessageBox.Show(ex.Message, Utilities.MsgBoxHead);
                }

            }
            */

        }

        //Update
        /*
        internal void UpdateCustomer()
        {
            Directory.CreateDirectory(@"" + Utilities.Customers);

            if (!valSave())
                return;
            else
            {

                string strFilename = @"" + Utilities.Customers + "\\customers" + Utilities.Ext;
                Customer cust = new Customer();

                try
                {
                    cust.m_Telephone = txtTelephone.Text;
                    cust.m_Email = txtEmail.Text;
                    cust.m_Street = txtStreet.Text;
                    cust.m_City = txtCity.Text;
                    cust.m_State = cbxStates.Text;
                    cust.m_ZipCode = txtZipCode.Text;
                    if (lblPicturePath.Text.Length != 0)
                    {
                        FileInfo flePicture = new FileInfo(lblPicturePath.Text);
                        flePicture.CopyTo(@"" + Utilities.Customers + "\\" +
                                          txtName.Text +
                                          flePicture.Extension);
                        cust.m_Picture = @"" + Utilities.Customers + "\\" +
                                          txtName.Text +
                                          flePicture.Extension;

                    }
                    //lstCustomers.Add(txtName.Text, cust);   //this is key - id for the customer
                    if (lstCustomers.ContainsKey(txtName.Text) == true)
                    {
                        lstCustomers[txtName.Text] = cust;
                    }

                    FileStream bcrStream = new FileStream(strFilename,
                                                          FileMode.Create,
                                                          FileAccess.Write,
                                                          FileShare.Write);
                    BinaryFormatter bcrBinary = new BinaryFormatter();

                    bcrBinary.Serialize(bcrStream, lstCustomers);
                    bcrStream.Close();

                    MessageBox.Show(selectedKey + " has been updated!", Utilities.MsgBoxHead);
                    Reset();
                    ShowCustomers();

                }
                catch (SystemException ex)
                {
                    MessageBox.Show(ex.Message, Utilities.MsgBoxHead);
                }

            }

            //MessageBox.Show("This will update: " + selectedKey + "\n Still under construction", Utilities.MsgBoxHead);
        }
        */

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveCustomer(); //it does both insert and update
            
            /*
            if (isUpdate == false)
                SaveCustomer();

            else
                UpdateCustomer();
            */
        }

        private void lvwCustomers_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Reset();
            Customer cust = new Customer();
            string itm = e.Item.Text;
            
            foreach (KeyValuePair<string, Customer> kvp in lstCustomers)
            {
                m_selectedKey = kvp.Key;

                if (selectedKey == itm)
                {
                    
                    try
                    {
                        cust.m_CustomerID = selectedKey;
                        m_cid = Convert.ToInt32(selectedKey);
                        lblCustomerID.Text = "Selected Customer id: " + cid;
                        cust = kvp.Value;
                        txtName.Text = cust.m_Name;
                        txtTelephone.Text = cust.m_Telephone;
                        txtEmail.Text = cust.m_Email;
                        txtStreet.Text = cust.m_Street;
                        txtCity.Text = cust.m_City;
                        cbxStates.Text = cust.m_State;
                        txtZipCode.Text = cust.m_ZipCode;

                        m_imagepath = cust.m_Picture;
                        m_tempath = cust.m_Picture;
                        lblPicturePath.Text = "Picture: " + imagepath;
                        if (imagepath.Length > 0 || imagepath != "")
                        {
                            pbxCustomer.Image = Image.FromFile(imagepath);
                        }

                        //isUpdate = true;
                        //isSaveUpdate(isUpdate);
                        //btnDelete.Enabled = true;
                        break;
                    }
                    catch (SystemException ex)
                    {
                        MessageBox.Show(ex.Message, Utilities.MsgBoxHead);
                    }
                }

            }

        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
            getCustomerID();

            /*
            BinaryFormatter bfnewcustomer = new BinaryFormatter();
            string strFilename = @"" + Utilities.Customers + "\\customers" + Utilities.Ext;
            if (File.Exists(strFilename))
            {
                FileStream fscustomers = new FileStream(strFilename, FileMode.Open, FileAccess.Read, FileShare.Read);

                try
                {
                    lstCustomer = (SortedList<int, Customer>)bfnewcustomer.Deserialize(fscustomers);
                    custid = lstCustomer.Keys[lstCustomer.Count - 1] + 1;
                }
                finally
                {
                    fscustomers.Close();
                }

            }
            else
            {
                custid = 1;
                lstCustomer = new SortedList<int, Customer>();
            }
            cust.m_CustomerID = custid.ToString();
            */
        }

        //delete
        internal void DeleteCustomer()
        {
            /*
            Customer cust = new Customer();
            int i = 1;
            int cot = lstCustomers.Count;
            foreach (KeyValuePair<string, Customer> kvp in lstCustomers)
            {
                try
                {
                    if (selectedKey == kvp.Key)
                    {
                        lstCustomers.Remove(kvp.Key);
                        Reset();
                        break;
                    }

                    i++;
                }
                catch (SystemException ex)
                {
                    MessageBox.Show(ex.Message, Utilities.MsgBoxHead);
                }

            }
            */

            MessageBox.Show("This will delete: " + selectedKey + "\n Still under construction...", Utilities.MsgBoxHead);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult ans = MessageBox.Show("Are sure you want to delete \n " +
               selectedKey + "\n permanently from your database?",
               Utilities.MsgBoxHead, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {
                DeleteCustomer();
            }
            else
            {
                MessageBox.Show("No changes made to \n " + selectedKey,
                Utilities.MsgBoxHead, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnStateLookup_Click(object sender, EventArgs e)
        {
            StateLookup lp = new StateLookup();
            lp.Show();
        }

        private void btnPicture_Click(object sender, EventArgs e)
        {
            if (dlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                m_imagepath = dlgOpenFile.FileName;
                lblPicturePath.Text = imagepath;
                pbxCustomer.Image = Image.FromFile(imagepath);
            }
        }

        private void btnFriendlyPrint_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Utilities.ExcelCustomers);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, Utilities.MsgBoxHead);
            }
        }
        
    }
}
