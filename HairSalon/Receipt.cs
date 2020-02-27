using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HairSalon
{
    [Serializable]
    public class Receipt
    {
        public string m_ReceiptNum;
        public string m_Date;
        public string m_Customer;
        public string m_Phone;
        public string m_Style;
        public string m_Price;
        public string m_TaxRate;
        public string m_TaxAmt;
        public string m_SubTotal;
        public string m_AmtPaid;
        public string m_Balance;
        

        public Receipt()
        {
            m_ReceiptNum = "";
            m_Date = "";
            m_Customer = "";
            m_Phone = "";
            m_Style = "";
            m_Price = "";
            m_TaxRate = "";
            m_TaxAmt = "";
            m_SubTotal = "";
            m_AmtPaid = "";
            m_Balance = "";
            
        }

        public Receipt(string receiptnum, string date, string customer, string phone, string style, string price, 
            string taxrate, string taxamt, string subtotal, string amtpaid, string balance)
        {
            m_ReceiptNum = receiptnum;
            m_Date = date;
            m_Customer = customer;
            m_Phone = phone;
            m_Style = style;
            m_Price = price;
            m_TaxRate = taxrate;
            m_TaxAmt = taxamt;
            m_SubTotal = subtotal;
            m_AmtPaid = amtpaid;
            m_Balance = balance;
        }

    }
}
