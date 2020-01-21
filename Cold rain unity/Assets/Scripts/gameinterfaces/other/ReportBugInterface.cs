using Assets.Scripts.logger;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Assets.Scripts.gameinterfaces.other
{
    public class ReportBugInterface : GameInterface
    {
        public TextMeshProUGUI WrittenText;
        public Toggle SendLogs;

        public override void Create(Player player)
        {
            throw new NotImplementedException();
        }

        public override void Refresh()
        {
            throw new NotImplementedException();
        }

        public void ReportBug()
        {
            StringBuilder sb = new StringBuilder();
            if (SendLogs.isOn)
            {
                CrLogger.logs.ForEach(l => sb.Append($"{l}\n"));
            }
            string res = $"{WrittenText.text}\n\n\n\n{sb.ToString()}";
            SendMail(res);
        }
        
        public void SendMail(string content)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient();
            mail.To.Add("crlogginginc@gmail.com");
            mail.From = new MailAddress("crbugreport@hotmail.com");
            mail.Subject = "Bug report";
            mail.Body = content;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Host = "smtp-mail.outlook.com";
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new NetworkCredential("crbugreport@hotmail.com", "bugreportgang123");
            SmtpServer.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            SmtpServer.EnableSsl = true;
            try
            {
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                Debug.Log("Exception Message: " + ex.Message);
                if (ex.InnerException != null)
                    Debug.Log("Exception Inner:   " + ex.InnerException);
            }
        }
    }
}
