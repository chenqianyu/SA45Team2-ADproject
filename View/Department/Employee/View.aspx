<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageforEmployee.master" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="Department_Employee_View" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form class="form" runat="server">
        <p>
            <br />
        </p>
        <p style="margin-left: 80px">
            <asp:Label ID="Label1" runat="server" CssClass="h5" Text="Requisition Form#"></asp:Label>
            &nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" CssClass="h5" Text="DDS/111/99"></asp:Label>
        </p>
        <p style="margin-left: 80px">
            <asp:Label ID="Label3" runat="server" CssClass="h5" Text="Department Name"></asp:Label>
            &nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label4" runat="server" CssClass="h5" Text="Department of English"></asp:Label>
        </p>
        <p style="margin-left: 80px">
            <asp:Label ID="Label5" runat="server" CssClass="h5" Text="Department Code"></asp:Label>
            &nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label6" runat="server" CssClass="h5" Text="DDS"></asp:Label>
        </p>
        <p style="margin-left: 80px">
            <asp:Label ID="Label7" runat="server" CssClass="h5" Text="Employee Name"></asp:Label>
            &nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label8" runat="server" CssClass="h5" Text="Herry"></asp:Label>
        </p>
        <p style="margin-left: 80px">
            <asp:Label ID="Label9" runat="server" CssClass="h5" Text="Employee Number"></asp:Label>
            &nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label10" runat="server" CssClass="h5" Text="11233"></asp:Label>
        </p>
        <p style="margin-left: 80px">
            <asp:Label ID="Label11" runat="server" CssClass="h5" Text="Employee Email Address"></asp:Label>
            &nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label12" runat="server" CssClass="h5" Text="herry@ssis.com"></asp:Label>
        </p>
       
            <h4 style="margin-left: 80px">Category:</h4>
        <p></p>
        <br />
        <br />
        <div style="height: 250px,600px initial; width: 80%;left:0px">
            <asp:GridView ID="GridView1" runat="server" Style="margin-left: 149px" AutoGenerateColumns="False"
                CssClass="table col-2" PagerStyle-CssClass="page-item" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Large" AlternatingRowStyle-Width="400px">
                <Columns>
                    <asp:BoundField DataField="Catalogue Item Code" HeaderText="Catalogue Item Code" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />

                </Columns>
            </asp:GridView>
        </div>
        <p>
        </p>
        <p>
        </p>
    </form>
</asp:Content>

