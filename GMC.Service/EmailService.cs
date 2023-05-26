using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GMC.Service
{
    public class EmailService
    {
        public void SendEmail(string fromAddress, string toAddress, string subject, string body, string reportBase64)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("service.sagemcom@gmail.com", "ehcstldgwztgctnu"),
                EnableSsl = true,
            };

            var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            };

            // Convert Base64 String to byte[]
            var pdfBytes = Convert.FromBase64String(reportBase64);
            var pdfAttachment = new Attachment(new MemoryStream(pdfBytes), "report.pdf", "application/pdf");
            message.Attachments.Add(pdfAttachment);

            smtpClient.Send(message);
        }

    }
}
