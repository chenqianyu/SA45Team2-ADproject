<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>


<%@ Import Namespace="System.Web.Security" %>

<script runat="server">
//void Logon_Click(object sender, EventArgs e)
//{

//  if ((UserEmail.Text == "user1@gmail.com") && 
//          (UserPass.Text == "P@ger123"))
//    {
//        FormsAuthentication.RedirectFromLoginPage 
//           (UserEmail.Text, Persist.Checked);
//    }
//    else
//    {
//        Msg.Text = "Invalid credentials. Please try again.";
//    }
//}
</script>
<html>
<head id="Head1" runat="server">
    <title>Forms Authentication - Login</title>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Vendor styles -->
    <link rel="stylesheet" href="vendors/bower_components/material-design-iconic-font/dist/css/material-design-iconic-font.min.css">
    <link rel="stylesheet" href="vendors/bower_components/animate.css/animate.min.css">

    <!-- App styles -->
    <link rel="stylesheet" href="css/app.min.css">
    <style type="text/css">
        .auto-style1 {
            position: relative;
            left: 0px;
            top: 0px;
            width: 254px;
            height: 35px;
            margin-bottom: 2rem;
        }
    </style>
</head>

<body data-sa-theme="1">
    Authentication Login
  <form id="form1" runat="server">
      <div class="login">
          <asp:Login ID="Login1" runat="server" OnLoggedIn="Login1_LoggedIn1" Width="300px">
              <LayoutTemplate>
                  <%--      <table cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                      <tr>
                          <td>
                              <table cellpadding="0">
                                  <tr>
                                      <td align="center" colspan="2">Log In</td>
                                  </tr>
                                  <tr>
                                      <td align="right">
                                          <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td align="right">
                                          <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td colspan="2">
                                          <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." />
                                      </td>
                                  </tr>
                                  <tr>
                                      <td align="center" colspan="2" style="color: Red;">
                                          <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td align="right" colspan="2">
                                          <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="Login1" />
                                      </td>
                                  </tr>
                              </table>
                              <div class="login__block active" id="l-login">
                                  <div class="login__block__header">
                                      <i class="zmdi zmdi-account-circle"></i>
                          </td>
                      </tr>
                  </table>--%>
                  <div class="login__block active" id="l-login">
                      <div class="login__block__header">
                          <i class="zmdi zmdi-account-circle"></i>
                          Hi there! Please Sign in
                     <div class="actions actions--inverse login__block__actions">
                         <div class="dropdown">
                             <i data-toggle="dropdown" class="zmdi zmdi-more-vert actions__item"></i>

                             <div class="dropdown-menu dropdown-menu-right">
                                 <a class="dropdown-item" data-sa-action="login-switch" data-sa-target="#l-register" href="">Create an account</a>
                                 <a class="dropdown-item" data-sa-action="login-switch" data-sa-target="#l-forget-password" href="">Forgot password?</a>
                             </div>
                         </div>
                     </div>
                      </div>

                      <div class="login__block__body">
                          <div class="form-group">
                              <asp:TextBox ID="UserName" CssClass="form-control text-center" runat="server" placeholder="UserName"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                          </div>
                          <div class="form-group">
                              <asp:TextBox ID="Password" CssClass="form-control text-center" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                              <%--  <a href="index.html" class="btn btn--icon login__block__btn"></a> --%>
                              <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." CssClass="float-left" />
                          </div>
                          
                           <asp:Button ID="LoginButton" CssClass="btn-light" runat="server" CommandName="Login" ValidationGroup="Login1" BorderStyle="None" Width="50px" Text="log In"></asp:Button>
                          
                      </div>
              </LayoutTemplate>
          </asp:Login>
      </div>
  </form>
     <!-- Javascript -->
        <!-- Vendors -->
        <script src="vendors/bower_components/jquery/dist/jquery.min.js"></script>
        <script src="vendors/bower_components/popper.js/dist/umd/popper.min.js"></script>
        <script src="vendors/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>

        <!-- App functions and actions -->
        <script src="js/app.min.js"></script>
</body>
</html>
