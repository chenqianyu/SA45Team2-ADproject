using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SA45Team02_SSIS;
using System.Data;
using System.Text.RegularExpressions;

public partial class View_Stationery_DisbursementLists_Default : System.Web.UI.Page
{

  
   static  int previousquantity;
    int empID;
    List<int> compare;
    protected void Page_Load(object sender, EventArgs e)
    {
        Model entities = new Model();
        
        if (!IsPostBack)
        {
            List<string> DepartmentName = DisbursementController.SelectDepartmentName();
            List<string> DepartmentId = DisbursementController.SelectDepartmentName();
            for (int i = 0; i < DepartmentName.Count; i++)
            {
                ddlDisbursement.Items.Insert(i, new ListItem(DepartmentName[i], DepartmentId[i]));
            }

            DisbursementItemView selected = DisbursementController.RetrieveInformation(ddlDisbursement.SelectedValue);
            lbDisbursementID.Text = selected.Department_Name + "/" + selected.Requisition_No.ToString();
            lbDisbursement3.Text = selected.collectionPoint;
            lbDisbursement4.Text = selected.Employee_Name;
           
            empID = entities.Employees.Where(x => x.Employee_Name == lbDisbursement4.Text).Select(x => x.Employee_ID).First();
            gvDisbursement1.DataSource = DisbursementController.Retrieveitem(ddlDisbursement.SelectedValue);
            gvDisbursement1.DataBind();
        }
    }


    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DisbursementItemView selected = DisbursementController.RetrieveInformation(ddlDisbursement.SelectedValue);
            lbDisbursementID.Text = selected.Department_Name + "/" + selected.Requisition_No.ToString();
            lbDisbursement3.Text = selected.collectionPoint;
            lbDisbursement4.Text = selected.Employee_Name;
            gvDisbursement1.DataSource = DisbursementController.Retrieveitem(ddlDisbursement.SelectedValue);
            gvDisbursement1.DataBind();
            ltDisbursement.Visible = false;

        }
        catch(Exception)
        {
            ltDisbursement.Text = "there is not any retrieve";
            lbDisbursementID.Text = String.Empty;
            lbDisbursement3.Text = String.Empty;
            lbDisbursement1.Text = String.Empty;
            DataTable a = new DataTable();
            a.Columns.Add("Description", typeof(string));
            a.Columns.Add("QuantityToGive", typeof(int));
            gvDisbursement1.DataSource = a;          
            gvDisbursement1.DataBind();
        }
    }

    public void gridviewUpdating(object sender, GridViewUpdateEventArgs e)
    {

        GridViewRow row = gvDisbursement1.Rows[e.RowIndex];
        string Description = (row.FindControl("lbDisbursement1") as Label).Text;
        int quantitytogive = Convert.ToInt32((row.FindControl("tbDisbursement2") as TextBox).Text);
        compare = (List<int>)Session[(row.FindControl("lbDisbursement1") as Label).Text];
        int num = compare.FirstOrDefault();
        if (quantitytogive >= num)
        {
           (row.FindControl("ltDisbursementInEdit")as Literal).Text = "the value must be less than " + compare.First();
        }
        else
        {
            int gap = previousquantity - quantitytogive;
            string Item_ID = DisbursementController.FindItem(Description);
            //int RetrieveNo = Convert.ToInt32(lbDisbursement2.Text.Substring(lbDisbursement2.Text.Count() - 1, 1));
            int RetrieveNo = Convert.ToInt32(Regex.Match(lbDisbursementID.Text, @"\d+").Value);
            string Remark = (row.FindControl("tbDisbursement3") as TextBox).Text;
            DisbursementController.EditRetriveItem(Item_ID, RetrieveNo, quantitytogive);
            AdjustmentController.AddAdjustment(Item_ID, Convert.ToInt32(lbDisbursement5.Text.ToString()), DateTime.Now, Remark, gap);
            gvDisbursement1.EditIndex = -1;
            gvDisbursement1.Columns[2].Visible = false;
            BindGrid();
        }
       
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewRow row = gvDisbursement1.Rows[e.NewEditIndex];    
        int number = Convert.ToInt32((
            row.FindControl("lbDisbursement2") as Label).Text.ToString());
        var chart = Session[(row.FindControl("lbDisbursement1") as Label).Text];
        if(chart == null) { 
        Session[(row.FindControl("lbDisbursement1") as Label).Text] = new List<int>();
        }
        List<int> compare = (List<int>) Session[(row.FindControl("lbDisbursement1") as Label).Text];
        compare.Add(number);
        Session[(row.FindControl("lbDisbursement1") as Label).Text] = compare;


        previousquantity = number;
        gvDisbursement1.EditIndex = e.NewEditIndex;
        gvDisbursement1.Columns[2].Visible = true;
        BindGrid();

    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvDisbursement1.EditIndex = -1;
        gvDisbursement1.Columns[2].Visible = false;
        BindGrid();
    }

    private void BindGrid()
    {
        gvDisbursement1.DataSource = DisbursementController.Retrieveitem(ddlDisbursement.SelectedValue);
        gvDisbursement1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/View/Stationery/DisbursementLists/PastDisbursementLists.aspx");
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
}
