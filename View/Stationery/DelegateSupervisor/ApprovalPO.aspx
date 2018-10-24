<%@ Page Title="" Language="C#" MasterPageFile="~/View/Stationery/MasterPageForDelegateSupervisor.master" AutoEventWireup="true" CodeFile="ApprovalPO.aspx.cs" Inherits="Stationery_Supervisior_ApprovalPO" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form class="table" runat="Server">
 <h2>Purchase Order Details</h2>     
    
    <p>
        Purchase Order :
        <asp:Label ID="lbPurchaseOrder" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        Supplier Name :
        <asp:Label ID="lbSupplierName" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbDeliveryDate" runat="server" Text="Label"></asp:Label>
    </p>
    <div class="row">
        <div class="h4 col3">
        Please supply the following items by &nbsp;
            </div>
        <div class="col3">
        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
            </div>
    </div>
    
        <div style="height:250px,600px initial;width:80% ">
        <asp:GridView ID="gvPurchaseOrderDetail" runat="server" AutoGenerateColumns="False" CellPadding="3" CellSpacing="2" OnRowDataBound="gvPurchaseOrderDetail_RowDataBound" CssClass="table col-2" PagerStyle-CssClass="page-item" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Large" AlternatingRowStyle-Width="400px">
            <Columns>
                <asp:BoundField DataField="Item_No" HeaderText="Item" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                 <asp:TemplateField HeaderText="Quantity">           
                     <ItemTemplate>
                         <asp:Label ID="lbQuantity" runat="server" Text='<%# Bind("Ordered_Qty") %>'></asp:Label>
                     </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Price">
                   
                    <ItemTemplate>
                        <asp:Label ID="lbPrice" runat="server" Text='<%# Bind("Price") %>' ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Amount">
                    <ItemTemplate>
                        <asp:Label ID="lbAmount" runat="server" ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
            </Columns>
     </asp:GridView>
            </div>
   
    <p>
        &nbsp;</p>
    <p>
       <h5> Total Amount :</h5>
        <asp:Label ID="lbTotalAmount" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
       <h5> Ordered by : </h5>
        <asp:Label ID="lbOrderBy" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Date:
        <asp:Label ID="lbDate" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:Button ID="btnApprove" runat="server" Text="Approve" OnClick="btnApprove_Click"
            CssClass="btn-lg bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White" />
        <asp:Button ID="btnReject" runat="server" Text="Reject" OnClick="btnReject_Click" 
            CssClass="btn-lg bg-red" BorderStyle="None" Font-Bold="true" ForeColor="White"/>
       
<%--        <asp:Button ID="Button1" runat="server" Text="Approve" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="Reject" />--%>
        <br />
    </p>

        </form>
</asp:Content>
