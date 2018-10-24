using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SA45Team02_SSIS;

public partial class Adproject_team2_Default2 : System.Web.UI.Page
{
   
    string Itemno;
    protected void Page_Load(object sender, EventArgs e)
    {
       
       Itemno = Session["ItemNo"].ToString();
        if (Itemno!= String.Empty)
        {
            if (!IsPostBack)
           {
                          
                ItemCatalog Item = ItemCatalogController.SearchByItemNo(Itemno);
                Label1.Text = Item.Item_No;
                Label2.Text = Item.Category;
                TextBox2.Text = Item.Description;
                TextBox3.Text = Item.Reorder_Lvl.ToString();
                TextBox4.Text = Item.Reorder_Qty.ToString();
                TextBox5.Text = Item.Unit_of_Measure;
                Label3.Text = Item.Total_Qty.ToString();
                Label4.Text =
                string.Format("${0:C}", Item.Price.ToString());
                Label5.Text = Item.Allocated_Qty.ToString();
            }
        }
        else
        {
            if (!IsPostBack)
            {
                Label1.Text = "please select catalog";
                Label2.Visible = false;
                Label2.Width = 0;
                Label3.Text = "0";
                Label4.Text = "0";
                Label5.Text ="0";
                DropDownList1.Visible = true;
                DropDownList1.DataSource = ItemCatalogController.SelectItemCatalog();
                DropDownList1.DataBind();
            }
        }
        
    }

    protected void Edit_Clicked(object sender, EventArgs e)
    {
      
            try
            {
                if (Itemno.Equals(null))
                {
                    ItemCatalog a = new ItemCatalog();
                    a.Item_No = Label1.Text;
                    if (Session["ItemNo"] == null)
                        a.Category = DropDownList1.SelectedItem.ToString();
                    else
                        a.Category = Label2.Text;
                    a.Description = TextBox2.Text;
                    a.Reorder_Lvl = Convert.ToInt32(TextBox3.Text);
                    a.Reorder_Qty = Convert.ToInt32(TextBox4.Text);
                    a.Unit_of_Measure = TextBox5.Text;
                    a.Total_Qty = Convert.ToInt32(Label3.Text);
                    a.Price = Convert.ToDecimal(Label4.Text);
                a.Allocated_Qty = Convert.ToInt32(Label5);
                ItemCatalogController.insertNewItem(a);
                }
                else
                ItemCatalogController.editItemByNo(Itemno, Convert.ToInt32(TextBox3.Text), Convert.ToInt32(TextBox4.Text),
                        TextBox5.Text, Convert.ToInt32(Label3.Text), Convert.ToDecimal(Label4.Text),Convert.ToInt32(Label5.Text)) ;
                Situation.Text = "Edit successfully";
            }
            catch (Exception)
            {
                Situation.Text = "invalid connection";
            }
        
    }
    
    protected void Return_Clicked(object sender, EventArgs e)
    {
        Response.Redirect("~/View/Stationery/inventory/InventoryList.aspx");
    }
    protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        string a = DropDownList1.SelectedItem.ToString();
        Label1.Text = ItemCatalogController.createNewItem_no(a).ToString();
        
    }

}