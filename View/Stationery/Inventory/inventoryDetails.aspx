<%@ Page Title="" Language="C#" MasterPageFile="~/View/Stationery/MasterPageforStockClerk.master" AutoEventWireup="true" CodeFile="InventoryDetails.aspx.cs" Inherits="Adproject_team2_Default2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form class="form" runat="server">
    <h2>Detail views of : Clip</h2>
   
    <asp:Table CssClass="table" ID="Table1" runat="server" Width="2000px">
        
       <asp:TableRow runat="server" Width="300px">
           <asp:TableCell>Item Number:</asp:TableCell>
           <asp:TableCell><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></asp:TableCell>
       </asp:TableRow>
        <asp:TableRow runat="server" Width="400px">
            <asp:TableCell>Category:</asp:TableCell>
           <asp:TableCell><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
               <asp:DropDownList ID="DropDownList1" runat="server" Visible="False" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1"
                CssClass="btn btn-light dropdown-item" BackColor="#666666" style="-webkit-appearance:button;width:150px"/>
                   
</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" Width="400px">
            <asp:TableCell>Description:</asp:TableCell>
           <asp:TableCell>
               <div class="form-group">
               <asp:TextBox ID="TextBox2" Font-Size="Larger" CssClass="from-control" runat="server" Text=""></asp:TextBox>
                   <i class="form-group__bar"></i>
               </div>
           </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" Width="400px">
            <asp:TableCell>Reorder Level</asp:TableCell>
           <asp:TableCell>
                <div class="form-group">
               <asp:TextBox ID="TextBox3" Font-Size="Larger" CssClass="from-control" runat="server" Text=""></asp:TextBox>
                   <i class="form-group__bar"></i>
                       <asp:RegularExpressionValidator id="RegularExpressionValidator1"
                   ControlToValidate="TextBox3"
                   ValidationExpression="\d+"
                   Display="Static"
                   EnableClientScript="true"
                   ErrorMessage="Please enter numbers only"
                   runat="server"/>
               </div>
           </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" Width="400px">
            <asp:TableCell>Reorder Qty</asp:TableCell>
           <asp:TableCell>
                <div class="form-group">
               <asp:TextBox ID="TextBox4" Font-Size="Larger" CssClass="from-control" runat="server" Text=""></asp:TextBox>
                   <i class="form-group__bar"></i>
                    <asp:RegularExpressionValidator id="RegularExpressionValidator2"
                   ControlToValidate="TextBox4"
                   ValidationExpression="\d+"
                   Display="Static"
                   EnableClientScript="true"
                   ErrorMessage="Please enter numbers only"
                   runat="server"/>
               </div>
           </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" Width="400px">
            <asp:TableCell>Unit of Measure</asp:TableCell>
           <asp:TableCell> <div class="form-group">
               <asp:TextBox ID="TextBox5" Font-Size="Larger" CssClass="from-control" runat="server" Text=""></asp:TextBox>
                   <i class="form-group__bar"></i>
            
               </div></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" Width="400px">
            <asp:TableCell>Quantity</asp:TableCell>
           <asp:TableCell> <div class="form-group">
               <asp:Label ID="Label3" Font-Size="Larger" CssClass="from-control" runat="server" Text=""></asp:Label>
                   <i class="form-group__bar"></i>
               </div></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" Width="400px">
            <asp:TableCell>Price</asp:TableCell>
           <asp:TableCell>    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></asp:TableCell>
        </asp:TableRow>
                <asp:TableRow runat="server" Width="400px">
            <asp:TableCell>Allocated Quantity</asp:TableCell>
           <asp:TableCell><asp:Label ID="Label5" runat="server" Text="Label"></asp:Label></asp:TableCell>
        </asp:TableRow>
         <asp:TableRow runat="server" Width="400px">
            <asp:TableCell> <asp:Literal ID="Situation" runat="server" Text=""></asp:Literal></asp:TableCell>
           <asp:TableCell><asp:Button ID="Edit" runat="server" Text="Edit" OnClick="Edit_Clicked" 
               CssClass="btn bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White"/>
               <asp:Button ID="return" runat="server" Text="return" OnClick="Return_Clicked"
                   CssClass="btn bg-red" BorderStyle="None" Font-Bold="true" ForeColor="White"/>
           </asp:TableCell>
        </asp:TableRow>
        
    </asp:Table>
    </form>
</asp:Content>

