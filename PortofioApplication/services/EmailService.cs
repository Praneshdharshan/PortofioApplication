using System.Net;
using System.Net.Mail;

namespace PortofioApplication.Services
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public void Send(string to, string subject, string body)
        {
            var from = _config["EmailSettings:From"];
            var pass = _config["EmailSettings:Password"];

            SmtpClient client = new SmtpClient(_config["EmailSettings:Host"])
            {
                Port = int.Parse(_config["EmailSettings:Port"]),
                Credentials = new NetworkCredential(from, pass),
                EnableSsl = true
            };

            MailMessage msg = new MailMessage(from, to, subject, body);
            msg.IsBodyHtml = true;

            client.Send(msg);
        }
    }
}
