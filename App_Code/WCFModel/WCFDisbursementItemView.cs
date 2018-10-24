using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for WCFDisbursementItemView
/// </summary>
public class WCFDisbursementItemView
{
    public static WCFDisbursementItemView Make(string itemNo,
    string description,
    string departmentName,
    int requisitionNo,
    string collectionPoint,
    string employeeName,
    int quantityToGiveOut,
    string disbursementDate,
    string disbursementStatus,
    int retrievalId)
    {
        WCFDisbursementItemView c = new WCFDisbursementItemView();
        c.ItemNo = itemNo;
        c.Description = description;
        c.DepartmentName = departmentName;
        c.Requisition_No = requisitionNo;
        c.CollectionPoint = collectionPoint;
        c.Employee_Name = employeeName;
        c.QuantityToGiveOut = quantityToGiveOut;
        c.Disbursement_Date = disbursementDate;
        c.Disbursement_Status = disbursementStatus;
        c.Retrieval_ID = retrievalId;

        return c;
    }

    string itemNo;
    string description;
    string departmentName;
    int requisition_No;
    string collectionPoint;
    string employee_Name;
    int quantityToGiveOut;
    string disbursement_Date;
    string disbursement_Status;
    int retrieval_ID;

    public string ItemNo
    {
        get
        {
            return itemNo;
        }

        set
        {
            itemNo = value;
        }
    }

    public string Description
    {
        get
        {
            return description;
        }

        set
        {
            description = value;
        }
    }

    public string DepartmentName
    {
        get
        {
            return departmentName;
        }

        set
        {
            departmentName = value;
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

    public string CollectionPoint
    {
        get
        {
            return collectionPoint;
        }

        set
        {
            collectionPoint = value;
        }
    }

    public string Employee_Name
    {
        get
        {
            return employee_Name;
        }

        set
        {
            employee_Name = value;
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

    public string Disbursement_Date
    {
        get
        {
            return disbursement_Date;
        }

        set
        {
            disbursement_Date = value;
        }
    }

    public string Disbursement_Status
    {
        get
        {
            return disbursement_Status;
        }

        set
        {
            disbursement_Status = value;
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
}