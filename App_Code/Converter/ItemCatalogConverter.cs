using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ItemCatalogConverter
/// </summary>
public class ItemCatalogConverter
{
    public ItemCatalogConverter()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    

    public static WCFItemCatalog changeItemCatalogToWCFItemCatalog(ItemCatalog ic)
    {
        return WCFItemCatalog.Make(ic.Item_No,
    ic.Category,
    ic.Description,
    ic.Reorder_Lvl,
    ic.Reorder_Qty,
    ic.Unit_of_Measure,
    ic.Total_Qty,
    ic.Price,
    ic.Allocated_Qty,
    ic.Ordered_Qty);

    }

    public static List<WCFItemCatalog> changeItemCatalogListToWCFItemCatalogList(List<ItemCatalog> icList)
    {

        List<WCFItemCatalog> wcfICList = new List<WCFItemCatalog>();
        foreach (ItemCatalog ic in icList)
        {
            WCFItemCatalog wcfIC = WCFItemCatalog.Make(ic.Item_No,
    ic.Category,
    ic.Description,
    ic.Reorder_Lvl,
    ic.Reorder_Qty,
    ic.Unit_of_Measure,
    ic.Total_Qty,
    ic.Price,
    ic.Allocated_Qty,
    ic.Ordered_Qty);
            wcfICList.Add(wcfIC);
        }
        return wcfICList;
    }

}