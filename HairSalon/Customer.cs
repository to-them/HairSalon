using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HairSalon
{
    [Serializable]
    public class Customer
    {
        public string m_CustomerID;
        public string m_Name;
        public string m_Telephone;
        public string m_Email;
        public string m_Street;
        public string m_City;
        public string m_State;
        public string m_ZipCode;
        public string m_Picture;

        public Customer()
        {
            m_CustomerID = "";
            m_Name = "";
            m_Telephone = "";
            m_Email = "";
            m_Street = "";
            m_City = "";
            m_State = "";
            m_ZipCode = "";
            m_Picture = "";
        }

        public Customer(string customerid, string name, string telephone, string email, string street, string city, string state, string zip, string picture)
        {
            m_CustomerID = customerid;
            m_Name = name;
            m_Telephone = telephone;
            m_Email = email;
            m_Street = street;
            m_City = city;
            m_State = state;
            m_ZipCode = zip;
            m_Picture = picture;
        }

    }
}
