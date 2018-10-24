using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DisbursementDAO
/// </summary>
public class DisbursementDAO
{
    
    public DisbursementDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /*
* HanSu's codes starts
*/
    //1.get Latest RetrievalID
    public static int GetLatestRetrivalID()
    {
        Model entities = new Model();
        return entities.DisbursementViews.Where(w => w.Retrieval_Date != null).OrderByDescending(b => b.Retrieval_ID).Select(b => b.Retrieval_ID).FirstOrDefault();
    }

    //2.get Disbursement List for Each Department ViewClass Type
    public static List<DisbursementViewDTO> GetAllDisbursementListByDep1(int lateRetrieveID, string depID)
    {
        Model entities = new Model();

        var item = from dv in entities.DisbursementViews
                   join
ri in entities.RetrievalItems on new { dv.Requisition_No, dv.Item_No, dv.Retrieval_ID } equals new { ri.Requisition_No, ri.Item_No, ri.Retrieval_ID }
                   where dv.Retrieval_ID == lateRetrieveID
                   where ri.Disbursement_Status != Utility.Acknowledged
                   where dv.Department_ID == depID
                   select new DisbursementViewDTO
                   {
                       Retrieval_ID = dv.Retrieval_ID,
                       Requisition_No = dv.Requisition_No,
                       Item_Code = dv.Item_No,
                       Item_Description = dv.Description,
                       QuantityToGiveOut = dv.QuantityToGiveOut
                   };

        return item.GroupBy(x => new { x.Item_Code, x.Item_Description }).
            Select(y => new DisbursementViewDTO
            {
                Retrieval_ID = 0,
                Requisition_No = 0,
                Item_Code = y.Key.Item_Code,
                Item_Description = y.Key.Item_Description,
                QuantityToGiveOut = y.Sum(g => g.QuantityToGiveOut)
            }).ToList();
    }

    //3.get Disbursement List for Each Department DisbursementView(View) Type
    public static List<DisbursementView> GetAllDisbursementListByDep2(int lateRetrieveID, string depID)
    {
        Model entities = new Model();
        return entities.DisbursementViews.Where(x => x.Department_ID == depID).Where(y => y.Retrieval_ID == lateRetrieveID).ToList<DisbursementView>();
    }

    //4.get the Retrieval_Item List from Requisition Number
    public static List<RetrievalItem> GetRetrievalItemListByRequisitionNo(int retrieveID, int requisitionNo, Model entities)
    {
        return entities.RetrievalItems.Where(x => x.Retrieval_ID == retrieveID).Where(x => x.Requisition_No == requisitionNo).ToList<RetrievalItem>();
    }

    //5. get Retrieval_Item List with Latest Retrieval ID and Disbursement Status ="Acknowledged"
    public static List<RetrievalItem> GetAcknowledgedRetrievalItem(int lateRetrieveID)
    {
        Model entities = new Model();
        return entities.RetrievalItems.Where(x => x.Retrieval_ID == lateRetrieveID && x.Disbursement_Status == "Acknowledged").ToList();

    }

    //6.Update Disbursement Status And Date When Click "Acknowledge" button (using 2, 4 & 5 method)
    public static void UpdateForDisbursementStatusAndDate(string depID)
    {
        Model entities = new Model();
        List<DisbursementView> getDisbursementList = GetAllDisbursementListByDep2(GetLatestRetrivalID(), depID);
        foreach (DisbursementView list in getDisbursementList)
        {
            List<RetrievalItem> retrievalItemListByRequisitionNo = GetRetrievalItemListByRequisitionNo(list.Retrieval_ID, list.Requisition_No, entities);
            foreach (RetrievalItem list2 in retrievalItemListByRequisitionNo)
            {
                list2.Disbursement_Status = Utility.Acknowledged;
                list2.Disbursement_Date = DateTime.Now;
                entities.SaveChanges();
            }
        }
    }

