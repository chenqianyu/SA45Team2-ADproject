using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DisbursementViewDAO
/// </summary>
public class DisbursementViewDAO
{
    
    public DisbursementViewDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /*
* Balaji's Codes Start
*/


    public static List<int> GetRequisitionNoByItemNoAndRetrievalID(string itemno, int rtrid)
    {
        Model entities = new Model();
        return entities.DisbursementViews.Where(x => x.Item_No == itemno && x.Retrieval_ID == rtrid).OrderByDescending(x => x.Approval_Timestamp).Select(x => x.Requisition_No).ToList<int>();

    }


    public static List<DisbursementViewDTO> GetDisbursementViewByRetrievalID(int rtr)
    {
        Model entities = new Model();
        return entities.DisbursementViews.Where(x => x.Retrieval_ID == rtr).GroupBy(x => new { x.Item_No, x.Description, x.Retrieval_ID }).Select(y => new DisbursementViewDTO { item_Code = y.Key.Item_No, item_Description = y.Key.Description, retrieval_Id = y.Key.Retrieval_ID, quantityToGiveOut = y.Sum(g => g.QuantityToGiveOut) }).ToList();


    }

    public static List<DisbursementViewDTO> GetDisbursementViewByRetrievalIDAndItemNo(int rtr, string itemno)
    {
        Model entities = new Model();
        return entities.DisbursementViews.Where(x => x.Retrieval_ID == rtr).GroupBy(x => new { x.Item_No, x.Description, x.Department_Name }).Where(x => x.Key.Item_No == itemno).Select(y => new DisbursementViewDTO { item_Code = y.Key.Item_No, item_Description = y.Key.Description, dept_Name = y.Key.Department_Name, quantityToGiveOut = y.Sum(g => g.QuantityToGiveOut) }).ToList();


    }


    public static List<DisbursementViewDTO> list3(int rtr)
    {
        Model entities = new Model();
        return entities.DisbursementViews.Where(x => x.Retrieval_ID == rtr).GroupBy(x => new { x.Item_No, x.Description, x.Retrieval_ID }).Select(y => new DisbursementViewDTO { item_Code = y.Key.Item_No, item_Description = y.Key.Description, retrieval_Id = y.Key.Retrieval_ID, quantityToGiveOut = y.Sum(g => g.QuantityToGiveOut) }).ToList();


    }
    /*
    * Balaji's Codes End
    */

}