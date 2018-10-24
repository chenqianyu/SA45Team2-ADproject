<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageforDepartmenthead.master" AutoEventWireup="true" CodeFile="DelegateAuthority.aspx.cs" Inherits="Departmenthead_DelegateAuthority" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form class="form" runat="server">
        <asp:Panel ID="Panel1" runat="server">
            <div class="row">
                <div class="col-3">
                    <h3>
                        <asp:Label ID="lbDelegate" runat="server" Text=" Current Delegate:"></asp:Label>
                    </h3>
                    
                </div>
                <div class="col-3">
          <asp:Label CssClass="form-control-lg" ID="lbDelegateHistory" runat="server" Text="Label"></asp:Label></div>
                    </div>
            
        <br />
   
            <div class="row">
                <div class="col-2">
                    <asp:Label ID="lbFrom" runat="server" CssClass="form-control-lg" Text=" From Date:"> </asp:Label>
                </div>
                <div class="col-2">
                    <asp:Label ID="lbStartDate" CssClass="form-control-lg" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col-2">
                    <asp:Label ID="lbTo" CssClass="form-control-lg" runat="server" Text=" To Date:"></asp:Label>
                </div>
                <div class="col-2">
                    <asp:Label ID="lbEndDate" CssClass="form-control-lg" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
        </asp:Panel>
        <div class="table">
            <br />
            <br />
            <br />
            <div class="row">
                <div class="col-lg-2">
                    <asp:Label ID="lbReason" runat="server" Text="Reason:" CssClass="form-control-lg"></asp:Label>
                </div>

                <div class="form-group col-sm-7">
                    <asp:TextBox ID="tbInput" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ForeColor="#ff0000" runat="server"  display="None" id="reqName" controltovalidate="tbInput" errormessage="Please enter the reason!" />--%>
                    <i class="form-group__bar"></i>
                </div>
            </div>

            <div class="row">
                <div class="col-4">
                    <asp:Label ID="lbEmployeeName" runat="server" Text="Choose Employee Name:" EnableTheming="True" CssClass="form-control-lg"></asp:Label>
                </div>
                   <div class="col-6">
                    <asp:DropDownList ID="ddlItemList" runat="server" ForeColor="White"></asp:DropDownList>
                </div>
            </div>
            
            
            <div class="row"></div>
            <div class="row"></div>
            <br />
            <div class="row">
                <div class="col-4-lg">
                  &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbDelegationPeriod" runat="server" Text="Delegation Period:" CssClass="form-control-lg "></asp:Label>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-4-lg">
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Start Date:
                </div>
                <div class="col-3-lg">
                  <asp:TextBox ID="tbStartDate" runat="server" TextMode="Date" CssClass="form-control datetime-picker" ></asp:TextBox>       
                    <asp:CompareValidator ID="CompareValidatorToday" runat="server" ControlToValidate="tbStartDate" ForeColor="Red" ErrorMessage="Must be same or after Today" Type="Date"></asp:CompareValidator>
                </div>

                <div class="col-4-lg">
                    End Date:
                </div>
                <div class="col-3-lg">
                  <asp:TextBox ID="tbEndDate" runat="server" TextMode="Date" CssClass="form-control datetime-picker"></asp:TextBox>
                  
                </div>
            </div>
            <div class="row">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            <asp:CompareValidator ID="cvtxtStartDate" runat="server"
                ControlToCompare="tbStartDate" CultureInvariantValues="true"
                Display="None" EnableClientScript="true"
                ControlToValidate="tbEndDate"
                ErrorMessage="Start date must be earlier than finish date"
                Type="Date" SetFocusOnError="true" Operator="GreaterThanEqual"></asp:CompareValidator>
            <%--<asp:comparevalidator runat="server" 
  errormessage="The date must be greater than or equal today"
  controltovalidate="tbStartDate" type="date" 
  valuetocompare="<%# DateTime.Today.ToShortDateString() %>" />--%>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None"
                ControlToValidate="tbStartDate" ForeColor="Red"
                ErrorMessage="Please choose Start Date">Start Date is required</asp:RequiredFieldValidator>

            </div>
            <div class="row">
                <div class="col-3">
              &nbsp; <asp:Button ID="btnSubmit" runat="server" Text="DELEGATE AUTHORITY" OnClick="btnSubmit_Click" CssClass="btn-lg bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White" />
                </div>
            </div>
        </div>
    </form>
</asp:Content>
