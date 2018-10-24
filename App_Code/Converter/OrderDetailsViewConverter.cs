using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrderDetailsViewConverter
/// </summary>
public class OrderDetailsViewConverter
{
    public OrderDetailsViewConverter()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static List<WCFOrderDetailsView> ChangevDTOListToWCFdvDTOList(List<OrderDetailsView> oderDetailsList)
    {

        List<WCFOrderDetailsView> wcfODList = new List<WCFOrderDetailsView>();
        foreach (OrderDetailsView odv in oderDetailsList)
        {
            WCFOrderDetailsView wcfDV = WCFOrderDetailsView.Make(odv.Item_No, odv.Description, odv.Price, odv.Supplier_Name, odv.Ordered_Qty, odv.PO_No);
            wcfODList.Add(wcfDV);
        }
        return wcfODList;
    }
}