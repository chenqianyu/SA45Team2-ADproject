<%@ Page Title="" Language="C#" MasterPageFile="~/View/Stationery/MasterPageforStockClerk.master" AutoEventWireup="true" CodeFile="InventoryList.aspx.cs" Inherits="Adproject_team2_Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form class="form" runat="server">
    <h1>Inventory management</h1>
    <h2>Category by:<asp:DropDownList ID="DDLcatagory1" runat="server" DataTextField="Category" 
        DataValueField="Category" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1" 
         CssClass="btn btn-light dropdown-item" BackColor="#666666"
                    Style="-webkit-appearance: button" Width="200px">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SSIS_Team02Model %>" SelectCommand="SELECT DISTINCT [Category] FROM [ItemCatalog]" OnSelecting="SqlDataSource1_Selecting"></asp:SqlDataSource>
    &nbsp;
    </h2>

    <p>  
        <div style="height: 250px,600px initial; width: 80%">
        <asp:GridView ID="GVcatagory1" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="OnPaging" OnRowCommand="PassSession" AllowSorting="True"
            CssClass="table" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Large" AlternatingRowStyle-Width="400px">

<AlternatingRowStyle Width="400px"></AlternatingRowStyle>

            <Columns>
                <asp:BoundField DataField="ItemNo" HeaderText="ItemNo"/>
                <asp:BoundField DataField="Category" HeaderText="Catagory" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:BoundField DataField="Reorder Level" HeaderText="Reorder Level" />
                <asp:BoundField DataField="Reorder Quantity" HeaderText="Reorder Quantity" />
                <asp:BoundField DataField="Unit of Measure" HeaderText="Unit Of Measure" />
                <asp:BoundField DataField="Total Quantity"  HeaderText="Total Quantity" />
                <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" HtmlEncode="False"  />
                <asp:BoundField DataField="Allocated Quantity" HeaderText="Allocated Quantity" />
                <asp:TemplateField>
    <ItemTemplate>
        <asp:Button ID="Button1" runat="server" CommandName="Button" CommandArgument='<%# Eval("ItemNo") %>' Text="Edit" 
                    OnClick="PassSession" 
            CssClass="btn bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White"/> 
	
    </ItemTemplate>
</asp:TemplateField>
            </Columns>

<HeaderStyle Font-Bold="True" Font-Size="Large"></HeaderStyle>

        </asp:GridView>
            </div>
        <br />
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="New Inventory" OnClick="Button1_Click" 
            CssClass="btn bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White"/>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="Return"
            CssClass="btn bg-red" BorderStyle="None" Font-Bold="true" ForeColor="White" />
    &nbsp;&nbsp;
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
        </form>
</asp:Content>

