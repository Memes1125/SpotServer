using SpotyClient.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SpotyClient.ViewModel
{
    public class RecoveryPasswordWindowViewModel : Notify
    {
        public CustomCommand SandMail { get; set; }
        public int AcceptCode { get; set; }
        public int ContextAcceptCode { get; set; }

        public RecoveryPasswordWindowViewModel()
        {


            SandMail = new CustomCommand(() =>
            {
                RandomMethod();


                MailAddress from = new MailAddress("dima6145@bk.ru", "Код подтверждения");
                string myAdress = "pokimonchik34@gmail.com";
                MailAddress to = new MailAddress(myAdress);
                MailMessage m = new MailMessage(from, to);
                m.Subject = "Код подтверждения";
                m.Body = $"Доброго времени суток, никому не сообщяйте свой код {AcceptCode} ";
                SmtpClient smtp = new SmtpClient("smtp.mail.ru", 465/*587*/);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("dima6145@bk.ru", "FbthMPirDBiS5unQVVXc");
                smtp.EnableSsl = true;
                smtp.Send(m);


            });
        }

        public void RandomMethod()
        {
            Random rnd = new Random();
            AcceptCode = rnd.Next(1000, 9999);
        }
    }
}
