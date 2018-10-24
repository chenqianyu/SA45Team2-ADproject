<%@ Page Title="" Language="C#" MasterPageFile="~/View/Stationery/MasterPageForDelegateSupervisor.master" AutoEventWireup="true" CodeFile="Approvalpending.aspx.cs" Inherits="Stationery_Supervisior_Approvalpending" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form class="form" runat="server">
    <h2>Purchase Orders Pending Approval:</h2>
    <br />
    <table>
        <tr>
            <td class="h4">
                <asp:Label ID="lbDropDown" runat="server" Text="Choose Purchase Order Status: &nbsp;"></asp:Label>
                
            </td>
            <td>
             <asp:DropDownList ID="ddlPOAll" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPOAll_SelectedIndexChanged" 
                    CssClass="btn btn-light dropdown-item" BackColor="#666666" style="-webkit-appearance:button;width:150px">
                    <asp:ListItem Text="All" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Pending" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Approved" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Rejected" Value="3"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
    </table>
        <div style="height:250px,600px initial;width:80%" >
    <asp:GridView ID="gvPurchaseOrder" runat="server" AutoGenerateColumns="False"  DataKeyNames="Supplier_ID" OnRowDataBound="OnRowDataBound" OnRowCommand="gvPurchaseOrder_RowCommand" AllowPaging="true" OnPageIndexChanging="OnPaging" PageSize="10" 
         CssClass="table col-2" PagerStyle-CssClass="page-item"  HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Large" AlternatingRowStyle-Width="400px">
        <Columns>
            <asp:BoundField DataField="PO_NO" HeaderText="Purchase Order Number" />
            <asp:BoundField DataField="PO_Date" HeaderText="Purchase Order Date" />
          
    
            <asp:TemplateField HeaderText="Supplier">
                 <ItemTemplate>
                        <asp:Label ID="lbSupplierName" runat="server"></asp:Label>
                    </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Status">
                 <ItemTemplate>
                        <asp:Label ID="lbStatus" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                    </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <ItemTemplate>
                     <asp:LinkButton ID="lbView" runat="server" CommandName="gvPurchaseOrder" CommandArgument='<%# Bind("PO_No") %>' >View</asp:LinkButton>
                  </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
            </div>
    <br />
        </form>
</asp:Content>