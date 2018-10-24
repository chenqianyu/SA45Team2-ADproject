using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;

public partial class Stationery_Suppliers_AnalyseStatistic : System.Web.UI.Page
{
    Model entities;
    //protected void Page_PreInit(object sender, EventArgs e)
    //{
    //    string Role = Roles.GetRolesForUser().First();
    //    if (Role.ToString().Equals("StoreClerk"))
    //    {
    //        this.Page.MasterPageFile = "~/View/Stationery/MasterPageForStoreClerk.master";
    //    }
    //    else if (Role.ToString().Equals("Manager"))
    //    {
    //        this.Page.MasterPageFile = "~/View/Stationery/MasterPageForManager.master";
    //    }
    //    else if (Role.ToString().Equals("DelegateSupervisor"))
    //    {
    //        this.Page.MasterPageFile = "~/View/Stationery/MasterPageForDelegateSupervisor.master.master";
    //    }
    //    else if (Role.ToString().Equals("Supervisor"))
    //    {
    //        this.Page.MasterPageFile = "~/View/Stationery/MasterPageForManager.master";
    //    }
    //}

    protected void Page_Load(object sender, EventArgs e)
    {
        entities = new Model();
        if (!IsPostBack)
        {
            List<string> DropDownValue = entities.DisbursementViews.Select(x => x.Item_No).Distinct().ToList();
            for (int i = 0; i < DropDownValue.Count(); i++)
            {
                DropDownList1.Items.Insert(i, new ListItem(DropDownValue[i], DropDownValue[i].ToString()));
            }
            //DropDownList1.Items.Insert(0, new ListItem("Please Select An Item", "All"));
        }
        
    }
    protected void show_item_description(object sender, EventArgs e)
    {
        Label1.Text = "Desription is: " + entities.DisbursementViews.
        Where(x => x.Item_No == DropDownList1.SelectedValue).Select(x => x.Description).First();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        entities = new Model();
        string table1 = String.Empty;
        string table2 = String.Empty;
        string table3 = String.Empty;

        string jsvariable = "";

        DateTime datefrom = DateTime.Now.AddDays(1), dateto = DateTime.Now;
        try
        {
            datefrom = Convert.ToDateTime(datePickerFrom.Text);
            dateto = Convert.ToDateTime(datepickerTo.Text);
        }
        catch
        {
            reportData.InnerHtml = "<script> timeError = true</script>";
        }
        if (datefrom > dateto)
        {
            reportData.InnerHtml = "<script> timeError = true</script>";
        }
        else
        {
            string item = DropDownList1.SelectedValue;
            DataTable dt1 = ReportDAO.GetReport1(datefrom, dateto, item);
            DataTable dt2 = ReportDAO.GetReport2(datefrom, dateto, item);
            DataTable dt3 = ReportDAO.GetReport3(datefrom, dateto, item);
            DataTable dt4 = ReportDAO.GetReport4(datefrom, dateto, item);

            Random r;
            string[] styles = { "grey", "red", "orange", "green", "pink", "purple", "yellow", "cyan", "cornsilk", "crimson", "olivedrab", "gold", "chartreuse", "palevioletred", "plum", "lavender", "tomato", "violet", "rosybrown", "peachpuff" };

            //--------------------------------------table1--------------------------------------
            string data1 = "";

            r = new Random();

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string color_1 = styles[r.Next(styles.Length)];
                table1 = string.Format("['{0}', {1}, '{2} : {1}','{3}'],", (string)dt2.Rows[i]["Department_ID"], (int)dt3.Rows[i]["request_sum"], (string)dt1.Rows[i]["Description"], color_1) + table1;
            }

            data1 = "[" + "['DepartmentID' ,'Total Quantity', {role: 'tooltip'},{ role: 'style' }]," + table1 + "]";

            reportData.InnerHtml = jsvariable;

            //--------------------------------------table2--------------------------------------

            string data2 = "";
            DataTable tb_totalPrice = ReportDAO.GetReport5(datefrom, dateto, item);

            for (int i = 0; i < tb_totalPrice.Rows.Count; i++)
            {
                DataRow r_price = tb_totalPrice.Rows[i];
                string color_2 = styles[r.Next(styles.Length)];
                table2 = string.Format("['{0}', {1}, '{2} : ${1}','{3}'],", (string)r_price["Department_Name"], (decimal)r_price["totalPrice"], (string)r_price["Description"], color_2) + table2;
            }

            data2 = "[" + "['DepartmentName' ,'Total Price', { role: 'tooltip'},{ role: 'style' }]," + table2 + "]";

            reportData.InnerHtml = jsvariable;
            jsvariable = "<script>" +
                "var reportData_table1 =" + data1 + ";" +
                "var reportData_table2 = " + data2 + ";" +
                "var period = " + "'From :" + datefrom + ", To :" + dateto + "' ;timeError = false</script>" +
                " ";
            reportData.InnerHtml = jsvariable;
        }
    }
}