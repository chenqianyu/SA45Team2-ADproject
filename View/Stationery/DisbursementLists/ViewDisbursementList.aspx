<%@ Page Title="" Language="C#" MasterPageFile="~/View/Stationery/MasterPageforStockClerk.master" AutoEventWireup="true" CodeFile="ViewDisbursementList.aspx.cs" Inherits="View_Stationery_DisbursementLists_Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form class="form" runat="server">
        <asp:Label ID="lbDisbursement1" CssClass="h4" runat="server" Text="Please select a department:"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <br />
        <div class="row">
            <div class="col-3">
                <asp:DropDownList ID="ddlDisbursement" runat="server" AutoPostBack="True"
                    OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                    CssClass="btn btn-light dropdown-item" BackColor="#666666"
                    Style="-webkit-appearance: button">
                </asp:DropDownList>
            </div>
            <div class="col-3">
                <asp:Button ID="viewPastDisbursement" runat="server" OnClick="Button1_Click" Text="View Past Disbursement"
                    CssClass="btn-lg bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White" />
            </div>
        </div>
        <br />
        <div class="row">
        <h5>&nbsp;&nbsp;&nbsp; DisbursementID:&nbsp;</h5>
        <h5> <asp:Label ID="lbDisbursementID" runat="server"></asp:Label></h5>
        &nbsp;&nbsp;&nbsp;
            </div>
        <br />
        <div class="row">
        <h5>&nbsp;&nbsp;&nbsp; Collection Point:<asp:Label ID="lbDisbursement3" runat="server"></asp:Label></h5>
            </div>
        <br />
        <div class="row">
        <h5>
         &nbsp;&nbsp;&nbsp;&nbsp;Edit By:&nbsp;&nbsp;</h5>
        <h5>
        <asp:Label ID="lbDisbursement5" runat="server" ValidateRequestMode="Disabled" Text="203"></asp:Label>
            </h5>
            </div>
        <br />
        Item Details
        <div style="height: 250px,600px initial; width: 80%">
            <asp:GridView ID="gvDisbursement1" runat="server" AutoGenerateColumns="False" Width="677px"
                OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="gridviewUpdating"
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged1"
                CssClass="table col-1" PagerStyle-CssClass="page-item" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Large">
                <Columns>
                    <asp:TemplateField HeaderText="Item Name">
                        <ItemTemplate>
                            <asp:Label ID="lbDisbursement1" runat="server" Font-Size="Large" Text='<%# Bind("Description") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity to give">
                        <EditItemTemplate>
                            <div class="form-group">
                                <asp:TextBox ID="tbDisbursement2" runat="server" Font-Size="Large" CssClass="form-control bg-light" Text='<%# Bind("QuantityToGive") %>' ControlToValidate="tbDisbursement2"></asp:TextBox>
                                <i class="form-group__bar"></i>
                                <asp:Literal ID="ltDisbursementInEdit" runat="server"></asp:Literal> 
                                &nbsp; &nbsp; &nbsp; &nbsp;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter quantity" Font-Strikeout="False" ControlToValidate="tbDisbursement2"></asp:RequiredFieldValidator>
                            </div>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbDisbursement2" runat="server" Font-Size="Large" Text='<%# Bind("QuantityToGive") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Remark" Visible="False">
                        <EditItemTemplate>
                            <div class="form-group">
                                <asp:TextBox ID="tbDisbursement3" CssClass="form-control bg-light" runat="server"></asp:TextBox>
                                <i class="form-group__bar input-slider--red"></i>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter quantity" Font-Strikeout="False" ControlToValidate="tbDisbursement3"></asp:RequiredFieldValidator>
                                     
                            </div>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:LinkButton ID="lkbDisbursement1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"
                                Font-Size="Large"></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="lkbDisbursement2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"
                                Font-Size="Large"></asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="lkbDisbursement1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"
                                Font-Size="Large"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Literal ID="ltDisbursement" runat="server"></asp:Literal> 
                           
        </div>
  
        <h4 />
        Representative Name: &nbsp;
        <asp:Label CssClass="h4" ID="lbDisbursement4" runat="server"></asp:Label>
        <h4 />
        <br />
        <br />
    </form>
</asp:Content>

