using System;
using System.Net.Mail;
using System.Configuration;
using System.Collections.Specialized;

namespace SBITCEmailAdvisoryLite
{
    class Program
    {
        static void Main(string[] args)
        {
            ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
            configMap.ExeConfigFilename = @$"{Environment.CurrentDirectory}\App.config";
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);

            var smtpSettings = config.SectionGroups["AdvisorySettings"].Sections["SMTP"];
            var messageSettings = config.SectionGroups["AdvisorySettings"].Sections["Message"];

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient();

                mail.From = new MailAddress("your_email_address@gmail.com");
                mail.To.Add("to_address");
                mail.Subject = "Test Mail";
                mail.Body = "This is for testing SMTP mail from GMAIL";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("username", "password");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
