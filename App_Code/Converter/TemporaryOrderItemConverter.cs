using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TemporaryOrderItemConverter
/// </summary>
public class TemporaryOrderItemConverter
{
    public TemporaryOrderItemConverter()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static List<WCFTemporaryOrderItem> ChangeTempOIListToWCFTempOIList(List<TemporaryOrderItem> tempOIList)
    {

        List<WCFTemporaryOrderItem> wcfTempOIList = new List<WCFTemporaryOrderItem>();
        foreach (TemporaryOrderItem temp in tempOIList)
        {

            WCFTemporaryOrderItem wcfTemp = WCFTemporaryOrderItem.Make(temp.ItemNo, temp.ItemDescription, temp.SupplierID, temp.SupplierName, temp.Qty, Convert.ToString(temp.ExceptedDeliveryDate), temp.Remark);
            wcfTempOIList.Add(wcfTemp);
        }
        return wcfTempOIList;
    }
}