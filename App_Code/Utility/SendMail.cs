using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.IO;
//Coding by Keoh
public class SendMail
{
    string emailAddress = "sa45team2ssis@gmail.com";
    string password = "Qweasd12";
    public SendMail()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void Send(string emailMessage, string emailSubject, string recipientEmail)
    {
        using (MailMessage mm = new MailMessage(new MailAddress(emailAddress), new MailAddress(recipientEmail)))
        {
            mm.Subject = emailSubject;
            mm.IsBodyHtml = true;
            mm.Body = emailMessage;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential(emailAddress, password);
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mm);
        }
    }
}