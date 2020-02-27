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
    public partial class Reports : Form
    {
        int iFilename;
        bool IsNewOrder;
        string Filename;

        double Price = 0.00;
        double TaxAmt = 0.00;
        double AmtPaid = 0.00;
        double Balance = 0.00;
        Dictionary<string, Receipt> lstReceipts;

        public Reports()
        {
            InitializeComponent();
            this.Text = Utilities.Company + " - Receipts";
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            ExportToExcel();
            ShowReport();
        }

        //Export Reports data to excel
        private void ExportToExcel()
        {
            try
            {
                string fpath = Utilities.ExcelReports;

                // Specify the column list to export
                int[] iColumns = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

                // Export the details of specified columns to CSV
                RKLib.ExportData.Export objExport = new Export("Win");
                objExport.ExportDetails(Utilities.ExportReport(), iColumns, Export.ExportFormat.Excel, fpath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, Utilities.MsgBoxHead);
            }

        }

        private void ShowReport()
        {
            lstReceipts = new Dictionary<string, Receipt>();
            BinaryFormatter bfmReceipts = new BinaryFormatter();
            Receipt rec = new Receipt();

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
                lvwReports.Items.Clear();

                foreach (KeyValuePair<string, Receipt> kvp in lstReceipts)
                {
                    ListViewItem lvi = new ListViewItem(kvp.Key);
                    rec = kvp.Value;
                    DateTime getDate = Convert.ToDateTime(rec.m_Date);
                    lvi.SubItems.Add(getDate.ToShortDateString());
                    lvi.SubItems.Add(rec.m_Customer);
                    lvi.SubItems.Add(rec.m_Style);
                    lvi.SubItems.Add(rec.m_Price);
                    lvi.SubItems.Add(rec.m_TaxAmt);
                    lvi.SubItems.Add(rec.m_AmtPaid);
                    lvi.SubItems.Add(rec.m_Balance);

                    if (i % 2 == 0)
                    {
                        lvi.BackColor = Color.FromArgb(255, 128, 0);
                        lvi.ForeColor = Color.White;
                    }
                    else
                    {
                        lvi.BackColor = Color.FromArgb(128, 64, 64);
                        lvi.ForeColor = Color.White;
                    }

                    lvwReports.Items.Add(lvi);

                    //Calculate Year to Date
                    Price += double.Parse(rec.m_Price);
                    TaxAmt += double.Parse(rec.m_TaxAmt);
                    AmtPaid += double.Parse(rec.m_AmtPaid);
                    Balance += double.Parse(rec.m_Balance);

                    i++;

                }

                lblTotalPrice.Text = Price.ToString("F");
                lblTotalTaxAmt.Text = TaxAmt.ToString("F");
                lblTotalAmtPaid.Text = AmtPaid.ToString("F");
                lblTotalBalance.Text = Balance.ToString("F");
            }
            else
                return;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFriendlyPrint_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Utilities.ExcelReports);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, Utilities.MsgBoxHead);
            }
        }


    }
}
