<%@ Page Title="" Language="C#" MasterPageFile="~/View/Stationery/MasterPageforStockClerk.master" AutoEventWireup="true" CodeFile="SupplierDetails.aspx.cs" Inherits="Stationery_Suppliers_SupplierDetails" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form runat="server" class="form">
    <h1>Supplier Details</h1>
    <p>
    </p>
           
    <asp:Table CssClass="table" ID="Table2" runat="server" Width="600px" border="1" Height="100px">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server" Font-Size="Large" Width="5px">Supplier ID: </asp:TableCell>
            <asp:TableCell runat="server" Width="100px">
                            <div class="form-group">
               <asp:TextBox ID="TextBox7" Font-Size="Larger" CssClass="form-control "  runat="server" Text=""></asp:TextBox>
                   <i class="form-group__bar"></i>
               </div>
                </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server" Width="5px" Font-Size="Large">Supplier Name: </asp:TableCell>
            <asp:TableCell runat="server" Width="100px">
                <div class="form-group">
               <asp:TextBox ID="TextBox8" Font-Size="Larger" CssClass="form-control " runat="server" Text=""></asp:TextBox>
                   <i class="form-group__bar"></i>
               </div>
                </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server" Width="5px" Font-Size="Large">Contact Name: </asp:TableCell>
            <asp:TableCell runat="server" Width="100px" ForeColor="#CC0000">
               <div class="form-group">
               <asp:TextBox ID="TextBox9" Font-Size="Larger" CssClass="form-control "  runat="server" Text=""></asp:TextBox>
                   <i class="form-group__bar"></i>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox9" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
               </div>
                </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server" Width="5px" Font-Size="large">Phone: </asp:TableCell>
            <asp:TableCell runat="server" Width="100px" ForeColor="#CC0000">
                <div class="form-group">
               <asp:TextBox ID="TextBox10" CssClass="form-control "  Font-Size="Larger" runat="server" Text=""></asp:TextBox>
                   <i class="form-group__bar"></i>
               </div>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="TextBox10"
                    ValidationExpression="\d{7}" Display="Static" ErrorMessage="Phone must be 7 numeric digits" EnableClientScript="False" runat="server" />
            </asp:TableCell></asp:TableRow><asp:TableRow runat="server">
            <asp:TableCell runat="server" Width="5px" Font-Size="Large">Address: </asp:TableCell><asp:TableCell runat="server" Width="100px" ForeColor="#CC0000">
                <div class="form-group">
               <asp:TextBox ID="TextBox11" Font-Size="Larger" CssClass="form-control "  runat="server" Text=""></asp:TextBox>
                  <i class="form-group__bar"></i>
               </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox11" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
            </asp:TableCell></asp:TableRow><asp:TableRow runat="server">
            <asp:TableCell runat="server" Width="5px" CssClass="form-control "  Font-Size="Large">Email: </asp:TableCell><asp:TableCell runat="server" Width="100px" ForeColor="#CC0000">          
                <div class="form-group">
               <asp:TextBox ID="TextBox12" CssClass="form-control " Font-Size="Larger" runat="server" Text=""></asp:TextBox>
                   <i class="form-group__bar"></i>
               </div>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic"
                    ErrorMessage="Wrong Email Format" ControlToValidate="TextBox12" ValidationExpression="^[a-zA-Z0-9]{1,}@[a-zA-Z0-9]{1,}.(com|net|org|edu|mil|cn|cc)$"></asp:RegularExpressionValidator>
            </asp:TableCell></asp:TableRow></asp:Table><asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click"
        CssClass="btn-lg bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White"/>
    </form>
</asp:Content>
