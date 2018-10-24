<%@ Page Title="" Language="C#" MasterPageFile="~/View/Stationery/MasterPageforStockClerk.master" AutoEventWireup="true" CodeFile="RequisitionsList.aspx.cs" Inherits="Stationery_RequisitionsList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <form class="form" runat="server">
    <h1 align ="center">Requisition List</h1>    
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
    <asp:CompareValidator id="cvtxtStartDate" runat="server" 
     ControlToCompare="tbStartDate" cultureinvariantvalues="true" 
     display="None" enableclientscript="true"  
     ControlToValidate="tbEndDate" 
     ErrorMessage="Start date must be earlier than finish date"
     type="Date" setfocusonerror="true" Operator="GreaterThanEqual"   ></asp:CompareValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" display="None"
    ControlToValidate="tbStartDate" ForeColor="Red"
    ErrorMessage="Please choose Start Date">Start Date is required</asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" display="None"
    ControlToValidate="tbEndDate" ForeColor="Red"
    ErrorMessage="Please choose End Date">End Date is required</asp:RequiredFieldValidator>        
    <table class="table-inverse" style="height:250px,600px initial;width:80% ">
        <tr>
            <td class="col-2 h5">
                 Start Date:
                </td>
            <td class="col-2 h5">
                 <div class="form-group">
              <asp:TextBox ID="tbStartDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                   <i class="form-group__bar"></i>
                     </div>
            </td>
            </tr>  
        <tr>
            <td class="col-2 h5">
            End Date: 
                </td>
                <td class="col-2 h5">
                  <div class="form-group">
                   <asp:TextBox ID="tbEndDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                   <i class="form-group__bar"></i>
               </div>
            </td>    
            </tr>
        <tr>        
            <td >
             &nbsp;&nbsp;&nbsp;  <asp:Button ID="btnShowAll" runat="server" Text="Show All" OnClick="btnShowAll_Click"
                   CssClass="btn-lg bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnApproveFulfilled" runat="server" Text="Approved List" OnClick="btnApproveFulfilled_Click" 
                CssClass="btn-lg bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White" />
            </td>
            <td></td>
        </tr>        
    </table>
    <br />
    <br />
       <div style="height:250px,600px initial;width:80%" >
    <asp:GridView ID="gvRequisitionStatus1" runat="server" AutoGenerateColumns="False" OnRowCommand="gvRequisition_RowCommand1" DataKeyNames="Requisition_No" AllowPaging="true"
    OnPageIndexChanging="OnPageIndexChanging" PageSize="7"
    CssClass="table" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Large" RowStyle-Font-Size="Larger" AlternatingRowStyle-Width="300px">

        <Columns>
            <asp:TemplateField HeaderText="Requisition_No">
                 <ItemTemplate>
                        <asp:Label ID="lblRequestion_NO" runat="server" Text='<%# Bind("Requisition_No") %>'></asp:Label>
                    </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Requestion_Date">
                 <ItemTemplate>
                        <asp:Label ID="lblRequisition_Date" runat="server" Text='<%# Bind("Approval_TimeStamp") %>'></asp:Label>
                    </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Requestion_Status">
                 <ItemTemplate>
                        <asp:Label ID="lblRequisition_Status" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                    </ItemTemplate>
            </asp:TemplateField>         
            
            <asp:TemplateField>
                <ItemTemplate>
                     <asp:LinkButton ID="lnkDetail" runat="server" CommandName="gvRequisitionStatus1" CommandArgument='<%# Bind("Requisition_No") %>' >Details</asp:LinkButton>
                  </ItemTemplate>
            </asp:TemplateField>            
            
        </Columns>
    </asp:GridView>
           </div>
           <br />
           <div style="height: 250px,600px initial; width: 80%">
    <asp:GridView ID="gvRequisitionStatus2" runat="server" AutoGenerateColumns="False" OnRowCommand="gvRequisition_RowCommand2" DataKeyNames="Requisition_No" AllowPaging="true"
    OnPageIndexChanging="OnPageIndexChanging2" PageSize="7"
         CssClass="table" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Large" RowStyle-Font-Size="Larger" AlternatingRowStyle-Width="400px">

        <Columns>
            <asp:TemplateField HeaderText="Requisition_No">
                 <ItemTemplate>
                        <asp:Label ID="lblRequestion_NO" runat="server" Text='<%# Bind("Requisition_No") %>'></asp:Label>
                    </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Requestion_Date">
                 <ItemTemplate>
                        <asp:Label ID="lblRequisition_Date" runat="server" Text='<%# Bind("Approval_TimeStamp") %>'></asp:Label>
                    </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Requestion_Status">
                 <ItemTemplate>
                        <asp:Label ID="lblRequisition_Status" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                    </ItemTemplate>
            </asp:TemplateField>         
            
            <asp:TemplateField>
                <ItemTemplate>
                     <asp:LinkButton ID="lnkDetail" runat="server" CommandName="gvRequisitionStatus2" CommandArgument='<%# Bind("Requisition_No") %>' >Details</asp:LinkButton>
                  </ItemTemplate>
            </asp:TemplateField>            
            
        </Columns>
    </asp:GridView>  
           </div>  
    </form>
</asp:Content>