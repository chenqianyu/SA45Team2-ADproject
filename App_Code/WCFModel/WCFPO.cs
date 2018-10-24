using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for WCFPO
/// </summary>
[DataContract]
public class WCFPO
{
    public static WCFPO Make(int po_no,
    string supplier_id,
    int employee_id,
    string po_date,
    string approval_date,
    int approved_by,
    string expected_delivery_date,
    string actual_delivery_date,
    string remarks)
    {
        WCFPO c = new WCFPO();
        c.Po_no = po_no;
        c.Supplier_id = supplier_id;
        c.Employee_id = employee_id;
        c.Po_date = po_date;
        c.Approval_date = approval_date;
        c.Approved_by = approved_by;
        c.Expected_delivery_date = expected_delivery_date;
        c.Actual_delivery_date = actual_delivery_date;
        c.Remarks = remarks;
        return c;
    }
    int po_no;
    string supplier_id;
    int employee_id;
    string po_date;
    string approval_date;
    int approved_by;
    string expected_delivery_date;
    string actual_delivery_date;
    string remarks;

    [DataMember]
    public int Po_no
    {
        get
        {
            return po_no;
        }

        set
        {
            po_no = value;
        }
    }

    [DataMember]
    public string Supplier_id
    {
        get
        {
            return supplier_id;
        }

        set
        {
            supplier_id = value;
        }
    }

    [DataMember]
    public int Employee_id
    {
        get
        {
            return employee_id;
        }

        set
        {
            employee_id = value;
        }
    }

    [DataMember]
    public string Po_date
    {
        get
        {
            return po_date;
        }

        set
        {
            po_date = value;
        }
    }

    [DataMember]
    public string Approval_date
    {
        get
        {
            return approval_date;
        }

        set
        {
            approval_date = value;
        }
    }

    [DataMember]
    public int Approved_by
    {
        get
        {
            return approved_by;
        }

        set
        {
            approved_by = value;
        }
    }

    [DataMember]
    public string Expected_delivery_date
    {
        get
        {
            return expected_delivery_date;
        }

        set
        {
            expected_delivery_date = value;
        }
    }

    [DataMember]
    public string Actual_delivery_date
    {
        get
        {
            return actual_delivery_date;
        }

        set
        {
            actual_delivery_date = value;
        }
    }

    [DataMember]
    public string Remarks
    {
        get
        {
            return remarks;
        }

        set
        {
            remarks = value;
        }
    }
}