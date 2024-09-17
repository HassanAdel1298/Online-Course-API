using System.Net.Mail;
using System.Net;
using System.Text;

namespace Online_Course_API.sendEmail
{
    public class EmailSender : IEmailSender
    {
        public void SendEmail(string toEmail, string subject)
        {
            SmtpClient client = new SmtpClient("smtp.ethereal.email", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("alene59@ethereal.email", "qVjBzt2ZncpUH2JtA6");

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("alene59@ethereal.email");
            mailMessage.To.Add(toEmail);
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            StringBuilder mailBody = new StringBuilder();
            mailBody.AppendFormat("<h1>Student Enrollment</h1>");
            mailBody.AppendFormat("<br />");
            mailBody.AppendFormat("<p>Thank you for teaching the students </p>");
            mailMessage.Body = mailBody.ToString();

            client.Send(mailMessage);
        }
    }
}
