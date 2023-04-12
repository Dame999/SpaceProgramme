using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SpaceProgramTask
{
    public class EmailSender
    {
        public void SendEmail(string senderEmailAddress, string password, string recieverEmailAddress, string attachmentFileName)
        {
            try
            {
                SmtpClient mailServer = new SmtpClient("smtp-mail.outlook.com", 587);
                mailServer.EnableSsl = true;
                mailServer.UseDefaultCredentials = true;
                mailServer.Credentials = new System.Net.NetworkCredential(senderEmailAddress, password);

                string from = senderEmailAddress;
                string to = recieverEmailAddress;
                MailMessage message = new MailMessage(from, to);
                message.Subject = "Weather report for rocket launch";
                message.Body = "Hello, in this email you will find the WeatherReport.csv file with the needed parameters for rocket launch.";
                message.Attachments.Add(new Attachment(attachmentFileName));
                mailServer.Send(message);

            }
            catch (Exception ex)
            {
                throw new Exception("Unable to send the email. Please make sure you enter the correct email addresses and password");
            }
            
        }
    }
}
