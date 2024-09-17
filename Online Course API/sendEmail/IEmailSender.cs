namespace Online_Course_API.sendEmail
{
    public interface IEmailSender
    {
        void SendEmail(string toEmail, string subject);
    }
}
