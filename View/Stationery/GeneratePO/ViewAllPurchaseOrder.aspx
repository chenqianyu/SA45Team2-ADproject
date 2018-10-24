<%@ Page Title="" Language="C#" MasterPageFile="~/View/Stationery/MasterPageforStockClerk.master" AutoEventWireup="true" CodeFile="ViewAllPurchaseOrder.aspx.cs" Inherits="View_Stationery_GeneratePO_ViewAllPurchaseOrder" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form class="form" runat="server">
        <div class="row">
            <h2>Generate Purchase Order:</h2>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            <asp:CompareValidator ID="cvtxtStartDate" runat="server"
                ControlToCompare="tbStartDate" CultureInvariantValues="true"
                Display="None" EnableClientScript="true"
                ControlToValidate="tbEndDate"
                ErrorMessage="Start date must be earlier than finish date"
                Type="Date" SetFocusOnError="true" Operator="GreaterThanEqual"></asp:CompareValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None"
                ControlToValidate="tbStartDate" ForeColor="Red"
                ErrorMessage="Please choose Start Date">Start Date is required</asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="None"
                ControlToValidate="tbEndDate" ForeColor="Red"
                ErrorMessage="Please choose End Date">End Date is required</asp:RequiredFieldValidator>
        </div>
        <asp:Button ID="btnGeneratePurchaseOrder" runat="server" Text="GeneratePurchaseOrder" OnClick="btnGeneratePurchaseOrder_Click" CausesValidation="false"
            CssClass="btn bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White" /><br />
        <br />
        <div class="row">
            <div class="col-lg-2 h5">
                Start Date: 
            </div>
            <div class="form-group col-lg-2 h5 ">
                <asp:TextBox ID="tbStartDate" runat="server" CssClass="form-control" BorderStyle="None" TextMode="Date"></asp:TextBox>
                <i class="form-group__bar"></i>
            </div>

            <div class="col-lg-2 h5">
                End Date:
            </div>
            <div class="form-group col-lg-2 h5">
                <asp:TextBox ID="tbEndDate" runat="server" CssClass="form-control" BorderStyle="None" TextMode="Date"></asp:TextBox>
                <i class="form-group__bar"></i>
            </div>
        </div>

        <div class="row">
             &nbsp;&nbsp; &nbsp;&nbsp; 
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="FilterByDate" CommandName="searchByDate"
                CssClass="btn bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White" />
            &nbsp;&nbsp;
  
    <asp:Button ID="btnSearchAll" runat="server" Text="View All" OnClick="loadAll" CausesValidation="false"
        CssClass="btn bg-green" BorderStyle="None" Font-Bold="true" ForeColor="White" />
        </div>
        <br />
        <div style="height: 250px,600px initial; width: 80%">
            <asp:GridView ID="gvPurchaseOrder" runat="server" AutoGenerateColumns="False" OnRowCommand="gvPurchaseOrder_RowCommand" OnRowDataBound="gvPurchaseOrder_RowDataBound" DataKeyNames="PO_No" AllowPaging="true"
                OnPageIndexChanging="OnPaging" PageSize="10"
                CssClass="table" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Large" AlternatingRowStyle-Width="400px">

                <Columns>
                    <asp:TemplateField HeaderText="PONumber">
                        <ItemTemplate>
                            <asp:Label ID="lbPoNO" runat="server" Text='<%# Bind("PO_NO") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Supplier">
                        <ItemTemplate>
                            <asp:Label ID="lbSupplierName" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date">
                        <ItemTemplate>
                            <asp:Label ID="lbPoDate" runat="server" Text='<%# ((DateTime)Eval("PO_date")).ToShortDateString() %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbView" runat="server" CommandName="gvPurchaseOrder" CommandArgument='<%# Bind("PO_No") %>' CausesValidation="false">View</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>


                </Columns>
            </asp:GridView>
        </div>
    </form>

</asp:Content>

