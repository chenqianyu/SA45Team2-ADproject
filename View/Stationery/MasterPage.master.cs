using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        if (!IsPostBack)
        {
            bool hasParent = (e.Item.Parent != null);

            switch (hasParent)
            {
                case false:
                    switch (e.Item.Value)
                    {
                        case "Stationery Req":
                            Response.Redirect("~");
                            break;
                        case "Inventory maintainance":
                            Response.Redirect("");
                            break;
                        case "Supervisor":
                            Response.Redirect("Supervisor");
                            break;
                    }
                    break;
                case true:
                    switch (e.Item.Parent.Value)
                    {
                        case "Stationery Req":
                            switch (e.Item.Value)
                            {
                                case "View requsitions status":
                                    Response.Redirect("~/RGS/Workflow/Workflow.aspx");
                                    break;
                                case "Generate Disbursement List":
                                    Response.Redirect("~/RGS/Workflow/WorkflowEdit.aspx");
                                    break;
                                case "inform employee":
                                    Response.Redirect("~/RGS/Workflow/WorkflowCreate.aspx");
                                    break;
                                case "Generate Stationery Retrieval Form":
                                    Response.Redirect("~/RGS/Workflow/WorkflowDelete.aspx");
                                    break;
                            }
                            break;
                        case "Inventory maintainance":
                            switch (e.Item.Value)
                            {
                                case "View invenory stock levels":
                                    Response.Redirect("~/Adproject_team2/Stationery/inventory/inventoryList.aspx");
                                    break;
                                case "Generate PO":
                                    Response.Redirect("~/Adproject_team2/Stationery/GeneratePO/GeneratePO.aspx");
                                    break;
                                case "Maintain record of suppliers'information":
                                    Response.Redirect("~/Adproject_team2/Stationery/Suppliers/MaintainSuppliers.aspx");
                                    break;
                                case "Generate statics charts":
                                    Response.Redirect("~/Adproject_team2/Stationery/Suppliers/MaintainSuppliers.aspx");
                                    break;
                                case "Adjust reorder level":
                                    Response.Redirect("~/RGS/Workflow/BusinessHour/BusinessHours.aspx");
                                    break;
                                case "Key in discrepancy level":
                                    Response.Redirect("~/RGS/Workflow/BusinessHour/BusinessHours.aspx");
                                    break;
                            }
                            break;
                        case "Supervisor":
                            switch (e.Item.Value)
                            {
                                case "Approve PO":
                                    Response.Redirect("~/Adproject_team2/Stationery/Supervisior/ApprovalPO.aspx");
                                    break;
                                case "Issue adjustment voucher":
                                    Response.Redirect("~/Adproject_team2/Stationery/Supervisior/IssueAdjustment.aspx");
                                    break;
                                case "Delegate authority":
                                    Response.Redirect("~/Adproject_team2/Stationery/Supervisior/DelegateToOther.aspx");
                                    break;
                                case "Relinquish authority":
                                    Response.Redirect("~/Adproject_team2/Stationery/Supervisior/RelinquishApproval.aspx");
                                    break;
                            }
                            break;
                    }
                    break;

            }
        }
    }




    protected void OnMenuItemClick(object sender, MenuEventArgs e)
    {


        
        if (e.Item.Text.ToLower() == "logout")

        {

            FormsAuthentication.SignOut();

            FormsAuthentication.RedirectToLoginPage();

            //Redirect the page.
        }


    }
}
