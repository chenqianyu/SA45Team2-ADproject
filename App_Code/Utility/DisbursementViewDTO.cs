using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Coding By Han Su Yin and Balaji
/// <summary>
/// Summary description for ViewClass
/// </summary>
public class DisbursementViewDTO
{
    //Hansu
    public string Item_Code;
    public string Item_Description;
    public int Requisition_No;
    public int QuantityToGiveOut;
    public int Employee_ID;
    public string Dept_ID;
    public string Dept_Name;
    public int Requested_Quantity;
    public int Actual_Quantity;
    public DateTime Retrieval_Date;
    //Balaji
    public int Retrieval_ID;
    public string Remarks;
    public DisbursementViewDTO()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string item_Code
    {
        get { return Item_Code; }
        set { Item_Code = value; }
    }
    public string item_Description
    {
        get { return Item_Description; }
        set { Item_Description = value; }
    }
    public int requisition_No
    {
        get { return Requisition_No; }
        set { Requisition_No = value; }
    }

    public int quantityToGiveOut
    {
        get { return QuantityToGiveOut; }
        set { QuantityToGiveOut = value; }
    }
    public int employee_ID
    {
        get { return Employee_ID; }
        set { Employee_ID = value; }
    }
    public string dept_ID
    {
        get { return Dept_ID; }
        set { Dept_ID = value; }
    }
    public string dept_Name
    {
        get { return Dept_Name; }
        set { Dept_Name = value; }
    }

    public int requested_Quantity
    {
        get { return Requested_Quantity; }
        set { Requested_Quantity = value; }
    }

    public int actual_Quantity
    {
        get { return Actual_Quantity; }
        set { Actual_Quantity = value; }
    }

    public DateTime retrieval_Date
    {
        get { return Retrieval_Date; }
        set { Retrieval_Date = value; }
    }

    public int retrieval_Id
    {
        get { return Retrieval_ID; }
        set { Retrieval_ID = value; }
    }

    public string remarks
    {
        get { return Remarks; }
        set { Remarks = value; }
    }
}