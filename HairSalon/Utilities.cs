using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Xml;
using System.IO;
using Ayitech_Lib;
using AllPurpose_Lib;
using System.Collections;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace HairSalon
{
    public class Utilities
    {
        //Folders
        private static string AppBaseDir = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
        private static string HairSalonFolder = AppBaseDir + ConfigurationManager.AppSettings["HairSalonFolder"].ToString();
        private static string InstalledDefaultPic = AppBaseDir + ConfigurationManager.AppSettings["InstalledDefaultPic"].ToString();
        public static string Employees = HairSalonFolder + "\\Employees";
        public static string Customers = HairSalonFolder + "\\Customers";
        public static string ExcelCustomers = HairSalonFolder + "\\Customers\\customers.xls";
        public static string Receipts = HairSalonFolder + "\\Receipts";
        public static string Reports = HairSalonFolder + "\\Reports";
        public static string ExcelReports = HairSalonFolder + "\\Receipts\\receipts.xls";
        public static string CompanyInfo = HairSalonFolder + "\\CompanyInfo";
        public static string UStatesFile = HairSalonFolder + "\\ustates.xml";
        public static string DefaultPicture = Customers + "\\default.jpg";
        
        //file extension
        public static string Ext = ".ayi";

        //Company Objects
        /*
        public static string Company = ConfigurationManager.AppSettings["Company"].ToString();
        public static string Street = ConfigurationManager.AppSettings["Street"].ToString();
        public static string City = ConfigurationManager.AppSettings["City"].ToString();
        public static string State = ConfigurationManager.AppSettings["State"].ToString();
        public static string ZipCode = ConfigurationManager.AppSettings["ZipCode"].ToString();
        public static string Telephone = ConfigurationManager.AppSettings["Telephone"].ToString();
        public static string Website = ConfigurationManager.AppSettings["Website"].ToString();
        public static string Copyright = ConfigurationManager.AppSettings["Copyright"].ToString();
        public static string TaxRate = ConfigurationManager.AppSettings["TaxRate"].ToString();
        */
        public static string Company = "";
        public static string Street = "";
        public static string City = "";
        public static string State = "";
        public static string ZipCode = "";
        public static string Telephone = "";
        public static string Email = "";
        public static string Website = "";
        public static string Copyright = "";
        public static string TaxRate = "";
        
        //General
        public static string MsgBoxHead = ConfigurationManager.AppSettings["MsgBoxHead"].ToString();
        //------------------------------------------------------------------------------------------------------

        //Resources Folder - it has been replaced 
        //by InstalledDefaultPic
        private static string ResourcesFolder()
        {
            //Check this: http://weblogs.asp.net/cfrazier/archive/2005/07/18/419812.aspx 
            string path = Path.Combine(
                          Environment.GetFolderPath(
                          Environment.SpecialFolder.ProgramFiles),
                          Application.CompanyName);
            path = Path.Combine(path, Application.ProductName);
            path = Path.Combine(path, "Resources"); //Application sub-folder

            DirectoryInfo dirResourcesFolder = new DirectoryInfo(path);
            try
            {
                if (!dirResourcesFolder.Exists)
                    dirResourcesFolder.Create();

            }
            catch (IOException ioe)
            {
                throw ioe;
            }

            return path;

        }

        //company
        public static void setCompanyInfo()
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
                MessageBox.Show("Please Setup Your Company Information.", MsgBoxHead);
                return;
            }
            else
            {
                string Filename = @"" + Utilities.CompanyInfo + "\\company" + Utilities.Ext;
                StreamReader sr = new StreamReader(Filename);

                try
                {
                    //Company Information
                    Company = sr.ReadLine();
                    Street = sr.ReadLine();
                    City = sr.ReadLine();
                    State = sr.ReadLine();
                    ZipCode = sr.ReadLine();
                    Telephone = sr.ReadLine();
                    Email = sr.ReadLine();
                    Website = sr.ReadLine();
                    Copyright = sr.ReadLine();
                    TaxRate = sr.ReadLine();
                    //lblLastUpdate.Text = sr.ReadLine();

                }
                finally
                {
                    sr.Close();
                }
            }
        }

        //get default image
        public static void setDefaultPicture(string defaultpic)
        {
            //create location directory
            Directory.CreateDirectory(@"" + Utilities.Customers);

            //get installed default picture 
            FileInfo flePicture = new FileInfo(InstalledDefaultPic);

            //if picture don't exist copy it
            //from installed location 
            if (!File.Exists(defaultpic))
            {
                flePicture.CopyTo(defaultpic);
            }
        }

        //generate random number each time is been called
        //start at min and increment each call by to the max
        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        //Get entry date
        public static string EntryDate()
        {
            return (DateTime.Now.ToLongDateString() + ". " + DateTime.Now.ToLongTimeString());
        }
        //----------------------------------------------------------

        /*
        //Create default database file On start of the application this
        //will check for the file and it does not exist, it will create it

        //Create database default folder  
        private void CreateDefaultDbFolder()
        {
            DirectoryInfo dirFolder = new DirectoryInfo(HairSalonFolder);
            try
            {
                if (!dirFolder.Exists)
                    dirFolder.Create();
            }
            catch (IOException ioe)
            {
                throw ioe;
            }

        }
        */
        //--------------------------------------------------------------------

        public void CreateStatesTB()
        {
            Directory.CreateDirectory(@"" + HairSalonFolder);
            string strFilename = UStatesFile;

            XmlTextWriter xtw = null;
            if (!File.Exists(strFilename))
            {
                try
                {
                    xtw = new XmlTextWriter(strFilename, Encoding.UTF8);
                    xtw.Formatting = Formatting.Indented;
                    xtw.WriteStartDocument();
                    xtw.WriteStartElement("StatesTable");
                    xtw.WriteStartElement("StateRow");
                    xtw.WriteAttributeString("StateID", "1");
                    xtw.WriteAttributeString("Code", "AL");
                    xtw.WriteAttributeString("State", "Alabama");
                    xtw.WriteEndElement();
                    xtw.WriteEndDocument();

                    UStates();

                }
                catch (XmlException xe)
                {
                    throw xe;
                }
                finally
                {
                    xtw.Close();
                    BuildStates(strFilename);
                }

            }

        }

        private void BuildStates(string ustatesfile)
        {
            XmlGenericOps xop = new XmlGenericOps();
            DataSet ds = new DataSet();
            ds.ReadXml(ustatesfile);
            int id = 2;
            foreach (DictionaryEntry en in states)
            {
                DataRow dr;

                dr = ds.Tables[0].NewRow();

                dr["StateID"] = id;
                dr["Code"] = (string)en.Key;
                dr["State"] = (string)en.Value;
                ds.Tables[0].Rows.Add(dr);

                id++;
            }
            ds.WriteXml(ustatesfile);

        }

        Hashtable states = null;
        private void UStates()
        {
            states = new Hashtable();
            //states.Add("AL", "Alabama");
            states.Add("AK", "Alaska");
            states.Add("AZ", "Arizona");
            states.Add("AR", "Arkansas");
            states.Add("CA", "California");
            states.Add("CO", "Colorado");
            states.Add("CT", "Connecticut");
            states.Add("DE", "Delaware");
            states.Add("FL", "Florida");
            states.Add("GA", "Georgia");
            states.Add("HI", "Hawaii");
            states.Add("ID", "Idaho");
            states.Add("IL", "Illinois");
            states.Add("IN", "Indiana");
            states.Add("IA", "Iowa");
            states.Add("KS", "Kansas");
            states.Add("KY", "Kentucky");
            states.Add("LA", "Louisiana");
            states.Add("ME", "Maine");
            states.Add("MD", "Maryland");
            states.Add("MA", "Massachusetts");
            states.Add("MI", "Michigan");
            states.Add("MN", "Minnesota");
            states.Add("MS", "Mississippi");
            states.Add("MO", "Missouri");
            states.Add("MT", "Montana");
            states.Add("NE", "Nebraska");
            states.Add("NV", "Nevada");
            states.Add("NH", "New Hampshire");
            states.Add("NJ", "New Jersey");
            states.Add("NM", "New Mexico");
            states.Add("NY", "New York");
            states.Add("NC", "North Carolina");
            states.Add("ND", "North Dakota");
            states.Add("OH", "Ohio");
            states.Add("OK", "Oklahoma");
            states.Add("OR", "Oregon");
            states.Add("PA", "Pennsylvania");
            states.Add("RI", "Rhode Island");
            states.Add("SC", "South Carolina");
            states.Add("SD", "South Dakota");
            states.Add("TN", "Tennessee");
            states.Add("TX", "Texas");
            states.Add("UT", "Utah");
            states.Add("VT", "Vermont");
            states.Add("VA", "Virginia");
            states.Add("WA", "Washington");
            states.Add("WV", "West Virginia");
            states.Add("WI", "Wisconsin");
            states.Add("WY", "Wyoming");

        }
        //----------------------------------------------------------------

        //Export Report Data to Excel
        public static DataTable ExportReport()
        {
            //initilise table 
            DataTable tbl = new DataTable();
            DataColumn tc = null;
            DataRow tr = null;

            //create table columns
            tc = new DataColumn("Receipt #", Type.GetType("System.String"));
            tbl.Columns.Add(tc);
            tc = new DataColumn("Date", Type.GetType("System.String"));
            tbl.Columns.Add(tc);
            tc = new DataColumn("Customer", Type.GetType("System.String"));
            tbl.Columns.Add(tc);
            tc = new DataColumn("Telephone", Type.GetType("System.String"));
            tbl.Columns.Add(tc);
            tc = new DataColumn("Hair Style", Type.GetType("System.String"));
            tbl.Columns.Add(tc);
            tc = new DataColumn("Price", Type.GetType("System.String"));
            tbl.Columns.Add(tc);
            tc = new DataColumn("TaxRate %", Type.GetType("System.String"));
            tbl.Columns.Add(tc);
            tc = new DataColumn("TaxAmt", Type.GetType("System.String"));
            tbl.Columns.Add(tc);
            tc = new DataColumn("Total", Type.GetType("System.String"));
            tbl.Columns.Add(tc);
            tc = new DataColumn("AmtPaid", Type.GetType("System.String"));
            tbl.Columns.Add(tc);
            tc = new DataColumn("Balance", Type.GetType("System.String"));
            tbl.Columns.Add(tc);

            Dictionary<string, Receipt> lstReceipts = new Dictionary<string,Receipt>();
            BinaryFormatter bfmReceipts = new BinaryFormatter();
            Receipt rec = new Receipt();

            string strFilename = @"" + Receipts + "\\receipts" + Ext;

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
                foreach (KeyValuePair<string, Receipt> kvp in lstReceipts)
                {
                    rec = kvp.Value;
                    DateTime getDate = Convert.ToDateTime(rec.m_Date);

                    tr = tbl.NewRow();
                    tr["Receipt #"] = kvp.Key;
                    tr["Date"] = getDate.ToShortDateString();
                    tr["Customer"] = rec.m_Customer;
                    tr["Telephone"] = rec.m_Phone;
                    tr["Hair Style"] = rec.m_Style;
                    tr["Price"] = rec.m_Price;
                    tr["TaxRate %"] = rec.m_TaxRate;
                    tr["TaxAmt"] = rec.m_TaxAmt;
                    tr["Total"] = rec.m_SubTotal;
                    tr["AmtPaid"] = rec.m_AmtPaid;
                    tr["Balance"] = rec.m_Balance;
                    tbl.Rows.Add(tr);

                }

            }

            return tbl;
        }

        //Export Customers Data to Excel
        public static DataTable ExportCustomers()
        {
            //initilise table 
            DataTable tbl = new DataTable();
            DataColumn tc = null;
            DataRow tr = null;

            //create table columns
            tc = new DataColumn("Name", Type.GetType("System.String"));
            tbl.Columns.Add(tc);
            tc = new DataColumn("Telephone", Type.GetType("System.String"));
            tbl.Columns.Add(tc);
            tc = new DataColumn("Email", Type.GetType("System.String"));
            tbl.Columns.Add(tc);
            tc = new DataColumn("Street", Type.GetType("System.String"));
            tbl.Columns.Add(tc);
            tc = new DataColumn("City", Type.GetType("System.String"));
            tbl.Columns.Add(tc);
            tc = new DataColumn("State", Type.GetType("System.String"));
            tbl.Columns.Add(tc);
            tc = new DataColumn("Zip Code", Type.GetType("System.String"));
            tbl.Columns.Add(tc);

            Dictionary<string, Customer> lstCustomers = new Dictionary<string,Customer>();
            BinaryFormatter bfmCustomers = new BinaryFormatter();

            string strFilename = @"" + Customers + "\\customers" + Ext;

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
            if (lstCustomers.Count > 0)
            {
                foreach (KeyValuePair<string, Customer> kvp in lstCustomers)
                {
                    Customer cust = kvp.Value;
                    string cid = kvp.Key;
                    tr = tbl.NewRow();
                    tr["Name"] = cust.m_Name;
                    tr["Telephone"] = cust.m_Telephone;
                    tr["Email"] = cust.m_Email;
                    tr["Street"] = cust.m_Street;
                    tr["City"] = cust.m_City;
                    tr["State"] = cust.m_State;
                    tr["Zip Code"] = cust.m_ZipCode;
                    tbl.Rows.Add(tr);
                }
            }
            return tbl;
        }
        //---------------------------------------------------------------------

    }
}
