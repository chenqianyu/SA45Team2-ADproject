<%@ Page Title="" Language="C#" MasterPageFile="~/View/Stationery/MasterPageforStockClerk.master" AutoEventWireup="true" CodeFile="GeneratePO.aspx.cs" Inherits="View_Stationery_GeneratePO_PurchaseOrderConfirmPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form class="form" runat="server">
        <div class="row">
            <div class="h4">
               &nbsp;&nbsp;&nbsp;&nbsp;Item: <asp:Label ID="lbItem" runat="server" Text="Item:">&nbsp;
                    <asp:DropDownList ID="ddlItemList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlItemList_SelectedIndexChanged"
                        CssClass="btn btn-light dropdown-item" BackColor="#666666" style="-webkit-appearance:button;width:150px">
                   
                    </asp:DropDownList>
                </asp:Label>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="h5">
             &nbsp;&nbsp;&nbsp;   Item Code: &nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbItemCode1" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="h5">
                <asp:Label ID="lbQty" runat="server" Text="Qty:">&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="tbQty" runat="server" TextMode="Number"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegEx" runat="server" ControlToValidate="tbQty" ErrorMessage="Please Enter Positive Number Only" ForeColor="Red" ValidationExpression="^\d+$" Display="Dynamic" />
                    <asp:CompareValidator ID="vdTbQtyMin" runat="server"
                        ControlToValidate="tbQty" Operator="GreaterThanEqual"
                        Display="Dynamic" Type="Integer" SetFocusOnError="true"
                        ValueToCompare="30" ErrorMessage="Minimum order quantity for this item is 30">
</asp:CompareValidator>
                </asp:Label>
            </div>
        </div>
        <br />

        <asp:Button ID="btnAddItem" runat="server" Text="Add Item" OnClick="btnAddItem_Click" Enabled="true"
            CssClass="btn-lg bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White" />
        <br />
        <br />
        <div style="height: 250px,600px initial; width: 80%">
            <asp:GridView ID="gvOrderDetails" runat="server" AutoGenerateColumns="False"
                OnRowCancelingEdit="OnRowCancelingEdit"
                OnRowDeleting="OnRowDeleting"
                OnRowEditing="OnRowEditing"
                OnRowUpdating="OnRowUpdating"
                OnRowDataBound="OnRowDataBound"
                CssClass="table col-1" PagerStyle-CssClass="page-item" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Large"
                RowStyle-Font-Size="Larger">

                <Columns>
                    <asp:TemplateField HeaderText="ItemCode">

                        <ItemTemplate>
                            <asp:Label ID="lbItemNo" Text='<%# Bind("ItemNo") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Description">


                        <ItemTemplate>
                            <asp:Label ID="lbDescription" Text='<%# Bind("ItemDescription") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Supplier">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlSupplier" runat="server"></asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbSupplier" Text='<%# Bind("SupplierName") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="QTY">
                        <EditItemTemplate>
                            <asp:TextBox ID="tbQty" runat="server" Text='<%# Bind("Qty") %>' TextMode="Number" min="1"></asp:TextBox><asp:CompareValidator ID="vdTbQtyIndividualMin" runat="server"
                                ControlToValidate="tbQty" Operator="GreaterThanEqual"
                                Display="Dynamic" Type="Integer" SetFocusOnError="true"
                                ValueToCompare="30" ErrorMessage="Minimum order quantity for this item is 30">
                        </asp:CompareValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbQty" Text='<%# Bind("Qty") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" ButtonType="Button" ShowDeleteButton="True"
                        ControlStyle-CssClass="btn-lg bg-teal " ControlStyle-BorderStyle="None" ControlStyle-Font-Bold="true"
                        ControlStyle-ForeColor="White" />
                </Columns>
            </asp:GridView>
            <br />
        </div>
        <asp:Button ID="btnConfirm" runat="server" Text="Confirm To Order" OnClick="btnConfirm_Click"
            CssClass="btn-lg bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White" />
    </form>
</asp:Content>
