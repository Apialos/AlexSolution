using System.Threading.Tasks;

namespace MyGallery.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class MailService : IMailService
    {
        public void SendEmail(string email, string subject, string message)
        {
            throw new System.NotImplementedException();
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Task.CompletedTask;
        }
    }
}
