using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RetrievalService" in code, svc and config file together.
public class RetrievalService : IRetrievalService
{
    public void AddAdjustment(string itemNo, string empID, string raisedDate, string remarks, string qty)
    {
        RetrievalController.AddAdjustment(itemNo, Convert.ToInt32(empID), Convert.ToDateTime(raisedDate), remarks, Convert.ToInt32(qty));
    }

    public void AddNewRetrieval(string retid)
    {
        RetrievalController.AddNewRetrieval(Convert.ToInt32(retid));
    }

    public void AddRetrievalItemForUnfulfilled()
    {
        RetrievalController.AddRetrievalItemForUnfulfilled();
    }

    public List<WCFDisbursementViewDTO> GetDisbursementViewByRetrievalID(string rtr)
    {
        List<DisbursementViewDTO> list=RetrievalController.GetDisbursementViewByRetrievalID(Convert.ToInt32(rtr));
        return DisbursementViewDTOConvert.ChangevDTOListToWCFdvDTOList(list);
    }

    public List<WCFDisbursementViewDTO> GetDisbursementViewByRetrievalIDAndItemNo(string rtr, string itemno)
    {
        List<DisbursementViewDTO> list=RetrievalController.GetDisbursementViewByRetrievalIDAndItemNo(Convert.ToInt32(rtr), itemno);
        return DisbursementViewDTOConvert.ChangevDTOListToWCFdvDTOList(list);
    }

    public List<WCFDisbursementViewDTO> Getlist3(string rtr)
    {
    
        List<DisbursementViewDTO> list = RetrievalController.getlist3(Convert.ToInt32(rtr));
        return DisbursementViewDTOConvert.ChangevDTOListToWCFdvDTOList(list);
    }

    public List<int> GetRequisitionNoByItemNoAndRetrievalID(string itemno, string rtrid)
    {
        return RetrievalController.GetRequisitionNoByItemNoAndRetrievalID(itemno, Convert.ToInt32( rtrid));
    }

    public List<int> GetRetrievalIDListLessThanMaxRetrievalId(string maxrtr)
    {
        return RetrievalController.GetRetrievalIDListLessThanMaxRetrievalId(Convert.ToInt32(maxrtr));
    }

    public void IncreaseAllocatedQuantity(string itemno, string adjustment)
    {
        RetrievalController.IncreaseAllocatedQuantity(itemno, Convert.ToInt32(adjustment));
    }

    public void IncreaseRetrieval(List<int> reqnos, int adjustment, string itemno, int maxrtrid)
    {
        RetrievalController.IncreaseRetrieval(reqnos, adjustment, itemno, maxrtrid);
    }

    public void ReduceAllocatedQuantity(string itemno, string adjustment)
    {
        RetrievalController.ReduceAllocatedQuantity(itemno, Convert.ToInt32(adjustment));
    }

    public void ReduceItemTotalQty(List<DisbursementViewDTO> conflist)
    {
        RetrievalController.ReduceItemTotalQty(conflist);
    }

    public void Reduceretrieval(List<int> reqnos, int adjustment, string itemno, int maxrtrid)
    {
        RetrievalController.Reduceretrieval(reqnos, adjustment, itemno, maxrtrid);
    }

    public int RetrieveMaxID()
    {
        return RetrievalController.RetrieveMaxID();
    }

  

    public void UpdateRetrieval(string retid)
    {
        RetrievalController.UpdateRetrieval(Convert.ToInt32(retid));
    }

   
}
