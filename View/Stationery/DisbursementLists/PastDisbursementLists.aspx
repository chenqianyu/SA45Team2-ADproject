<%@ Page Title="" Language="C#" MasterPageFile="~/View/Stationery/MasterPageforStockClerk.master" AutoEventWireup="true" CodeFile="PastDisbursementLists.aspx.cs" Inherits="Stationery_PastDisbursementLists" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form class="form" runat="server">
        <h1>Past Disbursement Lists</h1>
        <br />
        <div class="row">
            <div class="h5">&nbsp;&nbsp;&nbsp;&nbsp;Select Department:&nbsp;&nbsp;&nbsp;</div>
            <div class="col-4">
                <asp:DropDownList ID="ddlDepartment" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                    CssClass="btn btn-light dropdown-item" BackColor="#666666"
                    Style="-webkit-appearance: button" Width="200px">
                    <asp:ListItem>All</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="h5 col-2">
                From Date:&nbsp;&nbsp;
            </div>
            <div class="form-group col-4">
                <asp:TextBox ID="TextBox2" runat="server" Width="447px" TextMode="Date" CssClass="form-control h5 "></asp:TextBox>
                <i class="form-group__bar"></i>
            </div>

        </div>
        <br />
        <div class="row">
            <div class="h5 col-2">
                To Date:&nbsp;&nbsp;
            </div>
            <div class="form-group col-4">
                <asp:TextBox ID="CalanderText" runat="server" Width="447px" TextMode="Date" CssClass="form-control h5"></asp:TextBox>
                <i class="form-group__bar"></i>
            </div>
        </div>
        <br />
        <h3>Disbursement List: </h3>
        <div style="height: 250px,600px initial; width: 60%">
            <asp:GridView ID="gvDisbursement" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                CssClass="table col-3" PagerStyle-CssClass="page-item" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Larger" RowStyle-Font-Size="Large">

                <Columns>
                    <asp:BoundField DataField="Disbursement_Date" HeaderText="Date" />
                    <asp:BoundField DataField="Department_Name" HeaderText="DisbursementID" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="Button1" runat="server" CommandName="Button" CommandArgument='<%# Eval("Department_Name") %>' Text="View"
                                OnClick="PassSession"
                                CssClass="btn-lg bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White" />

                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
            
        <br />

    </form>
</asp:Content>

