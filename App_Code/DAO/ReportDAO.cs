using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using SA45Team02_SSIS;
/// <summary>
/// Summary description for ReportDAO
/// </summary>
public class ReportDAO
{
    public ReportDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /*
* Charlotte's Codes Start
*/
    Model entities = new Model();

    public static DataTable GetReport1(DateTime from, DateTime to, string itemNo)
    {
        DataTable d = new DataTable();
        d.Columns.Add("Description", typeof(String));
        Model entities = new Model();
        List<DisbursementViewDTO> dvli = entities.DisbursementViews.
            Where(x => x.Approval_Timestamp >= from && x.Approval_Timestamp <= to && x.Item_No == itemNo).
            GroupBy(x => new { x.Department_ID, x.Description, x.Department_Name }).
            Select(y => new DisbursementViewDTO { item_Description = y.Key.Description }).ToList();
        foreach (DisbursementViewDTO dd in dvli)
        {
            d.Rows.Add(dd.Item_Description);
        }
        return d;
        /*
        string sqlcmd = "/*select Description from DisbursementView" +
                        "where Department_ID = 'COMM' and Approval_Timestamp between '@from' and '@to' " +
                        "and  Item_No = '@itemNo' group by Department_ID,Department_Name,Description,Approval_Timestamp";
        string connectionString = "Data Source=DESKTOP-5ONENA2\\SQLEXPRESS;Initial Catalog=SSIS_Team2;Integrated Security=True";
        SqlConnection conn = new SqlConnection(connectionString);
        try
        {
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sqlcmd, conn);
            //      adapter.SelectCommand.Parameters.AddWithValue("@from", from);
            //      adapter.SelectCommand.Parameters.AddWithValue("@to", to);
            //      adapter.SelectCommand.Parameters.AddWithValue("@itemNo", itemNo);
            DataTable tb = new DataTable();
            adapter.Fill(tb);
            return tb;
        }
        catch (Exception e)
        {
            return null;
        }
        finally
        {
            conn.Close();
        }
        */
    }

    public static DataTable GetReport2(DateTime from, DateTime to, string itemNo)
    {
        DataTable d = new DataTable();
        d.Columns.Add("Department_ID", typeof(String));
        Model entities = new Model();
        List<DisbursementViewDTO> dvli = entities.DisbursementViews.
            Where(x => x.Approval_Timestamp >= from && x.Approval_Timestamp <= to && x.Item_No == itemNo).
            GroupBy(x => new { x.Department_ID, x.Description, x.Department_Name }).
            Select(y => new DisbursementViewDTO { dept_ID = y.Key.Department_ID }).ToList();
        foreach (DisbursementViewDTO dd in dvli)
        {
            d.Rows.Add(dd.Dept_ID);
        }
        return d;
    }

    public static DataTable GetReport3(DateTime from, DateTime to, string itemNo)
    {

        DataTable d = new DataTable();
        d.Columns.Add("request_sum", typeof(Int32));
        Model entities = new Model();
        List<DisbursementViewDTO> dvli = entities.DisbursementViews.
            Where(x => x.Approval_Timestamp >= from && x.Approval_Timestamp <= to && x.Item_No == itemNo).
            GroupBy(x => new { x.Department_ID, x.Description, x.Department_Name }).
            Select(y => new DisbursementViewDTO { requested_Quantity = y.Sum(g => g.Requested_Qty) }).ToList();
        foreach (DisbursementViewDTO dd in dvli)
        {
            d.Rows.Add(dd.Requested_Quantity);
        }
        return d;
    }

    public static DataTable GetReport4(DateTime from, DateTime to, string itemNo)
    {
        DataTable d = new DataTable();
        d.Columns.Add("actual_sum", typeof(Int32));
        Model entities = new Model();
        List<DisbursementViewDTO> dvli = entities.DisbursementViews.
            Where(x => x.Approval_Timestamp >= from && x.Approval_Timestamp <= to && x.Item_No == itemNo).
            GroupBy(x => new { x.Department_ID, x.Description, x.Department_Name }).
            Select(y => new DisbursementViewDTO { actual_Quantity = (int)y.Sum(g => g.Actual_Qty) }).ToList();
        foreach (DisbursementViewDTO dd in dvli)
        {
            d.Rows.Add(dd.Actual_Quantity);
        }
        return d;
    }

    public static DataTable GetReport5(DateTime from, DateTime to, string itemNo)
    {
        string sqlcmd = " select (qty_sum*Price)as totalPrice,Department_Name,Description from " +
            "( select sum(dv.Actual_Qty) as qty_sum ,dv.Department_Name,ic.Price,ic.Description from DisbursementView dv,ItemCatalog ic " +
            " where  dv.Approval_Timestamp between @from and @to and dv.Item_No=@itemNo and ic.Item_No = dv.Item_No " +
            "group by dv.Department_ID,dv.Department_Name,dv.Description,ic.Price,ic.Description) as sum_qty ";
        string connectionString = "Data Source=(local);Initial Catalog=SSIS_Team2;Integrated Security=True";
        SqlConnection conn = new SqlConnection(connectionString);
        try
        {
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sqlcmd, conn);
            adapter.SelectCommand.Parameters.AddWithValue("@from", from);
            adapter.SelectCommand.Parameters.AddWithValue("@to", to);
            adapter.SelectCommand.Parameters.AddWithValue("@itemNo", itemNo);
            DataTable tb = new DataTable();
            adapter.Fill(tb);
            return tb;
        }
        catch (Exception e)
        {
            return null;
        }
        finally
        {
            conn.Close();
        }
    }

    public static DataTable GetMonthlyReport(DateTime from, DateTime to, string itemNo, string depName)
    {
        string sqlcmd = "select DATEPART(year,Approval_Timestamp) [year],DATEPART(month,Approval_Timestamp)[month]," +
                        "sum(Requested_Qty) as request_sum from DisbursementView " +
                        "where Item_No = @itemNo and Department_Name=@depName " +
                        "group by DATEPART(year,Approval_Timestamp),DATEPART(month,Approval_Timestamp) " +
                        "order by DATEPART(month,Approval_Timestamp)";
        string connectionString = "Data Source=(local);Initial Catalog=SSIS_Team2-new;Integrated Security=True";
        SqlConnection conn = new SqlConnection(connectionString);
        try
        {
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sqlcmd, conn);
            adapter.SelectCommand.Parameters.AddWithValue("@from", from);
            adapter.SelectCommand.Parameters.AddWithValue("@to", to);
            adapter.SelectCommand.Parameters.AddWithValue("@itemNo", itemNo);
            adapter.SelectCommand.Parameters.AddWithValue("@depName", depName);
            DataTable tb = new DataTable();
            adapter.Fill(tb);
            return tb;
        }
        catch (Exception e)
        {
            return null;
        }
        finally
        {
            conn.Close();
        }
    }
    /*
* Charlotte's Codes Ends
*/
}