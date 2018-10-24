using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Stationery_decrepancy_StationeryRetrievalForm : System.Web.UI.Page
{

    List<int> ct;
    List<DisbursementViewDTO> list2;
    List<DisbursementViewDTO> list1;
    List<DisbursementViewDTO> list3;
  
    protected void Page_Load(object sender, EventArgs e)
    {
        
        
            list2 = (List<DisbursementViewDTO>)Session["grid2"];
            if (list2 == null)
            {
                list2 = new List<DisbursementViewDTO>();
            }
            list1 = (List<DisbursementViewDTO>)Session["grid1"];
            if (list1 == null)
            {
                list1 = new List<DisbursementViewDTO>();
            }
            ct = (List<int>)Session["sct"];
            if (ct == null)
            {
                ct = new List<int>();
            }
            list3 = (List<DisbursementViewDTO>)Session["grid3"];
            if (list3 == null)
            {
                list3 = new List<DisbursementViewDTO>();
            }
        

        if (!IsPostBack)
        {
            int maxrtr = RetrievalController.RetrieveMaxID();
            ddlPastretrieve.DataSource = RetrievalController.GetRetrievalIDListLessThanMaxRetrievalId(maxrtr);
            ddlPastretrieve.Items.Insert(0, new ListItem("Select Retrieval ID", "-1"));
            ddlPastretrieve.DataBind();
        }

    }

    void bindlist1()
    {
        int maxrtrid = RetrievalController.RetrieveMaxID();
        list1 = RetrievalController.GetDisbursementViewByRetrievalID(maxrtrid);
        gvSrfbyid.DataSource = list1;
        gvSrfbyid.DataBind();
        Session["grid1"] = list1;
    }

    void dropdownload()
    {
        ddlPastretrieve.AppendDataBoundItems = false;
        ddlPastretrieve.DataSource = new List<int>();
        ddlPastretrieve.DataBind();
        ddlPastretrieve.AppendDataBoundItems = true;
        int maxrtr = RetrievalController.RetrieveMaxID();
        ddlPastretrieve.DataSource = RetrievalController.GetRetrievalIDListLessThanMaxRetrievalId(maxrtr);
        ddlPastretrieve.Items.Insert(0, new ListItem("Select Retrieval ID", "-1"));
        ddlPastretrieve.DataBind();

    }
    protected void gvSrfbyid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ViewByDept")
        {

            string itemno = (string)e.CommandArgument;
            int maxrtrid = RetrievalController.RetrieveMaxID();
            list2 = RetrievalController.GetDisbursementViewByRetrievalIDAndItemNo(maxrtrid, itemno);
            Session["grid2"] = list2;
            gvSrfbyiddept.DataSource = list2;
            gvSrfbyiddept.DataBind();

        }
    }

    protected void gvSrfbyid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvSrfbyiddept.DataSource = new List<DisbursementViewDTO>();
        gvSrfbyiddept.DataBind();
        gvSrfbyid.EditIndex = e.NewEditIndex;
        bindlist1();
    }

    protected void gvSrfbyid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvSrfbyid.EditIndex = -1;
        bindlist1();
    }

    protected void gvSrfbyid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        list1 = (List<DisbursementViewDTO>)Session["grid1"];
        int retrieved = Int32.Parse(((TextBox)gvSrfbyid.Rows[e.RowIndex].FindControl("tbRetrieved")).Text);

        string remarks = ((TextBox)gvSrfbyid.Rows[e.RowIndex].FindControl("tbRemarks")).Text;
        int a = e.RowIndex;
        DisbursementViewDTO q = list1.ElementAt(a);
        q.Remarks = remarks;
        list1[a] = q;
        ct = (List<int>)Session["sct"];
        int firstretrieved = ct.ElementAt(a);
        int oldretrieved = q.quantityToGiveOut;
        int adjustment = 0;
        Boolean cont = false;
        if (oldretrieved > retrieved)
        {
            adjustment = oldretrieved - retrieved;
            cont = true;
        }
        else if (firstretrieved < retrieved)
        {
            Response.Write("<script>alert('The amount that you enter cannot be greater than the previously existing amount')</script>");
        }
        else if ((oldretrieved != firstretrieved) && (oldretrieved < retrieved))
        {
            string itemno = gvSrfbyid.DataKeys[e.RowIndex].Value.ToString();
            DateTime raiseddate = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
            int empno = 210;
            int addadj = retrieved - oldretrieved;
            int quantity = +addadj;
            RetrievalController.AddAdjustment(itemno, empno, raiseddate, remarks, quantity);
            int maxrtrid = RetrievalController.RetrieveMaxID();
            List<int> ascreqnos = RetrievalController.GetRequisitionNoByItemNoAndRetrievalID(itemno, maxrtrid);
            ascreqnos.Reverse();
            RetrievalController.IncreaseAllocatedQuantity(itemno, addadj);
            RetrievalController.IncreaseRetrieval(ascreqnos, addadj, itemno, maxrtrid);
            gvSrfbyid.EditIndex = -1;
            bindlist1();
        }
        if (cont)
        {
            string itemno = gvSrfbyid.DataKeys[e.RowIndex].Value.ToString();
            DateTime raiseddate = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
            int empno = 210;
            int quantity = -adjustment;
            RetrievalController.AddAdjustment(itemno, empno, raiseddate, remarks, quantity);
            int maxrtrid = RetrievalController.RetrieveMaxID();
            List<int> reqnos = RetrievalController.GetRequisitionNoByItemNoAndRetrievalID(itemno, maxrtrid);
            RetrievalController.ReduceAllocatedQuantity(itemno, adjustment);
            RetrievalController.Reduceretrieval(reqnos, adjustment, itemno, maxrtrid);
            gvSrfbyid.EditIndex = -1;
            bindlist1();
        }
    }

    protected void btnGenerateSRF_Click(object sender, EventArgs e)
    {

        ddlPastretrieve.Enabled = false;
        ddlPastretrieve.Visible = false;
        gvPastSRFbyid.DataSource = new List<DisbursementViewDTO>();
        gvPastSRFbyid.DataBind();
        gvSrfbyiddept.DataSource = new List<DisbursementViewDTO>();
        gvSrfbyiddept.DataBind();
        int maxrtrid = RetrievalController.RetrieveMaxID();
        list1 = RetrievalController.GetDisbursementViewByRetrievalID(maxrtrid);
        ct = (List<int>) Session["sct"];
        if (ct == null)
        {
            ct = new List<int>();
            foreach (DisbursementViewDTO vco in list1)
            {
                ct.Add(vco.quantityToGiveOut);

            }
        }
        else
        {
            ct = (List<int>)Session["sct"];
        }
        Session["sct"] = ct;
        Session["grid1"] = list1;
        if (list1.Count > 0)
        {
            btnConfirm.Enabled = true;
        }
        gvSrfbyid.DataSource = list1;
        gvSrfbyid.DataBind();
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {

        List<DisbursementViewDTO> conflist = (List<DisbursementViewDTO>)Session["grid1"];
        RetrievalController.ReduceItemTotalQty(conflist);
        int maxrtrid = RetrievalController.RetrieveMaxID();
        RetrievalController.UpdateRetrieval(maxrtrid);
        maxrtrid = maxrtrid + 1;
        RetrievalController.AddNewRetrieval(maxrtrid);
        ct = new List<int>();
        Session["sct"] = ct;
        gvSrfbyid.DataSource = new List<DisbursementViewDTO>();
        gvSrfbyid.DataBind();
        gvSrfbyiddept.DataSource = new List<DisbursementViewDTO>();
        gvSrfbyiddept.DataBind();
        dropdownload();
        btnConfirm.Enabled = false;
    }

    protected void gvPastSRFbyid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ViewByDept2")
        {
            string itemno = gvPastSRFbyid.DataKeys[gvPastSRFbyid.SelectedIndex].Value.ToString();
            Response.Write(itemno);
        }
    }

    protected void bntPastSRF_Click(object sender, EventArgs e)
    {
        gvSrfbyid.DataSource = new List<DisbursementViewDTO>();
        gvSrfbyid.DataBind();
        gvSrfbyiddept.DataSource = new List<DisbursementViewDTO>();
        gvSrfbyiddept.DataBind();
        gvPastSRFbyid.DataSource = new List<DisbursementViewDTO>();
        gvPastSRFbyid.DataBind();
        btnConfirm.Enabled = false;
        ddlPastretrieve.Visible = true;
        ddlPastretrieve.Enabled = true;
        ddlPastretrieve.SelectedIndex = -1;


    }



    protected void gvPastSRFbyid_SelectedIndexChanged(object sender, EventArgs e)
    {
        string itemno = gvPastSRFbyid.DataKeys[gvPastSRFbyid.SelectedIndex].Value.ToString();
        int rtrid = Convert.ToInt32(((Label)gvPastSRFbyid.Rows[gvPastSRFbyid.SelectedIndex].FindControl("lbRetrievalID")).Text);
        list2 = RetrievalController.GetDisbursementViewByRetrievalIDAndItemNo(rtrid, itemno);
        gvSrfbyiddept.DataSource = list2;
        gvSrfbyiddept.DataBind();
    }

    protected void ddlPastretrieve_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPastretrieve.SelectedItem.Text != "Select Retrieval ID")
        {
            int selectedrtrid = Convert.ToInt32(ddlPastretrieve.SelectedItem.Text);
            list3 = RetrievalController.getlist3(selectedrtrid);
            Session["grid3"] = list3;
            gvPastSRFbyid.DataSource = list3;
            gvPastSRFbyid.DataBind();
            gvSrfbyid.DataSource = new List<DisbursementViewDTO>();
            gvSrfbyid.DataBind();
            gvSrfbyiddept.DataSource = new List<DisbursementViewDTO>();
            gvSrfbyiddept.DataBind();
        }
        else
        {
            gvPastSRFbyid.DataSource = new List<DisbursementViewDTO>();
            gvPastSRFbyid.DataBind();
            gvSrfbyid.DataSource = new List<DisbursementViewDTO>();
            gvSrfbyid.DataBind();
            gvSrfbyiddept.DataSource = new List<DisbursementViewDTO>();
            gvSrfbyiddept.DataBind();
        }
    }
}