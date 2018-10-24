using SA45Team02_SSIS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Stationery_Supervisior_DelegateToOther : System.Web.UI.Page
{
  
    string deptID = "STORE";
    protected void Page_Load(object sender, EventArgs e)
    {
        CompareValidatorToday.ValueToCompare = DateTime.Now.ToShortDateString();
        Employee e1 = DelegateController.GetDelegateStoreClerk(deptID);
        if (e1 != null)
        {
            int delID = DelegateController.GetDelegateStoreClerk(deptID).Employee_ID;
            DelegateAuthority d = DelegateController.GetActiveDelegateByEmpId(delID);
            Panel1.Visible = true;
            lbDelegateHistory.Text = e1.Employee_Name;
            //  DelegateAuthority d = delCtr.getActiveDelegateByEmpId(205);
            if (d != null)
            {
                lbStartDate.Text = d.Start_Date.ToShortDateString();
                if (d.End_Date > d.Start_Date)
                {
                    lbEndDate.Text = ((DateTime)d.End_Date).ToShortDateString();
                }
                else { lbEndDate.Text = ""; }
            }

        }


        if (!String.IsNullOrEmpty(tbEndDate.Text))
        {
            cvtxtStartDate.Enabled = false;
        }
        if (!IsPostBack)
        {

            DropDownDataBind();
            // GridBind();
        }
    }
    private void DropDownDataBind()
    {
        ddlItemList.DataSource = DelegateController.GetStoreClerk();
        ddlItemList.DataTextField = "Employee_Name";
        ddlItemList.DataValueField = "Employee_ID";
        ddlItemList.DataBind();

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        if (Page.IsValid)
        {
            int employeeId = Int32.Parse(ddlItemList.SelectedValue);
            string employeeName = ddlItemList.SelectedItem.Text;
            DateTime start = DateTime.Parse(tbStartDate.Text);
            DateTime end = new DateTime();

            DateTime dt;

            if (DateTime.TryParse(tbEndDate.Text, out dt))
            {
                end = DateTime.Parse(tbEndDate.Text);
            }

            bool success = DelegateController.SetSupervisorDelegate(employeeId, start, end, Utility.Current);
            if (success)
            {
                string script = "alert('successful update');";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);

                Panel1.Visible = true;
                lbStartDate.Text = start.ToShortDateString();
                if (end > start)
                {
                    lbEndDate.Text = ((DateTime)end).ToShortDateString();
                }
                else
                { lbEndDate.Text = ""; }
                lbDelegateHistory.Text = ddlItemList.SelectedItem.Text;

            }
            else
            {
                string script = "alert('unsuccessful.Please choose another date');";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);

            }

        }
        DropDownDataBind();

    }
}