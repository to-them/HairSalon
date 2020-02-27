using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HairSalon
{
    [Serializable]
    public class Report
    {
        public string m_ReportID;
        public string m_TotalPrice;
        public string m_TotalAmtPaid;
        public string m_TotalBalance;
        public string m_TotalTaxAmt;
        public string m_ReportDate;

        public Report()
        {
            m_ReportID = "";
            m_TotalPrice = "";
            m_TotalAmtPaid = "";
            m_TotalBalance = "";
            m_TotalTaxAmt = "";
            m_ReportDate = "";
        }

        public Report(string reportid, string balance, string totalprice, string totalamtpaid, 
            string totalbalance, string totaltaxamt, string reportdate)
        {
            m_ReportID = reportid;
            m_TotalPrice = totalprice;
            m_TotalAmtPaid = totalamtpaid;
            m_TotalBalance = totalbalance;
            m_TotalTaxAmt = totaltaxamt;
            m_ReportDate = reportdate;
        }

    }
}
