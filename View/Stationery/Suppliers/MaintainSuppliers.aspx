<%@ Page Title="" Language="C#" MasterPageFile="~/View/Stationery/MasterPageforStockClerk.master" AutoEventWireup="true" CodeFile="MaintainSuppliers.aspx.cs" Inherits="Stationery_Suppliers_MaintainSuppliers" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form runat="server" class="form">
    <h1>
Supplier Information</h1>
    <p>
        &nbsp;</p>
    <p>
        <div style="height:250px,600px initial;width:80% ">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" 
            OnSelectedIndexChanged="PassSession" DataKeyNames="Supplier_ID" 
            CssClass="table" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Large" AlternatingRowStyle-Width="300px">

            <Columns>
                <asp:BoundField DataField="Supplier_ID" HeaderText="Supplier_ID" />
                <asp:BoundField DataField="Supplier_Name" HeaderText="Supplier_Name" />
                <asp:BoundField DataField="Contact_Name" HeaderText="Contact_Name" />
                <asp:BoundField DataField="Phone" HeaderText="Phone" />
                <asp:BoundField DataField="Address" HeaderText="Address" HeaderStyle-Width="300px" ItemStyle-Width="400px"/>
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" CommandName="Edit" Text="Edit" OnClick="PassSession" CommandArgument='<%# Bind("Supplier_ID") %>' 
                            CssClass="btn-lg bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
            </div>

       <h5>Testing:</h5> &nbsp;&nbsp; <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </p></form>
</asp:Content>

