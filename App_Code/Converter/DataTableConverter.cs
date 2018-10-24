using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataTableConverter
/// </summary>
public class DataTableConverter
{
    public DataTableConverter()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static List<WCFDataTable> ChangeDTToWcfDT(DataTable dataTable)
    {
        List<WCFDataTable> list = new List<WCFDataTable>();
        WCFDataTable wcfDataTable;
        foreach (DataRow row in dataTable.Rows)
        {
            string itemNO =Convert.ToString( row["Item Number"]);
            string description = Convert.ToString(row["Description"]);
            string quantityAssigned = Convert.ToString(row["Quantity Assigned"]);
            wcfDataTable = WCFDataTable.Make(itemNO, description, quantityAssigned);
            list.Add(wcfDataTable);
        }

        return list;
    }
}