using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PurchaseOrderConverter
/// </summary>
public class PurchaseOrderConverter
{
    public PurchaseOrderConverter()
    {
        //
        // TODO: Add constructor logic here
        //
    }
   


    public static List<WCFPO> ChangePOListToWCFPOList(List<PurchaseOrder> poList)
    {

        List<WCFPO> wcfPOList = new List<WCFPO>();
        foreach (PurchaseOrder po in poList)
        {

            WCFPO wcfPO = WCFPO.Make(po.PO_No, po.Supplier_ID, po.Employee_ID, Convert.ToString(po.PO_Date),
                Convert.ToString(po.Approval_Date),Convert.ToInt32( po.Approved_By),Convert.ToString(po.Expected_Delivery_Date),Convert.ToString( po.Actual_Delivery_Date),
                po.Remarks);
            wcfPOList.Add(wcfPO);
        }
        return wcfPOList;
    }

    public static WCFPO ChangePOToWCFPO(PurchaseOrder po)
    {
        return WCFPO.Make(po.PO_No, po.Supplier_ID, po.Employee_ID, Convert.ToString(po.PO_Date),
                  Convert.ToString(po.Approval_Date), Convert.ToInt32(po.Approved_By), Convert.ToString(po.Expected_Delivery_Date), Convert.ToString(po.Actual_Delivery_Date),
                  po.Remarks);
    }

    public static PurchaseOrder ChangeWCFPOToPO(WCFPO wcfPO)
    {
        PurchaseOrder po = new PurchaseOrder();
        po.PO_No = wcfPO.Po_no;
        po.Supplier_ID = wcfPO.Supplier_id;
        po.Employee_ID = wcfPO.Employee_id;
        po.PO_Date =Convert.ToDateTime( wcfPO.Po_date);
        po.Approval_Date = Convert.ToDateTime(wcfPO.Approval_date);
        po.Approved_By = wcfPO.Approved_by;
        po.Expected_Delivery_Date =Convert.ToDateTime( wcfPO.Expected_delivery_date);
        po.Actual_Delivery_Date = Convert.ToDateTime(wcfPO.Actual_delivery_date);
        po.Remarks = wcfPO.Remarks;
        return po;
    }

}