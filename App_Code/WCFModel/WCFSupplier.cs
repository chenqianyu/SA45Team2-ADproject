using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for WCFSupplier
/// </summary>
[DataContract]
public class WCFSupplier
{
    public static WCFSupplier Make(string supplier_ID,
    string supplier_Name,
    string contact_Name,
    int phone,
    string address,
    string email)
    {
        WCFSupplier c = new WCFSupplier();
        c.Supplier_ID = supplier_ID;
        c.Supplier_Name = supplier_Name;
        c.Contact_Name = contact_Name;
        c.Phone = phone;
        c.Address = address;
        c.Email = email;
        return c;
    }

    string supplier_ID;
    string supplier_Name;
    string contact_Name;
    int phone;
    string address;
    string email;

    [DataMember]
    public string Supplier_ID
    {
        get
        {
            return supplier_ID;
        }

        set
        {
            supplier_ID = value;
        }
    }

    [DataMember]
    public string Supplier_Name
    {
        get
        {
            return supplier_Name;
        }

        set
        {
            supplier_Name = value;
        }
    }

    [DataMember]
    public string Contact_Name
    {
        get
        {
            return contact_Name;
        }

        set
        {
            contact_Name = value;
        }
    }

    [DataMember]
    public int Phone
    {
        get
        {
            return phone;
        }

        set
        {
            phone = value;
        }
    }

    [DataMember]
    public string Address
    {
        get
        {
            return address;
        }

        set
        {
            address = value;
        }
    }

    [DataMember]
    public string Email
    {
        get
        {
            return email;
        }

        set
        {
            email = value;
        }
    }
}