<%@ Page Title="" Language="C#" MasterPageFile="~/View/Stationery/MasterPage.master" AutoEventWireup="true" CodeFile="RemarkSR.aspx.cs" Inherits="Stationery_decrepancy_RemarkSR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 233px;
        }
        .auto-style2 {
            width: 282px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
    <td class="auto-style2"><asp:Label ID="Label1" runat="server" Text="Itme Code"></asp:Label></td>
          <td class="auto-style1"><asp:Label ID="Label2" runat="server" Text="C001"></asp:Label></td>
            </tr>
        <tr>
    <td class="auto-style2"><asp:Label ID="Label3" runat="server" Text="Description"></asp:Label></td>
          <td class="auto-style1"><asp:Label ID="Label4" runat="server" Text="pen"></asp:Label></td>
            </tr>
        <tr>
    <td class="auto-style2"><asp:Label ID="Label5" runat="server" Text="Needed QTY"></asp:Label></td>
          <td class="auto-style1"><asp:Label ID="Label6" runat="server" Text="10"></asp:Label></td>
            </tr>
        <tr>
            <td> Actual QTY:</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label7" runat="server" Text="Department"></asp:Label></td>
            <td><asp:Label ID="Label8" runat="server" Text="English"></asp:Label></td>
        </tr>
         <tr>
            <td><asp:Label ID="Label9" runat="server" Text="Remark"></asp:Label></td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Height="95px" TextMode="MultiLine" Width="354px"></asp:TextBox> </td>
        </tr>

        </table>
    <asp:Button ID="Button1" runat="server" Text="Save" />
      <asp:Button ID="Button2" runat="server" Text="Cancel" />
</asp:Content>


