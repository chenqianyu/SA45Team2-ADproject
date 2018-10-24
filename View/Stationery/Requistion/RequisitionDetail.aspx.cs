using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Stationery_Requistion_RequisitionDetail : System.Web.UI.Page
{
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int rqID = Int32.Parse(Request.QueryString["requisitionID"]);
            txtRNo.Text = Convert.ToString(rqID);
            txtEmpID.Text = Convert.ToString(RequisitionController.GetEmployee(rqID).Employee_ID);
            txtEmpName.Text = Convert.ToString(RequisitionController.GetEmployee(rqID).Employee_Name);
            txtEmpEmail.Text = Convert.ToString(RequisitionController.GetEmployee(rqID).Email);
            Department dep = RequisitionController.GetDepartment(RequisitionController.GetEmployee(rqID));
            txtDepName.Text = Convert.ToString(dep.Department_Name);
            txtDepCode.Text = Convert.ToString(dep.Department_ID);
            gvRequisitionDetails.DataSource = RequisitionController.GetRequisitionItemsByReqID(rqID);
            gvRequisitionDetails.DataBind();
        }
    }

    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            RequisitionItem item = (RequisitionItem)e.Row.DataItem;
            string id = item.Item_No;
            string description = RequisitionController.GetItemByIemNo(id).Description;
            Label deslabel = (e.Row.FindControl("lblDescription") as Label);
            if (deslabel != null)
                deslabel.Text = description;
        }
    }
}