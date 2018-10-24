<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageforDelegateDepartmenthead.master" AutoEventWireup="true" CodeFile="AssignRep.aspx.cs" Inherits="Departmenthead_AssignRep" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form class="form" runat="server">
        <h2>Selection of Department Representative </h2>
        <br />
        <br />
        <div class="row">
            <div class="col-4">
            <h3>Current Representative:</h3>
                </div>
            <div class="col-3">
            <h4><asp:Label ID="lbCurrentRep" runat="server" Text=""></asp:Label></h4>
            </div>
        </div>
        <div class="row"></div>
        <br />
        <br />
        <div class="row">
            <div class="col-4">
                <h3>Department Representative: </h3>
            </div>
        
        <div class="col-4">
            <div class="dropdown">
                <asp:DropDownList ID="ddlEmployees" runat="server"
                     CssClass="btn btn-light dropdown-item" BackColor="#666666"
                     style="-webkit-appearance:button"></asp:DropDownList>
            </div>
        </div>
            </div>
        <br />
        <br />
        <p>
            <asp:Button ID="btnSubmit" runat="server" Text="Confirm" OnClick="btnSubmit_Click" CssClass="btn-lg bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White" />
        </p>
        <asp:Label ID="lbStatus" runat="server" Text=""></asp:Label>
    </form>
</asp:Content>
