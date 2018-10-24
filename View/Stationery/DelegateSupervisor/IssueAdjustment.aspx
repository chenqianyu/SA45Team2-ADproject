<%@ Page Title="" Language="C#" MasterPageFile="~/View/Stationery/MasterPageForDelegateSupervisor.master" AutoEventWireup="true" CodeFile="IssueAdjustment.aspx.cs" Inherits="Stationery_Supervisior_IssueAdjustment" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form class="from" runat="server">
    <style type="text/css">
        #TextArea1 {
            width: 237px;
            margin-left: 3px;
        }
    </style>
    <h2>Pending Voucher Adjustment Acknowledgement:</h2>
        <br />
        <div style="height:250px,600px initial;width:100% ">
    <asp:GridView ID="gvPendingAdjustments" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true"
          CssClass="data-table" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Medium" HeaderStyle-Width="500px">
       
        <Columns>
            <asp:BoundField DataField="Item_No" HeaderText="Item Code" />
            <asp:BoundField DataField="Description" HeaderText="Description" />
            <asp:BoundField DataField="Unit_of_Measure" HeaderText="Unit of Measurement" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
            <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
            <asp:BoundField DataField="Employee_ID" HeaderText="Emp ID" />
            <asp:BoundField DataField="Employee_Name" HeaderText="Emp Name" />
            <asp:BoundField DataField="Raised_Date" HeaderText="Submitted Date" />
            <asp:BoundField DataField="totalValue" HeaderText="Total Value (SGD)" />
            <asp:TemplateField HeaderText="Acknowledge">
                <ItemTemplate>
                    <asp:Button ID="btnAcknowledge" runat="server" Text="Acknowledge" OnClick="btnAcknowledge_Click"></asp:Button>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>
            </div>
    <br />
    <asp:Button ID="btnAcknowledgeAll" runat="server" Text="Acknowledge All" OnClick="btnAcknowledgeAll_Click"
        CssClass="btn-lg bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White"/>
    <br />
    <br />
    <asp:Label ID="lbStatus" CssClass="h4" runat="server" Text=""></asp:Label>
    <br />
    <br />
    <h2>Acknowledged Voucher Adjustments:</h2>
        <br />
        <div style="height:250px,600px initial;width:100% ">
    <asp:GridView ID="gvAcknowledgedAdjustments" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true"
        CssClass="data-table" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Medium" HeaderStyle-Width="500px">
       
        <Columns>
            <asp:BoundField DataField="Item_No" HeaderText="Item Code" />
            <asp:BoundField DataField="Description" HeaderText="Description" />
            <asp:BoundField DataField="Unit_of_Measure" HeaderText="Unit of Measurement" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
            <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
            <asp:BoundField DataField="Employee_ID" HeaderText="Emp ID" />
            <asp:BoundField DataField="Employee_Name" HeaderText="Emp Name" />
            <asp:BoundField DataField="Raised_Date" HeaderText="Submitted Date" />
            <asp:BoundField DataField="totalValue" HeaderText="Total Value (SGD)" />
            <asp:BoundField DataField="Acknowledgement_Date" HeaderText="Acknowledged Date" />
        </Columns>

    </asp:GridView>
            </div>
    </form>
</asp:Content>
