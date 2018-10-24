using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SA45Team02_SSIS;

public partial class View_Stationery_ViewDeliveryOrders : System.Web.UI.Page
{
  
    protected void Page_Load(object sender, EventArgs e)
    {
        gvPOList.DataSource = DeliveryOrderController.GetDeliveryOrderList(); ;
        gvPOList.DataBind();

        if (gvPOList.Rows.Count == 0)
        {
            lbStatus.Text = "There are no pending delivered orders";
        }

        gvAcknowledged.DataSource = DeliveryOrderController.GetPastDeliveryOrderList();
        gvAcknowledged.DataBind();

        if (gvAcknowledged.Rows.Count == 0)
        {
            lbStatus2.Text = "There are no past delivered orders";
        }
    }

    protected void lbView_Click(object sender, EventArgs e)
    {
        LinkButton View = (LinkButton)sender;
        GridViewRow row = (GridViewRow)View.NamingContainer;
        string POID = "";
        if (row != null)
        {
            POID = (row.FindControl("lbPONo") as Label).Text;
            Response.Redirect("ViewDeliveryOrderDetails.aspx?POID=" + POID);
        }
    }
}