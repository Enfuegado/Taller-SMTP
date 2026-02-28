using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using UnityEngine;

public class EmailManager : MonoBehaviour
{
    private string fromEmail = "ingmultimediausbbog@gmail.com";
    private string password = "fsjq ioqf zsxs jrzf";
    private string toEmail = "mailto@example.com";
    public async Task<(bool success, string message)> SendEmailAsync(string subject, string body)
    {
        return await Task.Run(() =>
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(fromEmail);
                mail.To.Add(toEmail);
                mail.Subject = subject;
                mail.Body = body;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(fromEmail, password),
                    EnableSsl = true
                };

                smtp.Send(mail);

                return (true, "Email sent successfully.");
            }
            catch (Exception ex)
            {
                return (false, "Error sending email: " + ex.Message);
            }
        });
    }
    public void SetDestinationEmail(string email)
    {
        toEmail = email;
    }
}