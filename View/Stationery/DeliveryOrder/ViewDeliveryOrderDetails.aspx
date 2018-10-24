<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/View/Stationery/MasterPageforStockClerk.master" CodeFile="ViewDeliveryOrderDetails.aspx.cs" Inherits="View_Stationery_ViewDeliveryOrderDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <form id="form1" class="form" runat="server">
    <h2>
        面积View Delivery Order Details
    </h2>
   
    <div>
        <div style="height:250px,600px initial;width:80% ">
        <asp:GridView ID="gvPODetails" runat="server" AutoGenerateColumns="false" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" OnRowUpdating="OnRowUpdating"
                    DataKeyNames="Item_No" CellPadding="10"
             CssClass="table col-2" PagerStyle-CssClass="page-item"  HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Large" AlternatingRowStyle-Width="400px">

                       <Columns>
                <asp:BoundField DataField="Item_No" HeaderText="ItemNo" ReadOnly="true"/>
                <asp:BoundField DataField="Category" HeaderText="Category" ReadOnly="true" />
                <asp:BoundField DataField="Description" HeaderText="Description" ReadOnly ="true"/>
                <asp:BoundField DataField="Unit_of_Measure" HeaderText="Unit of Measure" ReadOnly ="true"/>
                <asp:BoundField DataField="Ordered_Qty" HeaderText="Ordered Qty" ReadOnly ="true" />
                <asp:TemplateField HeaderText="Delivered Qty">
                    <EditItemTemplate>
                        <div class="form-group">
                        <asp:TextBox ID="tbDeliveredQty" CssClass="form-control" runat="server" Text='<%# Bind("Delivered_Qty") %>'></asp:TextBox>
                         <i class="form-group__bar"></i>    
                        </div>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblDeliveredQty" runat="server" Text='<%# Bind("Delivered_Qty") %>' ForeColor="White"
                             ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ControlStyle-CssClass="btn bg-teal" ButtonType="Button" ShowDeleteButton="False" ShowEditButton="True" ShowSelectButton="False" 
                    ControlStyle-BorderStyle="None" ControlStyle-Font-Bold="true" ControlStyle-ForeColor="White"  />
            </Columns>
        </asp:GridView>
        </div>
                <br />
                <asp:Button ID="btnAcknowledge" runat="server" Text="Acknowledge" OnClick="btnAcknowledge_Click"
                     CssClass="btn-lg bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White" />
                <br />
                <br />
                <asp:Label ID="lbStatus" CssClass="h5" runat="server" Text=""></asp:Label>
                <br />
                 <br />
                <asp:Label ID="lbAdjVouchers" CssClass="h5" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    </form>
</asp:Content>

