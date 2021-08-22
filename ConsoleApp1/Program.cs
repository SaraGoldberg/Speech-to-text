using System.Net;
using System.Net.Mail;
using System.Configuration;
using System;
using SpeechToText;
using SpeechToText.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SpeechToTextApiDemo
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            //string res = ConvertToText.SpeechToText();
            Sender sender = new Sender() { Email = "always2study@gmail.com", Password = "0527643113" };
            EmailSender emailSender = new EmailSender(sender);
            emailSender.Send("sara0527643113@gmail.com", "Subject: Speech to text", "That is the body");
        }
    }
}