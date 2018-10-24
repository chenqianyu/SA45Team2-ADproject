<%@ Page Title="" Language="C#" MasterPageFile="~/View/Stationery/MasterPageforStockClerk.master" AutoEventWireup="true" CodeFile="DetailsOfPastItem.aspx.cs" Inherits="View_Stationery_DisbursementLists_DetailsOfPastItem" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form class="form" runat="server">
    <div class="row">
     <h5>
    DepartmentName: &nbsp;<asp:Label ID="Label5" runat="server"></asp:Label>
         </h5>
    
        </div>
        <br />
         <div class="row">
             <h5>
    DisbursementID:&nbsp;
    <asp:Label ID="Label2" runat="server"></asp:Label>
                 </h5>
    &nbsp;&nbsp;&nbsp;
             </div>
    <br />
        <div class="row">
             <h5>
     Collection Point: &nbsp;&nbsp;<asp:Label ID="Label3" runat="server"></asp:Label>
                  </h5>
    &nbsp;&nbsp;&nbsp;
             </div>
    <br />
   <div class="row">
             <h5>
    Item Details
     </h5>
    &nbsp;&nbsp;&nbsp;
             </div>
    <div style="height: 250px,600px initial; width: 60%">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="677px"
            CssClass="table col-2" PagerStyle-CssClass="page-item" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Large" AlternatingRowStyle-Width="400px">
            <Columns>
                <asp:TemplateField HeaderText="Item Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quantity to give">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("QuantityToGive") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("QuantityToGive") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <div class="row">
        <div class="col-3">
            <h4>Representative Name:
            </h4>
        </div>
        <div class="col-3">
            <asp:Label ID="Label4" runat="server" CssClass="h4"></asp:Label>
        </div>
    </div>
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Return"
        CssClass="btn-lg bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White" />
    <br />
    <br />
        </form>
</asp:Content>

