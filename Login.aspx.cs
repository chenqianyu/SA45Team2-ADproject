using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Principal;
using SA45Team02_SSIS;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /*
    protected void Logon_Click(object sender, EventArgs e)
    {
        Boolean a = Membership.ValidateUser(UserEmail.Text,UserPass.Text);
        if(a == true)
        {
            if (Roles.IsUserInRole("employee"))
            {
                Response.Redirect("http://localhost/SA45Team02_SSIS/View/Stationery/GeneratePO/GeneratePO.aspx");
            }
        }
        */


    //bool success = LogInOutController.CheckSuccessLogin(UserEmail.Text, UserPass.Text);
    //if (success)
    //{
    //    FormsAuthentication.RedirectFromLoginPage
    //      (UserEmail.Text, Persist.Checked);
    //}
    //else
    //{
    //    Msg.Text = "Invalid credentials. Please try again.";
    //}



    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        if (Roles.IsUserInRole("employee"))
        {
            Response.Redirect("http://localhost/SA45Team02_SSIS/View/Stationery/GeneratePO/GeneratePO.aspx");
        }
    }



    //protected void Login1_LoggedIn(object sender, EventArgs e)
    //{
    //   String username= Login1.UserName;
    //    String password = Login1.Password;
    //    LoginUserInfo info=LogInOutController.RetrieveCurrentlyLoginUserInfo(username);
    //    Session[Utility.CurrentlyLoginUserInfo] = info;
    //    Console.WriteLine("...............hello...........here");
    //      //  Response.Redirect("~/View/Stationery/GeneratePO/GeneratePO.aspx");
    //    ;       //if (emp != null)
    //   // {
    //   //     Session[Utility.CurrentlyLoginUserEmail] = emp.Email;
    //   //     Session[Utility.CurrentlyLoginUserID] = emp.Employee_ID;
    //   //     Session[Utility.CurrentlyLoginUserName] = emp.Employee_Name;
    //   //     Session[Utility.CurrentlyLoginUserDepartment] = emp.Department_ID;
    //   //     string role = Convert.ToString(Roles.GetRolesForUser(Login1.UserName).GetValue(0));
    //   //     Session[Utility.CurrentlyLoginUserRole] = role;
    //   // }



    //    //if (Roles.IsUserInRole("Employee"))
    //    //{
    //    //    Response.Redirect("~/View/Stationery/GeneratePO/GeneratePO.aspx");
    //    //}
    //}



    //protected void Login1_LoggedIn(object sender, LoginCancelEventArgs e)
    //{
    //    String username = Login1.UserName;
    //    String password = Login1.Password;
    //    LoginUserInfo b =LogInOutController.CheckSuccessLogin(username, password);

    //    Session[Utility.CurrentlyLoginUserInfo] = b;
    //    Console.WriteLine("...............hello...........here");
    //  //  Response.Redirect("~/View/Stationery/GeneratePO/GeneratePO.aspx");
    //}



    protected void Login1_LoggedIn1(object sender, EventArgs e)
    {
        String username = Login1.UserName;
        String password = Login1.Password;
        LoginUserInfo b = LogInOutController.CheckSuccessLogin(username, password);

        Session[Utility.CurrentlyLoginUserInfo] = b;
        Console.WriteLine("...............hello...........here");
    }
}