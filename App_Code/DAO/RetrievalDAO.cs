using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RetrievalDAO
/// </summary>
public class RetrievalDAO
{
    public RetrievalDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /*
     * Keoh's codes starts
     */

    /// <summary>
    /// Returns the next retrieval number yet to be executed
    /// </summary>
    /// <returns></returns>
    public static int GetLatestRetrievalNumber()
    {
        Model entities = new Model();
        return entities.Retrievals.OrderByDescending(x => x.Retrieval_ID).First().Retrieval_ID;
    }

    /// <summary>
    /// Takes a list of RetrievalItems and add it into the database
    /// </summary>
    /// <param name="newRetrievalItems"></param>
    public static void AddToList(List<RetrievalItem> newRetrievalItems)
    {
        Model entities = new Model();
        entities.RetrievalItems.AddRange(newRetrievalItems);
    }

    /// <summary>
    /// Returns a list of RetrievalItems based on requisition number given
    /// </summary>
    /// <param name="requisitionNumber"></param>
    /// <returns></returns>
    public static List<RetrievalItem> ListItemByRequisitionNumber(int requisitionNumber)
    {
        Model entities = new Model();
        return entities.RetrievalItems.Where(x => x.Requisition_No == requisitionNumber).ToList();
    }

    /// <summary>
    /// Save changes made into database
    /// </summary>
    public static void SaveChanges()
    {
        Model entities = new Model();
        entities.SaveChanges();
    }
    /*
     * Keoh's codes ends
     */


    /*
    * Balaji's codes starts
    */
    public static void ReduceItemTotalQty(string itemno)
    {
        Model entities = new Model();


        SA45Team02_SSIS.ItemCatalog ic = entities.ItemCatalogs.Where(x => x.Item_No == itemno).First();
        ic.Total_Qty = ic.Total_Qty - ic.Allocated_Qty;
        ic.Allocated_Qty = 0;
        entities.SaveChanges();

    }
    public static int GetMaxRetrieval()
    {
        Model entities = new Model();
        return entities.Retrievals.Max(x => x.Retrieval_ID);

    }

    public static void UpdateRetrieval(int retid)
    {
        Model entities = new Model();
        Retrieval rtr = entities.Retrievals.Where(x => x.Retrieval_ID == retid).First();
        rtr.Retrieval_Date = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
        entities.SaveChanges();


    }
    public static void AddNewRetrieval(int retid)
    {
        Model entities = new Model();
        Retrieval rtr = new Retrieval();

        rtr.Retrieval_ID = retid;
        rtr.Retrieval_Date = null;
        entities.Retrievals.Add(rtr);
        entities.SaveChanges();

    }

  

    public static void ReduceAllocatedQuantity(string itemno, int adjustment)
    {
        Model entities = new Model();
        SA45Team02_SSIS.ItemCatalog ic = entities.ItemCatalogs.Where(x => x.Item_No == itemno).First();
        ic.Allocated_Qty = ic.Allocated_Qty - adjustment;
        ic.Total_Qty = ic.Total_Qty - adjustment;
        entities.SaveChanges();


    }

    public static void IncreaseAllocatedQuantity(string itemno, int adjustment)
    {
        Model entities = new Model();
        SA45Team02_SSIS.ItemCatalog ic = entities.ItemCatalogs.Where(x => x.Item_No == itemno).First();
        ic.Allocated_Qty = ic.Allocated_Qty + adjustment;
        ic.Total_Qty = ic.Total_Qty + adjustment;
        entities.SaveChanges();


    }

   
    public static void SaveChanges(RequisitionItem reqi, RetrievalItem ri, int reqno, string itemno, int maxrtrid)
    {
        Model entities = new Model();
        RequisitionItem reqi1 = entities.RequisitionItems.Where(x => x.Requisition_No == reqno && x.Item_No == itemno).First();
        reqi1.Status = reqi.Status;
        reqi1.Actual_Qty = reqi.Actual_Qty;
        RetrievalItem ri1 = entities.RetrievalItems.Where(x => x.Requisition_No == reqno && x.Retrieval_ID == maxrtrid && x.Item_No == itemno).First();
        ri1.QuantityToGiveOut = ri.QuantityToGiveOut;
        entities.SaveChanges();

    }
    public static RetrievalItem GetMaxRetrievalByReqNoAndItemNo(int reqno, string itemno, int maxrtrid)
    {
        Model entities = new Model();
        return entities.RetrievalItems.Where(x => x.Requisition_No == reqno && x.Retrieval_ID == maxrtrid && x.Item_No == itemno).First();

    }

   

   

    

    public static List<int> GetRetrievalIDListLessThanMaxRetrievalId(int maxrtr)
    {
        Model entities = new Model();
        return entities.Retrievals.Where(x => x.Retrieval_ID < maxrtr).Select(x => x.Retrieval_ID).ToList();

    }

    public static decimal GetPriceByItemNO(string itemno)
    {
        Model entities = new Model();
        return entities.SupplierItems.Where(x => x.Item_No == itemno && x.PreferenceRank == 1).Select(x => x.Price).First();

    }
    /*
    * Balaji's codes ends
    */


    /*
   * Jerry's codes starts
   */
    public static void EditRetriveItem(string item_No, int requisition_No, int number)
    {
        Model entities = new Model();
        RetrievalItem something = entities.RetrievalItems.Where(x => x.Item_No == item_No && x.Requisition_No == requisition_No).First();
        something.QuantityToGiveOut = number;
        entities.SaveChanges();
    }


    /*
   * Jerry's codes ends
   */
}