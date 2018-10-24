<%@ Page Title="" Language="C#" MasterPageFile="~/View/Stationery/MasterPage.master" AutoEventWireup="true" CodeFile="abcd.aspx.cs" Inherits="Stationery_decrepancy_abcd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    Choose Date:<asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Date:"></asp:Label><asp:Label ID="Label2" runat="server" Text="12/9/2018"></asp:Label>
    <asp:Table runat="server" GridLines="Both" BorderStyle="Solid">
        <asp:TableHeaderRow>
             <asp:TableHeaderCell>

             </asp:TableHeaderCell>
           
            <asp:TableHeaderCell>Stationary Description</asp:TableHeaderCell>
             <asp:TableHeaderCell>Needed Total Quantity</asp:TableHeaderCell>
             <asp:TableHeaderCell>Actual Total Quantity</asp:TableHeaderCell>
            <asp:TableHeaderCell>View</asp:TableHeaderCell>
           
            
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>C001</asp:TableCell>
             <asp:TableCell>Pencil</asp:TableCell>
            <asp:TableCell>10</asp:TableCell>
             <asp:TableCell>9</asp:TableCell>
           
            <asp:TableCell Font-Underline ForeColor="Blue"> View</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>D002</asp:TableCell>
            <asp:TableCell>Stapler</asp:TableCell>
            <asp:TableCell>7</asp:TableCell>
            <asp:TableCell>5</asp:TableCell>
            
            <asp:TableCell Font-Underline ForeColor="Blue"> View</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>S005</asp:TableCell>
            <asp:TableCell>Pen</asp:TableCell>
            <asp:TableCell>19</asp:TableCell>
            <asp:TableCell>15</asp:TableCell>
            
            <asp:TableCell Font-Underline ForeColor="Blue"> View</asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