    //7.Update Status For the Complete Request When Clicking the "Acknowledge" Button(using 2 & 6 Mehtod)
    public static void UpdateStatusForCompletedRequest()
    {
        Model entities = new Model();
        bool update = true;
        List<RetrievalItem> acknowledgedList = GetAcknowledgedRetrievalItem(GetLatestRetrivalID());
        foreach (RetrievalItem acList in acknowledgedList)
        {
            List<RequisitionItem> ritemList = entities.RequisitionItems.Where(x => x.Requisition_No == acList.Requisition_No).ToList();
            foreach (RequisitionItem ritem in ritemList)
            {
                if (ritem.Status == "Unfulfilled")
                {
                    update = false;
                    break;
                }
                update = true;
            }
            if (update)
            {
                Requisition r = entities.Requisitions.Where(x => x.Requisition_No == acList.Requisition_No).FirstOrDefault();
                r.Status = "Completed";
                entities.SaveChanges();
            }
        }
    }
    /*
* HanSu's codes ends
*/


    /*
* Jerry's codes starts
*/
    public static List<DisbursementItemView> SelectByDepartment(String Department)
    {
        Model entities = new Model();
        return entities.DisbursementItemViews.Where(x => x.Department_Name == Department).ToList();
    }
  
   
    
    public static DisbursementItemView ViewDisbursementByDep(string DepartmentName)
    {
        Model entities = new Model();
        return entities.DisbursementItemViews.Where(x => x.Department_Name == DepartmentName).FirstOrDefault();
        throw new KeyNotFoundException("there is not any retrieve");
    }
    public static DataTable ViewDisbursementItem(string DepartmentName)
    {
        Model entities = new Model();
        var DataTable = entities.DisbursementItemViews.Where(x => x.Department_Name == DepartmentName && x.Disbursement_Date == null).Select(x => new { x.Description, x.QuantityToGiveOut }).ToList();
        DataTable a = new DataTable();
        a.Columns.Add("Description", typeof(string));
        a.Columns.Add("QuantityToGive", typeof(int));
        for (int i = 0; i < DataTable.Count; i++)
        {
            a.Rows.Add(DataTable[i].Description, DataTable[i].QuantityToGiveOut);
        }
        return a;
        throw new KeyNotFoundException("there is not any retrieve");
    }
    
   

    public static DataTable ViewDisbursementIndex(string department)
    {
        Model entities = new Model();
        DataTable b = new DataTable();
        b.Columns.Add("Disbursement_Date", typeof(DateTime));
        b.Columns.Add("Department_Name", typeof(string));
        if (department.Equals("All"))
        {
            var Datatable = entities.DisbursementItemViews.Select(x => new { x.Disbursement_Date, x.Department_Name, x.Retrieval_ID }).Distinct().ToList();
            for (int i = 0; i < Datatable.Count; i++)
            {
                b.Rows.Add(Datatable[i].Disbursement_Date, (Datatable[i].Department_Name + "/" + Datatable[i].Retrieval_ID));
            }
            return b;

        }
        else
        {
            var Datatable = entities.DisbursementItemViews.Where(x => x.Department_Name.Equals(department))
                  .Select(x => new { x.Disbursement_Date, x.Department_Name, x.Retrieval_ID }).Distinct().ToList();
            for (int i = 0; i < Datatable.Count; i++)
            {
                b.Rows.Add(Datatable[i].Disbursement_Date, (Datatable[i].Department_Name + "/" + Datatable[i].Retrieval_ID));
            }
            return b;
        }
        throw new KeyNotFoundException("there is not any retrieve");
    }
    public static DataTable ViewPastDisbursementItem(string DepartmentName, int number)
    {
        Model entities = new Model();
        var DataTable = entities.DisbursementItemViews.Where(x => x.Department_Name == DepartmentName && x.Disbursement_Date == null && x.Retrieval_ID == number).Select(x => new { x.Description, x.QuantityToGiveOut }).ToList();
        DataTable a = new DataTable();
        a.Columns.Add("Description", typeof(string));
        a.Columns.Add("QuantityToGive", typeof(int));
        for (int i = 0; i < DataTable.Count; i++)
        {
            a.Rows.Add(DataTable[i].Description, DataTable[i].QuantityToGiveOut);
        }
        return a;
        throw new KeyNotFoundException("there is not any retrieve");
    }

    /*
* Jerry's codes ends
*/
}