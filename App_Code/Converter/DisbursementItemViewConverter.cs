using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DisbursementItemViewConverter
/// </summary>
public class DisbursementItemViewConverter
{
    public DisbursementItemViewConverter()
    {
        //
        // TODO: Add constructor logic here
        //
    }

  
   
  
 
    public static WCFDisbursementItemView ChangeDbiViewToWcfDbiView(DisbursementItemView dbiView)
    {
        return WCFDisbursementItemView.Make(dbiView.Item_No, dbiView.Description, dbiView.Department_Name,
            dbiView.Requisition_No, dbiView.collectionPoint, dbiView.Employee_Name, dbiView.QuantityToGiveOut,
            Convert.ToString(dbiView.Disbursement_Date), dbiView.Disbursement_Status, dbiView.Retrieval_ID);
    }
}