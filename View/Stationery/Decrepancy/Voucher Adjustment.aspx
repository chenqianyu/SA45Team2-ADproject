<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageforDepartmenthead.master" AutoEventWireup="true" CodeFile="Voucher Adjustment.aspx.cs" Inherits="Stationery_decrepancy_Decrepancy" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form runat="server">
    <h2>Voucher Adjustment</h2>
    <table class="table-inverse" style="width:60%">
        <tr style="height:40px">
            <td class="h5 col-2">
                <asp:Label ID="lbDisplayItemCode" runat="server" Text="Item Code: "></asp:Label>
            </td>
            <td class="h5 col-2">
                <asp:DropDownList ID="ddlItemCode" runat="server" OnSelectedIndexChanged="ddlItemCode_SelectedIndexChanged" AutoPostBack="true"
                     CssClass="btn btn-light dropdown-item" BackColor="#666666" style="-webkit-appearance:button;width:150px;height:auto;">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height:40px">
            <td class="h5 col-2" style="height:10px">
                <asp:Label ID="lbDisplayDescription" runat="server" Text="Description: "></asp:Label>
            </td>
            <td class="h5 col-2">        
                <asp:Label ID="lbDescription" runat="server" Text=""><i class="form-group__bar"></i></asp:Label>
            </td>
        </tr>
        <tr style="height:40px">
            <td class="h5 col-2" style="height:10px">
                <asp:Label ID="lbDisplayUnit" runat="server" Text="Unit of Measurement: "></asp:Label>              
            </td>
            <td class="h5 col-2" style="height:10px">
               
                <asp:Label ID="lbUnitOfMeasure" runat="server" Text=""><i class="form-group__bar"></i></asp:Label>      
          
            </td>
           
        </tr>
        <tr style="height:40px">
            <td class="h5 col-2">
                <asp:Label ID="lbDisplayQty" runat="server" Text="Quantity: "></asp:Label>
            </td>
            <td class="h5 col-2">
                 <br />
                 <div class="form-group">
               <asp:TextBox ID="tbQty" runat="server" CssClass="form-control" OnTextChanged="tbQty_TextChanged" AutoPostBack="true" Enabled ="false"></asp:TextBox>
                  <i class="form-group__bar"></i>
               </div>
                
            </td>
        </tr>
        <tr style="height:40px">
            <td class="h5 col-2" style="height:10px">
                <asp:Label ID="lbDisplayRemark" runat="server" Text="Remark: "></asp:Label>
            </td>
            <td class="h5 col-2">
               <br />
                <div class="form-group">
               <asp:TextBox ID="tbRemarks" CssClass="form-control" runat="server"></asp:TextBox>
                  <i class="form-group__bar"></i>
                    </div>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbQty" ForeColor="Red" ErrorMessage="RequiredFieldValidator">Qty is required</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorRetrieved2" runat="server" ControlToValidate="tbQty" ErrorMessage="Please Enter Only Positive Numbers" ForeColor="Red" ValidationExpression="^\d+$" Display="Dynamic"></asp:RegularExpressionValidator>
</td>
        </tr>
        <tr style="height:40px">
            <td class="h5 col-2" style="height:10px">
                <asp:Label ID="lbDisplayValue" runat="server" Text="Total Value: "></asp:Label>
            </td>
            <td class="h5 col-2"  >
                 <asp:Label ID="lbValue" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="height:40px">
            <td class="h5 col-2">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                CssClass="btn bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White"/>
            </td>
        </tr>
    </table>
    <br />
    <h2>
        Adjustments Pending Acknowledgement
    </h2>
    <br />
        <div style="height: 250px,600px initial; width: 80%">
     <asp:GridView ID="gvAdj" runat="server" AutoGenerateColumns="false" DataKeyNames="Item_No" CellPadding="10" OnRowDeleting="OnRowDeleting"  ShowHeaderWhenEmpty="true"
           CssClass="table col-2" PagerStyle-CssClass="page-item" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Large" AlternatingRowStyle-Width="400px">
            <Columns>
                <asp:BoundField DataField="Item_No" HeaderText="Item Code"/>
                <asp:BoundField DataField="Raised_Date" HeaderText="Raised Date"/>
                <asp:BoundField DataField="Quantity" HeaderText="Quantity"/>
                <asp:BoundField DataField="Remarks" HeaderText="Remarks"/>
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ShowEditButton="False" ShowSelectButton="False" DeleteText="Cancel" />
            </Columns>
        </asp:GridView>
            </div>
    <br />
    <asp:Label ID="lbStatus" runat="server" Text=""></asp:Label>
    </form>
</asp:Content>

