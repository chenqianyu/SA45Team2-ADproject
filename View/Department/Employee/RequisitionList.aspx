<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageforEmployee.master" AutoEventWireup="true" CodeFile="RequisitionList.aspx.cs" Inherits="Department_Employee_RequistionList" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form class="form" runat="server">
        <br />
        <br />
        <br />
        <br />
        <div style="min-height:100px;max-height:600px initial;width:80% "> 
        <asp:GridView ID="gvViewReqisition" runat="server" AutoGenerateColumns="false" OnRowCommand="gvViewReqisition_RowCommand" DataKeyNames="Requisition_No"
            OnSelectedIndexChanged="gvViewReqisition_SelectedIndexChanged" OnRowDeleting="gvViewReqisition_RowDeleting"
            OnRowDataBound="gvViewReqisition_RowDataBound" OnRowEditing="gvViewReqisition_RowEditing" OnRowUpdating="gvViewReqisition_RowUpdating1"
            AllowPaging="true" PageSize="10" OnPageIndexChanging="gvViewReqisition_PageIndexChanging"
            CssClass="table" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Large" AlternatingRowStyle-Width="400px">
            <Columns>
                <asp:TemplateField HeaderText="Requisition_No">
                    <ItemTemplate>
                        <asp:Label ID="lblReq" Text='<%#Eval("Requisition_No") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Approval_Timestamp">
                    <ItemTemplate>
                        <asp:Label Text='<%#Eval("Approval_Timestamp") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" Text='<%#Eval("Status") %>' runat="server" />
                    </ItemTemplate>

                </asp:TemplateField>

                <asp:TemplateField HeaderText="Submission_Timestamp">
                    <ItemTemplate>
                        <asp:Label Text='<%#Eval("Submission_Timestamp") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Remarks">
                    <ItemTemplate>
                        <asp:Label Text='<%#Eval("Remarks") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>



                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnSelect" runat="server" CommandName="select" ToolTip='<%#Eval("Status") %>' Text="Select" Visible="false" CssClass="btn-lg bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White" />
                        <asp:Button ID="btnEdit" runat="server" CommandName="Delete" Text="Cancel" Visible="false" CssClass="btn-lg bg-red" BorderStyle="None" Font-Bold="true" ForeColor="White" />

                    </ItemTemplate>

                </asp:TemplateField>
            </Columns>
        </asp:GridView>
            </div>


        <br />



        <br />
        <h4>
        <asp:Label ID="lblRequisition" runat="server" Text="List Of Requisition Items" Font-Bold="true" Visible="false"></asp:Label>
            </h4>
        <br />
        <br />
         <div style="min-height:250px;max-height:600px initial;width:80% "> 
        <asp:GridView ID="gvRequisitionList" runat="server" AutoGenerateColumns="false" OnRowCancelingEdit="gvRequisitionList_RowCancelingEdit" OnRowEditing="gvRequisitionList_RowEditing"
            OnRowUpdating="gvRequisitionList_RowUpdating" OnRowDeleting="gvRequisitionList_RowDeleting"
            CssClass="table" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Large" AlternatingRowStyle-Width="400px">
            <Columns>
                <asp:TemplateField HeaderText="Requisition_No">
                    <ItemTemplate>
                        <asp:Label ID="lblReqReq" Text='<%#Eval("Requisition_No") %>' runat="server" />
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Item_No">
                    <ItemTemplate>
                        <asp:Label ID="lblItemNo" Text='<%#Eval("Item_No") %>' runat="server" />
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description">
                    <ItemTemplate>
                        <asp:Label Text='<%#Eval("Description") %>' runat="server" />
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Requested_Qty">
                    <ItemTemplate>
                        <asp:Label Text='<%#Eval("Requested_Qty") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtReqQty" Text='<%#Eval("Requested_Qty") %>' runat="server" />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:Label ID="lblQuantityStatus" Text='<%#Eval("Status") %>' runat="server" />
                    </ItemTemplate>

                </asp:TemplateField>


                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnEdits" runat="server" CommandName="Edit" Visible="false" Text="Edit" CssClass="btn-lg bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White" />
                        <asp:Button ID="btnDelete" runat="server" CommandName="Delete" Visible="false" Text="Delete" CssClass="btn-lg bg-red" BorderStyle="None" Font-Bold="true" ForeColor="White" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Button ID="btnUpdate" runat="server" CommandName="Update" Text="Save" CssClass="btn-lg bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White" />
                        <asp:Button ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn-lg bg-red" BorderStyle="None" Font-Bold="true" ForeColor="White"/>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>
             </div>


        <br />
        <table id="myTable">
        </table>
    </form>
</asp:Content>
