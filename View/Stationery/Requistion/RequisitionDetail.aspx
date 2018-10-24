<%@ Page Title="" Language="C#" MasterPageFile="~/View/Stationery/MasterPageforStockClerk.master" AutoEventWireup="true" CodeFile="RequisitionDetail.aspx.cs" Inherits="View_Stationery_Requistion_RequisitionDetail" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <h1 align="center">Requisition Detail</h1>    
    <table class="table">
        <tr>
            <td class="col-2 h5">
                <asp:Label ID="lbRNo" runat="server" Text="<b>Requisition Number:</b>"></asp:Label>
            </td>
            <td class="col-2 h5">
                <asp:Label ID="txtRNo" runat="server" ></asp:Label>
            </td>
        </tr>     
        <tr>
            <td class="col-2 h5">
                <asp:Label ID="lbDepName" runat="server" Text="<b>Department Name:</b>"></asp:Label>
            </td>
            <td class="col-2 h5">
                <asp:Label ID="txtDepName" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="col-2 h5">
                <asp:Label ID="lbDepCode" runat="server" Text="<b>Department Code:</b>"></asp:Label>
            </td>
            <td class="col-2 h5">
                <asp:Label ID="txtDepCode" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="col-2 h5">
                <asp:Label ID="lbEmpName" runat="server" Text="<b>Employee Name:</b>"></asp:Label>
            </td >
            <td class="col-2 h5">
                <asp:Label ID="txtEmpName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="col-2 h5">
                <asp:Label ID="lbEmpID" runat="server" Text="<b>Employee ID:</b>"></asp:Label>
            </td>
            <td class="col-2 h5">
                <asp:Label ID="txtEmpID" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="col-2 h5">
                <asp:Label ID="lbEmpEmail" runat="server" Text="<b>Employee Email Address:</b>"></asp:Label>
            </td>
            <td class="col-2 h5">
                <asp:Label ID="txtEmpEmail" runat="server" ></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <asp:Label ID="lbRequestedItem" CssClass="h4" runat="server" Text="<b>Requested Items:</b>"></asp:Label>
    <br />
      <div style="height:250px,600px initial;width:80%" >
    <asp:GridView ID="gvRequisitionDetails" runat="server" AutoGenerateColumns="False"  OnRowDataBound="OnRowDataBound"
         CssClass="table col-2" PagerStyle-CssClass="page-item" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Large" AlternatingRowStyle-Width="400px">
        <Columns>
            <asp:BoundField DataField="Item_No" HeaderText="Item_No" SortExpression="Item_No" />
                <asp:TemplateField HeaderText="Description">
                    <ItemTemplate>
                        <asp:Label ID="lblDescription" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            
            <asp:BoundField DataField="Requested_Qty" HeaderText="Requested_Qty" SortExpression="Requested_Qty" />
                <asp:BoundField DataField="Actual_Qty" HeaderText="Actual_Qty" SortExpression="Actual_Qty" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />        
        </Columns>
    </asp:GridView>
          </div>
</asp:Content>