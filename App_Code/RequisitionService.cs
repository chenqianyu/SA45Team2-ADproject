using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SA45Team02_SSIS;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RequisitionService" in code, svc and config file together.
public class RequisitionService : IRequisitionService
{
    public void AddRequisition(string reqno, string empId, string d, string status)
    {
        RequisitionController.AddRequisition(Convert.ToInt32(reqno),Convert.ToInt32( empId), Convert.ToDateTime(d), status);
    }

    public void AddRequisitionItems(List<ItemCatalog> b, int reqno)
    {
        RequisitionController.AddRequisitionItems(b, reqno);
    }

    //public List<WCFReqListView> AllReqListByDept()
       
    //{
    //    List<ReqListView> reqListView = RequisitionController.AllReqListByDept();
    //    return ReqListViewConverter.ChangePOListToWCFPOList(reqListView);
    //}

    public void ApproveRequisitions(List<ReqListView> approvedList)
    {
        RequisitionController.ApproveRequisitions(approvedList);
    }

    public void DeleteRequisitionItemsByReqNoAndItemNo(string itemNo, string reqNo)
    {
        RequisitionController.DeleteRequisitionItemsByReqNoAndItemNo(itemNo, Convert.ToInt32(reqNo));
    }

    public WCFItemCatalog FindItemCatalogFromGivenListByItemNo(List<ItemCatalog> a, string b)
    {
       ItemCatalog ic= RequisitionController.FindItemCatalogFromGivenListByItemNo(a, b);
       return ItemCatalogConverter.changeItemCatalogToWCFItemCatalog(ic);
    }

    public int GetCountByReqNo()
    {
        return RequisitionController.GetCountByReqNo();
    }

    public WCFDepartment GetDepartment(Employee e)
    {
       Department d= RequisitionController.GetDepartment(e);
       return DepartementConverter.ChangeDepToWcfDep(d);
    }

    public List<string> GetDistinctItemCatalogsByCategory()
    {
        return RequisitionController.GetDistinctItemCatalogsByCategory();
    }

    public WCFEmployee GetEmployee(string rid)
    {
       Employee e= RequisitionController.GetEmployee(Convert.ToInt32(rid));
        return EmployeeConverter.ChangeEmpToWCFEmp(e);
    }

    public WCFItemCatalog GetItemByIemNo(string itemNo)
    {
       ItemCatalog ic= RequisitionController.GetItemByIemNo(itemNo);
        return ItemCatalogConverter.changeItemCatalogToWCFItemCatalog(ic);
    }

    public List<WCFRequisition> GetRequisitionByEmpID(string empid)
    {
       List<Requisition> list= RequisitionController.GetRequisitionByEmpID(Convert.ToInt32(empid));
       return RequisitionConverter.ChangeReqListToWCFReqList(list);
    }

    public void GetRequisitionByReqNo(string reqNo)
    {
        RequisitionController.GetRequisitionRequestByReqNo(Convert.ToInt32(reqNo));
    }

    public void GetRequisitionItems(string reqNo)
    {
        RequisitionController.GetRequisitionItemsByReqID(Convert.ToInt32(reqNo));
    }

    public List<WCFRequisitionItem> GetRequisitionItemsByReqID(string rqID)
    {
        List<RequisitionItem> list= RequisitionController.GetRequisitionItemsByReqID(Convert.ToInt32(rqID));
        return RequisitionItemConverter.ChangeReqItemListToWCFReqItemList(list);
    }

    public List<WCFRequisitionRequest> GetRequisitionRequestByReqNo(string reqNo)
    {
       List< RequisitionRequest> list= RequisitionController.GetRequisitionRequestByReqNo(Convert.ToInt32(reqNo));
        return RequisitionRequestConverter.ChangeReqRequestListToWCFReqRequestList(list);
    }

    public void RejectRequisitions(List<ReqListView> rejectedList)
    {
        RequisitionController.RejectRequisitions(rejectedList);
    }

    //public List<WCFReqListView> ReqListByDept()
    //{
    //    List<ReqListView> reqLVList = RequisitionController.ReqListByDept();
    //}

    public WCFReqListView RequesterDetails(string requisitionNumber, string deptID)
    {
       ReqListView reqLV= RequisitionController.RequesterDetails(Convert.ToInt32(requisitionNumber), deptID);
        return ReqListViewConverter.ChangeReqLvToWcfReqLv(reqLV);
    }

    public List<WCFReqDetailsView> RequisitionDetails(string requisitionNumber, string deptID)
    {
      List<ReqDetailsView> reqlvList=  RequisitionController.RequisitionDetails(Convert.ToInt32(requisitionNumber), deptID);
       return ReqDetailsViewConverter.ChangeReqDVListToWCFReqDVList(reqlvList);
    }

    public string RequisitionStatus(string requisitionNumber)
    {
       return RequisitionController.RequisitionStatus(Convert.ToInt32(requisitionNumber));
    }

    public List<WCFRequisition> RetrieveApprovedRequisitionByDate(string startDate, string endDate)
    {
        List<Requisition> reqList = RequisitionController.RetrieveApprovedRequisitionByDate(Convert.ToDateTime(startDate),Convert.ToDateTime(endDate));
        return RequisitionConverter.ChangeReqListToWCFReqList(reqList);
    }

    public List<WCFItemCatalog> RetrieveItemCatalogByCategoryID(string categoryID)
    {
        List<ItemCatalog> icList = RequisitionController.RetrieveItemCatalogByCategoryID(categoryID);
        return ItemCatalogConverter.changeItemCatalogListToWCFItemCatalogList(icList);
    }

    public List<WCFItemCatalog> RetrieveItemCatalogsList()
    {
       List<ItemCatalog> icList= RequisitionController.RetrieveItemCatalogsList();
       return ItemCatalogConverter.changeItemCatalogListToWCFItemCatalogList(icList);

    }

    public WCFRequisition RetrieveMaxReqNo()
    {
       Requisition r= RequisitionController.RetrieveMaxReqNo();
       return RequisitionConverter.ChangeReqToWcfReq(r);
    }

    public List<WCFRequisition> RetrieveRequisitionByDateWithAll(string startDate, string endDate)
    {
      List<Requisition> list=  RequisitionController.RetrieveRequisitionByDateWithAll(Convert.ToDateTime(startDate),Convert.ToDateTime( endDate));
      return  RequisitionConverter.ChangeReqListToWCFReqList(list);
        
    }

   

    public void UpdateRequisitionItemsByReqNoAndItemNo(string itemNo, string reqno, string q)
    {
        RequisitionController.UpdateRequisitionItemsByReqNoAndItemNo(itemNo, Convert.ToInt32(reqno), Convert.ToInt32(q));
    }

   
}
