<%@ Page Title="" Language="C#" MasterPageFile="~/View/Stationery/MasterPageforStockClerk.master" AutoEventWireup="true" CodeFile="StationeryRetrievalForm.aspx.cs" Inherits="View_Stationery_decrepancy_StationeryRetrievalForm" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form runat="server">
    <p>
        <br />

        <asp:Button ID="btnGenerateSRF" runat="server" Text="Generate Retrieval Form" OnClick="btnGenerateSRF_Click"
            CssClass="btn-lg bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White"/>
    &nbsp;&nbsp;&nbsp;
        <asp:Button ID="bntPastSRF" runat="server" Text="View Past SRF" OnClick="bntPastSRF_Click"
               CssClass="btn-lg bg-green" BorderStyle="None" Font-Bold="true" ForeColor="White"/>
    </p>
    <p>
        <asp:DropDownList ID="ddlPastretrieve" Visible="false" AutoPostBack="true" Enabled="false" runat="server" OnSelectedIndexChanged="ddlPastretrieve_SelectedIndexChanged" AppendDataBoundItems="true"
             CssClass="btn btn-light dropdown-item" BackColor="#666666" style="-webkit-appearance:button;width:150px;height:auto;">             
        </asp:DropDownList>
    </p>
   
        <div style="height:250px,600px initial;width:80%" >
        <asp:GridView ID="gvSrfbyid" runat="server" AutoGenerateColumns="false" OnRowCommand="gvSrfbyid_RowCommand" DataKeyNames="Item_Code" OnRowEditing="gvSrfbyid_RowEditing" OnRowCancelingEdit="gvSrfbyid_RowCancelingEdit" OnRowUpdating="gvSrfbyid_RowUpdating"
           CssClass="table" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Large" RowStyle-Font-Size="Larger" AlternatingRowStyle-Width="300px">
       
            <Columns>
                <asp:TemplateField HeaderText="ItemNo" SortExpression="Item_Code">
                   
                    <ItemTemplate>
                        <asp:Label ID="lbItemNo" runat="server" Text='<%# Bind("Item_Code") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description" SortExpression="Item_Description">
                   
                    <ItemTemplate>
                        <asp:Label ID="lbDesc" runat="server" Text='<%# Bind("Item_Description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Retrieved">
                    <ItemTemplate>
                        <asp:Label ID = "lbRetrieved" Text='<%#Eval("QuantityToGiveOut") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbRetrieved" Text='<%#Eval("QuantityToGiveOut") %>'  runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorRetrieved" runat="server" ErrorMessage="Please enter the quantity retrieved"
      ControlToValidate="tbRetrieved" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorRetrieved2" runat="server" ControlToValidate="tbRetrieved"
    ErrorMessage="Please Enter Only Numerics" ForeColor="Red" ValidationExpression="^\d+$" Display="Dynamic">        </asp:RegularExpressionValidator>
                    </EditItemTemplate>
                    </asp:TemplateField>
                <asp:TemplateField HeaderText="Remarks">
                    <ItemTemplate>
                        <asp:Label ID="lbRemarks" Text='<%#Eval("Remarks") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbRemarks" Text='<%#Eval("Remarks") %>' runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorRemarks" runat="server" ErrorMessage="Please enter remarks"
      ControlToValidate="tbRemarks" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnView" runat="server" CommandName="ViewByDept" Text="ViewByDept" CommandArgument='<%# Bind("Item_Code") %>'
                             CssClass="btn bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White"/>
                        <asp:Button ID="btnEdit" runat="server" CommandName="Edit" Text="Edit" CommandArgument='<%# Bind("Item_Code") %>' 
                             CssClass="btn bg-red" BorderStyle="None" Font-Bold="true" ForeColor="White"/>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Button ID="btnUpdate" runat="server" CommandName="Update" Text="Update"
                             CssClass="btn bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White" />
                        <asp:Button ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancel" CausesValidation="false"
                         CssClass="btn bg-red" BorderStyle="None" Font-Bold="true" ForeColor="White"/>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
            </div>
   
    <p>
        &nbsp;</p>

       <br />
            <div style="height:250px,600px initial;width:80%" >
        <asp:GridView ID="gvPastSRFbyid" runat="server" AutoGenerateColumns="false" OnRowCommand="gvPastSRFbyid_RowCommand" OnSelectedIndexChanged="gvPastSRFbyid_SelectedIndexChanged" DataKeyNames ="Item_Code"
             CssClass="table" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Large" RowStyle-Font-Size="Larger" AlternatingRowStyle-Width="300px">
<Columns>
                <asp:TemplateField HeaderText="ItemNo" SortExpression="Item_Code">
                   
                    <ItemTemplate>
                        <asp:Label ID="lbItemNo" runat="server" Text='<%# Bind("Item_Code") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description" SortExpression="Item_Description">
                   
                    <ItemTemplate>
                        <asp:Label ID="lbDesc" runat="server" Text='<%# Bind("Item_Description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Retrieved">
                    <ItemTemplate>
                        <asp:Label ID = "lbRetrieved" Text='<%#Eval("QuantityToGiveOut") %>' runat="server" />
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Retrieval ID">
                    <ItemTemplate>
                        <asp:Label ID = "lbRetrievalID" Text='<%#Eval("Retrieval_ID") %>' runat="server" />
                    </ItemTemplate>
                    </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnView2" runat="server" CommandName="Select" Text="ViewByDept" CommandArgument='<%# Bind("Retrieval_ID") %>' 
                             CssClass="btn bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White"/>
                      </ItemTemplate>
                </asp:TemplateField>
</Columns>
        </asp:GridView>
                </div>
    
         <br />
    <br />
        <div style="height:250px,600px initial;width:80%" >
        <asp:GridView ID="gvSrfbyiddept" runat="server" AutoGenerateColumns="false"
              CssClass="table" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Large" RowStyle-Font-Size="Larger" AlternatingRowStyle-Width="300px">
 <Columns>
            <asp:BoundField DataField="Item_Code" HeaderText="ItemNo" SortExpression="Item_Code" />
            <asp:BoundField DataField="Item_Description" HeaderText="Description" SortExpression="Item_Description" />
             <asp:BoundField DataField="Dept_Name" HeaderText="Department" SortExpression="Dept_Name" />
             <asp:BoundField DataField="QuantityToGiveOut" HeaderText="Retrieved" SortExpression="QuantityToGiveOut" />
            </Columns>
        </asp:GridView>
            </div>
    
    <p>
     &nbsp;&nbsp;    <asp:Button ID="btnConfirm" runat="server" OnClick="btnConfirm_Click" Enabled="false" Text="Confirm"
             CssClass="btn-lg bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White" />
    </p>
</form>
</asp:Content>