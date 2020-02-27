using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ayitech_Lib;
using AllPurpose_Lib;

namespace HairSalon
{
    public partial class StateLookup : Form
    {
        public StateLookup()
        {
            InitializeComponent();
        }

        //Ref: http://www.akadia.com/services/dotnet_listview_sort_dataset.html
        private void StateLookup_Load(object sender, EventArgs e)
        {
            Utilities ut = new Utilities();
            ut.CreateStatesTB();
            BuildList();
        }

        internal void BuildList()
        {
            XmlGenericOps xop = new XmlGenericOps();
            DataSet ds = new DataSet();
            ds = xop.PopulateFile(Utilities.UStatesFile);
            lvwUStates.Items.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ListViewItem lvi = new ListViewItem(dr["Code"].ToString());
                lvi.SubItems.Add(dr["State"].ToString());
                lvwUStates.Items.Add(lvi);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
