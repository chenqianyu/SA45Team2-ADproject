<%@ Page Title="" Language="C#" MasterPageFile="~/View/Stationery/MasterPage.master" AutoEventWireup="true" CodeFile="abcd.aspx.cs" Inherits="Stationery_decrepancy_abcd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br/>
    <h3 align="center">Stationary Retrival</h3>
    <br />
    <br />
    <asp:Table runat="server" GridLines="Both" BorderStyle="Solid">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>No</asp:TableHeaderCell>
            <asp:TableHeaderCell>Stationary Description</asp:TableHeaderCell>
            <asp:TableHeaderCell>Needed Total Quantity</asp:TableHeaderCell>
            <asp:TableHeaderCell>Actual Total Quantity</asp:TableHeaderCell>
            <asp:TableHeaderCell>Dept Name</asp:TableHeaderCell>
            <asp:TableHeaderCell>Needed Quantity</asp:TableHeaderCell>
            <asp:TableHeaderCell>Actual Quantity</asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>2</asp:TableCell>
            <asp:TableCell>Pencil</asp:TableCell>
            <asp:TableCell>10</asp:TableCell>
            <asp:TableCell>9</asp:TableCell>
            <asp:TableCell>Zool</asp:TableCell>
            <asp:TableCell>3</asp:TableCell>
            <asp:TableCell>3</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>2</asp:TableCell>
            <asp:TableCell>Pencil</asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell>REGR</asp:TableCell>
            <asp:TableCell>5</asp:TableCell>
            <asp:TableCell>4</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>2</asp:TableCell>
            <asp:TableCell>Pencil</asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell>COMM</asp:TableCell>
            <asp:TableCell>2</asp:TableCell>
            <asp:TableCell>2</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>4</asp:TableCell>
            <asp:TableCell>Stapler</asp:TableCell>
            <asp:TableCell>7</asp:TableCell>
            <asp:TableCell>5</asp:TableCell>
            <asp:TableCell>COMM</asp:TableCell>
            <asp:TableCell>4</asp:TableCell>
            <asp:TableCell>2</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>4</asp:TableCell>
            <asp:TableCell>Stapler</asp:TableCell>
            <asp:TableCell> </asp:TableCell>
            <asp:TableCell> </asp:TableCell>
            <asp:TableCell>CPSC</asp:TableCell>
            <asp:TableCell>3</asp:TableCell>
            <asp:TableCell>3</asp:TableCell>
        </asp:TableRow>
    </asp:Table>
<asp:Button ID="Button1" runat="server" Text="Print" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="Button2" runat="server" Text="Button" />
<br />
</asp:Content>
