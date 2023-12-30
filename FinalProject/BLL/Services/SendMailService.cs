using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace BLL.Services
{
    public class SendMailService
    {
        /*------------------------------------------------------------------------------------------------*/
        /*Send mail with random verification code*/
        /*------------------------------------------------------------------------------------------------*/
        public static string SendMail(string toEmailAddress)
        {
            try
            {
                var randomCode = GenerateRandomCode(6);
                string smtpServer = "smtp.gmail.com";
                int smtpPort = 587; // Gmail SMTP port
                string smtpUsername = "ghoreghore.customer.info@gmail.com";
                string smtpPassword = "zpur hffp fwlc vmxu";

                using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
                {
                    smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                    smtpClient.EnableSsl = true;

                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("ghoreghore.customer.info@gmail.com");
                    mailMessage.To.Add(toEmailAddress);
                    mailMessage.Subject = "Verification Code for E-commerce site";
                    mailMessage.Body = $"Your verification code is: {randomCode}";
                    mailMessage.IsBodyHtml = true;

                    smtpClient.Send(mailMessage);
                }

                var data = Verify(toEmailAddress, randomCode);

                Console.WriteLine($"Verification code sent to {toEmailAddress}");
                return "Verification code sent";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
                return null;
            }
        }

        /*------------------------------------------------------------------------------------------------*/
        /*Verify mail*/
        /*------------------------------------------------------------------------------------------------*/
        public static string Verify(string toEmailAddress, string enteredCode)
        {
            // Here you can compare the entered code with the generated one
            // For simplicity, I'm returning a success message, modify as needed
            if (enteredCode == GenerateRandomCode(6))
            {
                return "Verification successful";
            }
            else
            {
                return "Verification failed";
            }
        }

        /*------------------------------------------------------------------------------------------------*/
        /*Generate random code with letters and numbers*/
        /*------------------------------------------------------------------------------------------------*/
        private static string GenerateRandomCode(int length)
        {
            const string upperCaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lowerCaseChars = "abcdefghijklmnopqrstuvwxyz";
            const string numberChars = "0123456789";

            var random = new Random();

            // Ensure at least one uppercase letter, one lowercase letter, and one number
            var randomCode = new string(
                new[]
                {
            upperCaseChars[random.Next(upperCaseChars.Length)],
            lowerCaseChars[random.Next(lowerCaseChars.Length)],
            numberChars[random.Next(numberChars.Length)]
                }
                .Concat(Enumerable.Repeat(upperCaseChars + lowerCaseChars + numberChars, length - 3)
                .Select(s => s[random.Next(s.Length)]))
                .ToArray()
            );

            return randomCode;
        }

    }
}
