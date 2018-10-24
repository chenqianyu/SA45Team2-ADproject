<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageforDepartmentRep.master" AutoEventWireup="true" CodeFile="CollectionPoint.aspx.cs" Inherits="Department_DepartmentRep_Default" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form class="form" runat="server">
        <h1>Selection of Collection Point
        </h1>
        <br />
        <br />
        <h4>Current Collection Point:</h4>
         <br />
        <h5>
            <asp:Label ID="lbCollectPt" runat="server" Text=""></asp:Label>
        </h5>
         <br />
        <h4>Select a Collection Point:</h4>
         <br />
        <div class="form-group">
            <asp:RadioButtonList ID="rbCollectionPt" runat="server" DataTextField="Description" DataValueField="Description" RepeatColumns="3" RepeatDirection="Horizontal" Font-Bold="True" Font-Size="Medium"></asp:RadioButtonList>
        </div>
        <p>
            <asp:Button ID="btnSubmit" runat="server" Text="Confirm" OnClick="btnSubmit_Click" CssClass="btn-lg bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White" />
        </p>

        <asp:Label ID="lbStatus" runat="server" Text="" ForeColor="Blue"></asp:Label>
        <br />
        <br />
        <br />
        <br />
    </form>
</asp:Content>

