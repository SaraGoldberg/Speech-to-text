using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace SpeechToText
{
    public class Sender
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class EmailSender
    {
        public EmailSender(Sender sender)
        {
            this.Sender = sender;
        }
        public Sender Sender { get; set; }

        static string SmtpAddress = "smtp.gmail.com";
        static int PortNumber = 587;
        static bool EnableSSL = true;
        public void Send(string reciever, string subject, string body)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(this.Sender.Email);
                mail.To.Add(reciever);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient(SmtpAddress, PortNumber))
                {
                    smtp.Credentials = new NetworkCredential(this.Sender.Email, this.Sender.Password);
                    smtp.EnableSsl =EnableSSL;
                    smtp.Send(mail);
                }
            }
        }   
    }
}