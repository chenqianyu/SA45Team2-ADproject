<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageforDelegateDepartmenthead.master" AutoEventWireup="true" CodeFile="ViewRequisitionsLists.aspx.cs" Inherits="Departmenthead_Default" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form class="form" runat="server">
    <script type="text/javascript" language="javascript">
        function CheckAllEmp(Checkbox) {
            var GridVwHeaderChckbox = document.getElementById("<%=gvRequisitionList.ClientID %>");
            for (i = 1; i < GridVwHeaderChckbox.rows.length; i++) {
                if (GridVwHeaderChckbox.rows[i].cells[5].getElementsByTagName("INPUT")[0].disabled == false) {
                    GridVwHeaderChckbox.rows[i].cells[5].getElementsByTagName("INPUT")[0].checked = Checkbox.checked;
                }
            }
        }
    </script>

    <br />
    <h2>Requisitions Forms</h2>
    <br />
        <asp:Button CssClass="btn bg-green" ID="btnViewPending" runat="server" Text="View Pending" OnClick="btnViewPending_Click" BorderStyle="None" Font-Bold="true" ForeColor="White"  />
        <asp:Button CssClass="btn bg-info" ID ="btnViewAll" runat="server" Text="View All" OnClick="btnViewAll_Click" BorderStyle="None" Font-Bold="true" ForeColor="White" /> 
    <br/>
    <div style="height:250px,600px initial;width:80% ">
        <asp:GridView ID="gvRequisitionList"   AutoGenerateColumns="false" runat="server" AllowPaging="true" PageSize="10" OnPageIndexChanging="gvRequisitionList_PageIndexChanging" 
            CssClass="table col-2" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Large" AlternatingRowStyle-Width="400px">
            <Columns>
                <asp:TemplateField HeaderText="Remarks(Optional)">
                    <HeaderTemplate>
                        <asp:Label ID="lbRequisitionNumberHeader" runat="server" Text="Requisition Number"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbRequisitionNumber" runat="server" Text='<%# Eval("DepartmentID") + "/" + Eval("EmployeeID") + "/" + Eval("RequisitionNumber")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name" />
                <asp:BoundField DataField="ApprovalStatus" HeaderText="Approval Status" />
                <asp:TemplateField HeaderText="Remarks(Optional)">
                    <ItemTemplate>
                        <asp:TextBox ID="tbRemarks" runat="server" Height="25" Visible='<%# (Eval("ApprovalStatus").ToString() == "Pending")%>' Text='<%#Bind("Remarks") %>'>></asp:TextBox>
                        <asp:Label ID="lbRemarks" runat="server" Text='<%# Eval("Remarks")%>' Visible='<%# (Eval("ApprovalStatus").ToString() != "Pending")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="lbViewDetails" runat="server" Text="View Details"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtnViewDetails" runat="server" OnClick="lbtnViewDetails_Click" >
                            View Details
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="cbSelectAll" runat="server" onclick="CheckAllEmp(this);"/>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="cbSelect" runat="server" Enabled='<%# (Eval("ApprovalStatus").ToString() == "Pending")%>' BorderStyle="None"></asp:CheckBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </div>
        <br />
        <div class="row">
        <div class="col-3">
        <asp:Button ID="btnApprove" runat="server" Text="Approve Selected"  OnClick="btnApprove_Click" CssClass="btn-lg bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White" />
            </div>
        <div class="col-3">
        <asp:Button ID="btnReject" runat="server" Text="Reject Selected" OnClick="btnReject_Click" CssClass="btn-lg bg-red" BorderStyle="None" Font-Bold="true" ForeColor="White" />
            </div>
            </div>
    
        </form>
</asp:Content>