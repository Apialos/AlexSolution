using System.Threading.Tasks;

namespace MyGallery.Services
{
    public interface IMailService
    {
        void SendEmail(string email, string subject, string message);
        Task SendEmailAsync(string email, string subject, string message);
    }
}
