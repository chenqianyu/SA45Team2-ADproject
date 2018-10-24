<%@ Page Title="" Language="C#" MasterPageFile="~/View/Stationery/MasterPageforStockClerk.master" AutoEventWireup="true" CodeFile="ViewPODetails.aspx.cs" Inherits="View_Stationery_GeneratePO_ViewPO" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form class="form" runat="server">
          <h2>View Purchase Order:</h2>
  <br />
   <h3>Search By Item Descritpion: </h3> <asp:DropDownList ID="ddlItem" runat="server"></asp:DropDownList>
   <asp:Button ID="btnSearch" runat="server" Text="Search" onclick="SearchByItemDescription" 
       CssClass="btn-lg bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White" />
        &nbsp;&nbsp;
    <asp:Button ID="btnViewAll" runat="server" Text="ViewAll" onclick="ViewAll"
        CssClass="btn-lg bg-green" BorderStyle="None" Font-Bold="true" ForeColor="White" />
         <div style="height: 250px,600px initial; width: 80%">
     <asp:GridView ID="gvOrderDetails" runat="server" AutoGenerateColumns="False" OnRowDataBound="OnRowDataBound"
        CssClass="table" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Large" AlternatingRowStyle-Width="400px">

        <Columns>
            <asp:TemplateField HeaderText="ItemCode">
                <ItemTemplate>
                    <asp:Label ID="Label1"  Text='<%# Bind("Item_No") %>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Description">
                <ItemTemplate>
                    <asp:Label ID="lbDescription"  runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Supplier">
                <ItemTemplate>
                    <asp:Label ID="lbSupplier"   runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="QTY">
                <ItemTemplate>
                    <asp:Label ID="Label4"  Text='<%# Bind("Ordered_Qty") %>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click"
        CssClass="btn-lg bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White" />
             </div>
        </form>
</asp:Content>

