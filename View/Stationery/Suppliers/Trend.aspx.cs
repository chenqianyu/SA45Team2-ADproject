using SA45Team02_SSIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class View_Stationery_Suppliers_Prediction : System.Web.UI.Page
{
    Model entities;

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
            /*DropDownList1.Items.Insert(0, new ListItem("Please Select An Item", "All"));*/
            List<string> radioButton = entities.DisbursementViews.Select(x => x.Department_Name).Distinct().ToList();
            for (int j = 0; j < radioButton.Count(); j++)
            {
                RadioButton1.Items.Insert(j, radioButton[j]);
            }

        }
        //Label1.Text = "Desription is: " + entities.RetrievalViews.Where(x => x.Item_No == DropDownList1.SelectedValue).Select(x => x.Description).First();


        if (IsPostBack && datePickerFrom != null && datePickerTo != null)
            this.DropDownList1_SelectedIndexChanged(sender, e);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        entities = new Model();
        string table4 = String.Empty;

        string jsvariable = "";
        ReportDAO rd = new ReportDAO();
        DateTime from = DateTime.Now.AddDays(1), to = DateTime.Now;
        try
        {
            from = Convert.ToDateTime(datePickerFrom.Text);
            to = Convert.ToDateTime(datePickerTo.Text);
        }
        catch
        {
            reportData.InnerHtml = "<script> timeError = true</script>";
        }
        if (from > to)
        {
            reportData.InnerHtml = "<script> timeError = true</script>";

        }
        else
        {
            string item = DropDownList1.SelectedValue;

            string department = RadioButton1.SelectedValue;
            DataTable tb_trend = new DataTable();
            tb_trend = ReportDAO.GetMonthlyReport(from, to, item, department);

            Random r;
            string[] styles = { "grey", "red", "orange", "green", "pink", "purple", "yellow", "cyan", "cornsilk", "crimson", "olivedrab", "gold", "chartreuse", "palevioletred", "plum", "lavender", "tomato", "violet", "rosybrown", "peachpuff" };

            //--------------------------------------table4--------------------------------------
            string data4 = "";

            r = new Random();

            for (int i = 0; i < tb_trend.Rows.Count; i++)
            {
                DataRow row = tb_trend.Rows[i];
                string color_4 = styles[r.Next(styles.Length)];
                DisbursementView dv = new DisbursementView();
                table4 = string.Format("['{0}/{1}', {2}, '{3}','{4}'],", (int)row["year"], (int)row["month"], (int)row["request_sum"], department + " : " + dv.Requested_Qty, color_4) + table4;
            }

            data4 = "[" + "['Time' ,'Total Request Quantity', {role: 'tooltip'},{ role: 'style' }]," + table4 + "]";


            jsvariable = "<script>" +
    "var reportData_table4 = " + data4 + ";" +
    "var period = " + "'From :" + from + ", To :" + to + "' ;timeError = false</script>" +
    " ";
            reportData.InnerHtml = jsvariable;

        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/View/Stationery/Suppliers/AnalyseStatistic.aspx");
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DateTime from = DateTime.Now.AddDays(1), to = DateTime.Now;
        reportData.InnerHtml = "<script> averageError = false</script>";
        reportData.InnerHtml = "<script> timeError = false</script>";

        try
        {
            from = Convert.ToDateTime(datePickerFrom.Text);
            to = Convert.ToDateTime(datePickerTo.Text);
            if (from > to)
            {
                reportData.InnerHtml = "<script> timeError = true</script>";
            }
            else
            {
                Label1.Text = "Desription is: " + entities.DisbursementViews.Where(x => x.Item_No == DropDownList1.SelectedValue).Select(x => x.Description).First();
                string a = entities.DisbursementViews.Where(x => x.Item_No == DropDownList1.SelectedValue
                && x.Approval_Timestamp >= from
                && x.Approval_Timestamp < to
                ).Select(x => x.Requested_Qty).Average().ToString();
                Label2.Text = "Average request quantity in this period is: " + a;
            }
        }
        catch (InvalidOperationException)
        {
            reportData.InnerHtml = "<script> averageError = true</script>";
            Label1.Text = "Desription is: " + entities.DisbursementViews.Where(x => x.Item_No == DropDownList1.SelectedValue).Select(x => x.Description).First();
            Label2.Text = "Average request quantity in this period is: Empty ";
        }
        catch (InvalidCastException)
        {
            reportData.InnerHtml = "<script> timeError = true</script>";
            Label1.Text = "Desription is: " + entities.DisbursementViews.Where(x => x.Item_No == DropDownList1.SelectedValue).Select(x => x.Description).First();
            Label2.Text = "Average request quantity in this period is: Empty ";
        }
        catch (FormatException)
        {
            Label2.Text = "Sorry Please Select Time Period.";
        }
    }
}