<%@ Page Title="" Language="C#" MasterPageFile="~/View/Stationery/MasterPageforManager.master" AutoEventWireup="true" CodeFile="Relinquish.aspx.cs" Inherits="Departmenthead_Relinquish" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form class="form" runat="server">

        <asp:Panel ID="Panel" runat="server">

            <table class="table-inverse">
                <tr>
                    <td class="col-3">
                        <asp:Label ID="lbRevokeAuthority" runat="server" Text=" Revoke Authority"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="col-3">
                        <asp:Label ID="lbDelegateName" runat="server" Text="  Delegate Name :"></asp:Label>
                    </td>


                    <%-- <td><asp:DropDownList ID="ddlItemList" runat="server" Width="282px" AutoPostBack="True" OnSelectedIndexChanged="ddlItemList_SelectedIndexChanged" >

           </asp:DropDownList></td>--%>
                    <td class="col-3">
                        <asp:Label ID="lbName" runat="server" Text="Label"></asp:Label></td>
                </tr>

                <tr>
                    <td class="col-3">
                        <asp:Label ID="lbFrom" runat="server" Text="From :"></asp:Label></td>
                    <td class="col-4">
                        <asp:Label ID="lbStartDate" runat="server" Text="Label"></asp:Label></td>

                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>

                    <td class="col-3">
                        <asp:Label ID="lbTo" runat="server" Text=" To :"></asp:Label></td>
                    <td class="col-4">
                        <asp:Label ID="lbEndDate" runat="server" Text="Label"></asp:Label></td>

                </tr>


                <%--<tr>
            <td>
                 <asp:Label ID="lbReason" runat="server" Text="Reason:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbInput" runat="server" TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                
            </td>

        </tr>--%>
                <tr>
                    <td></td>
                </tr>
                <tr>

                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Relinquish" OnClick="btnSubmit_Click" CssClass="btn-lg bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White" /></td>


                    <td>
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn-lg bg-red" BorderStyle="None" Font-Bold="true" ForeColor="White" /></td>

                </tr>
            </table>

        </asp:Panel>
    </form>

</asp:Content>
