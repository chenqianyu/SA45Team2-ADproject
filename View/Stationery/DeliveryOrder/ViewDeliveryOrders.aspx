<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/View/Stationery/MasterPageforStockClerk.master" CodeFile="ViewDeliveryOrders.aspx.cs" Inherits="View_Stationery_ViewDeliveryOrders" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>Pending Delivery Orders
    </h2>
    <br />
    <form id="form1" class="form" runat="ser
        <div>
            <div style="height:250px,600px initial;width:80% ">
            <asp:GridView ID="gvPOList" runat="server" AutoGenerateColumns="false" CellPadding="10"
                CssClass="table col-2" PagerStyle-CssClass="page-item" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Large" AlternatingRowStyle-Width="400px">

                <Columns>
                    <asp:TemplateField HeaderText="PO Number">
                        <ItemTemplate>
                            <asp:Label ID="lbPONo" runat="server" Text='<%# Bind("PO_No") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Supplier_Name" HeaderText="Supplier Name" ReadOnly="true" />
                    <asp:TemplateField HeaderText="PO Date" SortExpression="PO_Date">
                        <ItemTemplate>
                            <asp:Label ID="lbPODate" runat="server" Text='<%# Bind("PO_Date","{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Expected Delivery Date" SortExpression="PO_Date">
                        <ItemTemplate>
                            <asp:Label ID="lbExpectedDeliverDate" runat="server" Text='<%# Bind("Expected_Delivery_Date","{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="View Details">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbView" runat="server" Text="View" OnClick="lbView_Click"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
                </div>
            <br />
            <h5>
            <asp:Label ID="lbStatus" CssClass="h4" runat="server" Text=""></asp:Label>
                </h5>
            <br />
            <h2>Past Delivered Orders
            </h2>
             <br />
            <div style="height:250px,600px initial;width:80% ">
            <asp:GridView ID="gvAcknowledged" runat="server" AutoGenerateColumns="false" CellPadding="10" ShowHeaderWhenEmpty="true"
                CssClass="table col-2" PagerStyle-CssClass="page-item" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Large" AlternatingRowStyle-Width="400px">
                <Columns>
                    <asp:TemplateField HeaderText="PO Number">
                        <ItemTemplate>
                            <asp:Label ID="lbPONo" runat="server" Text='<%# Bind("PO_No") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Supplier_Name" HeaderText="Supplier Name" ReadOnly="true" />
                    <asp:TemplateField HeaderText="PO Date" SortExpression="PO_Date">
                        <ItemTemplate>
                            <asp:Label ID="lbPODate" runat="server" Text='<%# Bind("PO_Date","{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Actual Delivery Date" SortExpression="PO_Date">
                        <ItemTemplate>
                            <asp:Label ID="lbActualDeliverDate" runat="server" Text='<%# Bind("Actual_Delivery_Date","{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="View Details">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbView" runat="server" Text="View" OnClick="lbView_Click"
                                 CssClass="btn-lg bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
                </div>
            <br />
            <asp:Label ID="lbStatus2" CssClass="h5"  ForeColor="#ff0000" runat="server" Text=""></asp:Label>
            <br />
        </div>
    </form>
</asp:Content>
