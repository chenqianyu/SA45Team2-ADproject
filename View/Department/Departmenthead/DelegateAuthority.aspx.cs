using SA45Team02_SSIS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Departmenthead_DelegateAuthority : System.Web.UI.Page
{
    DelegateController delCtr = new DelegateController();
    string deptID = "ELEC";
    protected void Page_Load(object sender, EventArgs e)
    {
        CompareValidatorToday.ValueToCompare = DateTime.Now.ToShortDateString();
        Employee e1 = DelegateController.GetDelegateEmp(deptID);
        if (e1 != null)
        {
            int delID = DelegateController.GetDelegateEmp(deptID).Employee_ID;
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
        ddlItemList.DataSource = DelegateController.GetEmployeeName(deptID);
        ddlItemList.DataTextField = "Employee_Name";
        ddlItemList.DataValueField = "Employee_ID";
        ddlItemList.DataBind();

    }

    //private void GridBind()
    //{

    //    //lbDelegateHistory.Text = delCtr.getDelegate().FirstOrDefault().Employee_Name;
    //    //int empId = 203;
    //    //lbStartDate.Text =delCtr.getActiveDelegateByEmpId(empId).Start_Date.ToString();
    //    //lbEndDate.Text = ((DateTime)delCtr.getActiveDelegateByEmpId(empId).End_Date).ToShortDateString();

    //}

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

            bool success = DelegateController.SetDepartmentDelegate(employeeId, start, end, Utility.Current);
            if (success)
            {
                string script = "alert('Successfully updated');";
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
                string script = "alert('Unsuccessful.Please choose another date');";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);

            }

        }
        DropDownDataBind();

    }
    //private void ShowInfo(int employeeId)
    //{
    //    DelegateAuthority dl = rqc.GetDelegateAuthorityByEmpId(employeeId);
    //    lbStartDate.Text = dl.Start_Date.ToShortDateString();
    //    lbEndDate.Text = dl.End_Date.Value.ToShortDateString();
    //    tbInput.Text = dl.Status;
    //}

}