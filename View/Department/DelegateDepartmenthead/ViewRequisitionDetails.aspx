<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageforDelegateDepartmenthead.master" AutoEventWireup="true" CodeFile="ViewRequisitionDetails.aspx.cs" Inherits="Departmenthead_ViewRequisitionDetails" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form class="form" runat="server">
        
        <h1>Requisition Detail</h1>
        <br/>
        <br/>
        <h2>Requisition Form Number:</h2>&nbsp;<asp:Label ID="lbReqFormNumber" runat="server" Text="N/A"></asp:Label>
        <br />
        <b>Employee Name:</b>&nbsp;<asp:Label ID="lbEmployeeName" runat="server" Text="N/A"></asp:Label>
        <br />
        <br />
        <b>Requested Items:</b>
        <div style="height:250px,600px;width:80% ">
        <asp:GridView ID="gvRequisitionDetails" AutoGenerateColumns="false" runat="server" CssClass="table"  HeaderStyle-Font-Size="Large">
            <Columns>
                <asp:BoundField DataField="ItemNumber" HeaderText="Item Number" />
                <asp:BoundField DataField="ItemDescription" HeaderText="Description" />
                <asp:BoundField DataField="RequestedQty" HeaderText="Requested Qty" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="lbRemarks" runat="server" Text=""></asp:Label>
        <br />
        <asp:TextBox ID="tbRemarks" Height="200" Width="300" runat="server" TextMode="SingleLine" Visible="false"></asp:TextBox>
        <br />
        <br />
        </div>
        <asp:Button ID="btnApprove" runat="server" Text="Approve" OnClick="BtnApprove_Click" CssClass="btn-lg bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White"  />&nbsp; &nbsp;
   
        <asp:Button ID="btnReject" runat="server" Text="Reject" OnClick="BtnReject_Click" CssClass="btn-lg bg-red" BorderStyle="None" Font-Bold="true" ForeColor="White"  />
    </form>
</asp:Content>
