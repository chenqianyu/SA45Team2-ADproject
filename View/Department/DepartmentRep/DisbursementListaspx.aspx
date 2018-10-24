 <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageforDepartmentRep.master" AutoEventWireup="true" CodeFile="DisbursementListaspx.aspx.cs" Inherits="DepartmentRep_DisbursementListaspx" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form runat="server" class="form">
    <div style="align-content">
      <h1>Disbursement Status</h1>
     </div>
    <br />
    <br />
    <asp:GridView ID="gvItemToGiveOutToDepartment" runat="server" AutoGenerateColumns="False" align="center" DataKeyNames="item_Code">
        <Columns>
            <asp:TemplateField HeaderText="Item_Description">                
                <ItemTemplate>
                        <asp:Label ID="lbItemDescription" runat="server" Text='<%# Bind("Item_Description") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="QuantityToGiveOut">                
                <ItemTemplate>
                        <asp:Label ID="lbQuantityToGiveOut" runat="server" Text='<%# Bind("QuantityToGiveOut") %>'></asp:Label>
                 </ItemTemplate>
            </asp:TemplateField>            
        </Columns>
    </asp:GridView>
    <br />
    <asp:Table ID="tbRepresentative" runat="server"  Width="510px">
        <asp:TableRow>
            <asp:TableCell><b>Representative Name: </b></asp:TableCell>
            <asp:TableCell><b>
                <asp:Label ID="lbRepresentative" runat="server" Text=""></asp:Label></b>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <table>
        <tr>
            <td>
                    <asp:CheckBox ID="cbAcknowledge" runat="server" />  <asp:Label ID="lbAcknowledgeLetter" runat="server" Text="I Acknowledge the receipt of Items Listed are in Good Condition"></asp:Label>
            </td>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnAcknowledge" runat="server" Text="Acknowledge" OnClick="btnAcknowledge_Click" CssClass="auto-style1" Width="153px" />
            </td>
        </tr>
    </table>
    <br /> 
        </form>
</asp:Content>