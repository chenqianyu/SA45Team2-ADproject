<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageforEmployee.master" AutoEventWireup="true" CodeFile="RaiseRequisition.aspx.cs" Inherits="View_Department_Employee_RaiseRequisition" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form class="form" runat="server">
    <input type="hidden" id="refreshed" value="no">

    <script type="text/javascript">
       jQuery(document).ready(function()
        {
                var d = new Date();
                d = d.getTime();
                if (jQuery('#reloadValue').val().length == 0)
                {
                        jQuery('#reloadValue').val(d);
                        jQuery('body').show();
                }
                else
                {
                        jQuery('#reloadValue').val('');
                        location.reload();
                }
        });
   </script>
    <asp:DropDownList ID="ddlItemCategory" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlItemCategory_SelectedIndexChanged" AppendDataBoundItems="true"
    CssClass="btn btn-light dropdown-item" BackColor="#666666" style="-webkit-appearance:button;width:150px">
    </asp:DropDownList>
        <div style="height:250px,600px initial;width:80% ">
    <asp:GridView ID="gvItemCatalog" runat="server" AutoGenerateSelectButton="false" CellPadding="3" GridLines="Vertical"
        AutoGenerateColumns="False" Style="margin-top: 38px" AllowPaging="True" PageSize="12" OnPageIndexChanging="gvItemCatalog_PageIndexChanging"
        CssClass="table col-2" PagerStyle-CssClass="page-item"  HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Large" AlternatingRowStyle-Width="400px">

        <Columns>
            <asp:BoundField DataField="Item_No" HeaderText="Item_No" ReadOnly="True" SortExpression="Item_No" />
            <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />

            <asp:BoundField DataField="Unit_of_Measure" HeaderText="Unit_of_Measure" SortExpression="Unit_of_Measure" />

            <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />

            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="txtQuantity" TextMode="Number" runat="server" /> <asp:RangeValidator runat="server" Type="Integer" 
MinimumValue="1" MaximumValue="2147483647" ForeColor="Red" ControlToValidate="txtQuantity" 
ErrorMessage="Value should be greater than 0" Display="Dynamic" />
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>

<%--        <AlternatingRowStyle BackColor="#DCDCDC" />
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />--%>

    </asp:GridView>
            </div>
    <br />
    <asp:Button ID="btnAddToCart" runat="server" Height="46px" Text="AddToCart" Width="118px" OnClick="btnAddToCart_Click"
         CssClass="btn-lg bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White" />
    <br />
    <br />
    <br />
    <br />
    <br />
         <div style="height:250px,600px initial;width:80% ">
    <asp:GridView ID="gvCheckOut" runat="server" OnRowCommand="gvCheckOut_RowCommand" OnRowEditing="gvCheckOut_RowEditing" OnRowCancelingEdit="gvCheckOut_RowCancelingEdit"
        OnRowDeleting="gvCheckOut_RowDeleting" OnRowUpdating="gvCheckOut_RowUpdating" AutoGenerateColumns="False" 
         CssClass="data-table col-3" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Large" AlternatingRowStyle-Width="400px">
       
        <Columns>
            <asp:TemplateField HeaderText="ItemNumber">
                <ItemTemplate>
                    <asp:Label Text='<%#Eval("Item_No") %>' runat="server" />
                </ItemTemplate>

            </asp:TemplateField>
            <asp:TemplateField HeaderText="Description">
                <ItemTemplate>
                    <asp:Label Text='<%#Eval("Description") %>' runat="server" />
                </ItemTemplate>

            </asp:TemplateField>

            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:Label Text='<%#Eval("Allocated_Qty") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtQuantityChange" Text='<%#Eval("Allocated_Qty") %>' runat="server" />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnEdit" runat="server" CommandName="Edit" Text="Edit" CssClass="btn-lg bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White"/>
                    <asp:Button ID="btnDelete" runat="server" CommandName="Delete" Text="Delete" CssClass="btn-lg bg-red" BorderStyle="None" Font-Bold="true" ForeColor="White" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Button ID="btnSave" runat="server" CommandName="Update" Text="Save" CssClass="btn-lg bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White"/>
                    <asp:Button ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn-lg bg-red" BorderStyle="None" Font-Bold="true" ForeColor="White"/>
                </EditItemTemplate>
            </asp:TemplateField>

        </Columns>
     <%--   <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
        <RowStyle BackColor="White" ForeColor="#003399" />
        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        <SortedAscendingCellStyle BackColor="#EDF6F6" />
        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
        <SortedDescendingCellStyle BackColor="#D6DFDF" />
        <SortedDescendingHeaderStyle BackColor="#002876" />--%>
    </asp:GridView>
             </div>
    <br />
    <br />
    <br />
        
    <asp:Button ID="btnCheckOut" Text="Check Out" OnClick="btnCheckOut_Click" runat="server" Visible="false" 
        CssClass="btn-lg bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White" />
         
    </form>
</asp:Content>
