using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mail_Bomber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] gmails = { "" };
            
            string FromMail = "";
            string FromPassword = "";
            for (int i = 0; i < gmails.Length; i++)
            {
               
                MailMessage message = new MailMessage();
                message.From = new MailAddress(FromMail);
                message.Subject = "Test Mail from workshop";
                message.To.Add(new MailAddress(gmails[i]));
                message.Body = "Test from " + gmails[i];

                var smtpCleint = new SmtpClient("smtp.gmail.com");
                smtpCleint.Port = 587;
                smtpCleint.Credentials = new NetworkCredential(FromMail, FromPassword);
                smtpCleint.EnableSsl = true;

                try
                {
                    Random rnd = new Random();
                    smtpCleint.Send(message);
                    int delayTime = rnd.Next(1000, 5000);
                    Console.WriteLine("Sucessful");
                    Thread.Sleep(delayTime);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            
            
        }
    }
}
