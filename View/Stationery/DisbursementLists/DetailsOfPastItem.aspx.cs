using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SA45Team02_SSIS;
using System.Text.RegularExpressions;

public partial class View_Stationery_DisbursementLists_DetailsOfPastItem : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        string Departmentinfo =Convert.ToString( Session["department_Name"]);
        if (!IsPostBack)
        {
            //string Department_Name = Departmentinfo.Substring(0, Departmentinfo.Count()-2);
            string Retrieval_ID = Regex.Match(Departmentinfo, @"\d+").Value;
            string Department_Name = Departmentinfo.Substring(0, Departmentinfo.Count() - Retrieval_ID.Length-1);
            //int Number = Convert.ToInt32(Departmentinfo.Substring(Departmentinfo.Count()-1,1));
            int Number = Convert.ToInt32(Retrieval_ID);
            DisbursementItemView selected = DisbursementController.RetrieveInformation(Department_Name);
            Label5.Text = selected.Department_Name;
            Label2.Text = selected.Department_Name + "/" + selected.Requisition_No.ToString();
            Label3.Text = selected.collectionPoint;
            Label4.Text = selected.Employee_Name;
            GridView1.DataSource = DisbursementController.ViewPastDisbursementItem(Department_Name,Number);
            GridView1.DataBind();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/View/Stationery/DisbursementLists/PastDisbursementLists.aspx");
    }
}