using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for WCFDisbursementViewDTO
/// </summary>
public class WCFDisbursementViewDTO
{
     string item_Code;
     string item_Description;
     int requisition_No;
     int quantityToGiveOut;
     int employee_ID;
     string dept_ID;
     string dept_Name;
     int requested_Quantity;
     int actual_Quantity;
     string retrieval_Date;
     int retrieval_ID;
     string remarks;

    public static WCFDisbursementViewDTO Make(string item_Code,
string item_Description,
int requisition_No,
int quantityToGiveOut,
int employee_ID,
string dept_ID,
string dept_Name,
int requested_Quantity,
int actual_Quantity,
DateTime retrieval_Date,
int retrieval_ID,
string remarks)
    {
        WCFDisbursementViewDTO c = new WCFDisbursementViewDTO();
        c.Item_Code = item_Code;
        c.Item_Description = item_Description;
        c.Requisition_No = requisition_No;
        c.QuantityToGiveOut = quantityToGiveOut;
        c.Employee_ID = employee_ID;
        c.Dept_ID = dept_ID;
        c.Dept_Name = dept_Name;
        c.Requested_Quantity = requested_Quantity;
        c.Actual_Quantity = actual_Quantity;
        c.Retrieval_Date = retrieval_Date.ToString();
        c.Retrieval_ID = retrieval_ID;




        return c;
    }

    public string Item_Code
    {
        get
        {
            return item_Code;
        }

        set
        {
            item_Code = value;
        }
    }

    public string Item_Description
    {
        get
        {
            return item_Description;
        }

        set
        {
            item_Description = value;
        }
    }

    public int Requisition_No
    {
        get
        {
            return requisition_No;
        }

        set
        {
            requisition_No = value;
        }
    }

    public int QuantityToGiveOut
    {
        get
        {
            return quantityToGiveOut;
        }

        set
        {
            quantityToGiveOut = value;
        }
    }

    public int Employee_ID
    {
        get
        {
            return employee_ID;
        }

        set
        {
            employee_ID = value;
        }
    }

    public string Dept_ID
    {
        get
        {
            return dept_ID;
        }

        set
        {
            dept_ID = value;
        }
    }

    public string Dept_Name
    {
        get
        {
            return dept_Name;
        }

        set
        {
            dept_Name = value;
        }
    }

    public int Requested_Quantity
    {
        get
        {
            return requested_Quantity;
        }

        set
        {
            requested_Quantity = value;
        }
    }

    public int Actual_Quantity
    {
        get
        {
            return actual_Quantity;
        }

        set
        {
            actual_Quantity = value;
        }
    }

    public string Retrieval_Date
    {
        get
        {
            return retrieval_Date;
        }

        set
        {
            retrieval_Date = value;
        }
    }

    public int Retrieval_ID
    {
        get
        {
            return retrieval_ID;
        }

        set
        {
            retrieval_ID = value;
        }
    }

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