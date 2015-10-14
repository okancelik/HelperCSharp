using System;
using System.Net;
using System.Net.Mail;

namespace HelperCSharp
{
    public class CHelperMail
    {
        /// <summary>
        /// E-Posta'nin kimden gönderilecegi bilgisini tutar
        /// </summary>
        public string From { get; set; }
        /// <summary>
        /// E-Postanin kime/kimlere gönderilecegi bilgisini tutar.
        /// Not:Birden fazla adrese gönderilecekse aralarına virgül (,) koyun.
        /// </summary>
        public string To { get; set; }
        /// <summary>
        /// Ek olarak gönderilecek dosyanın yolunu tutar.
        /// </summary>
        public string Attachments { get; set; }
        /// <summary>
        /// Mailin konusunu tutar.
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Mailin içeriğini tutar.
        /// </summary>
        public string Body { get; set; }

        /////////////// Settings //////////////////
        /// <summary>
        /// Maili gönderecek adresi tutar.
        /// </summary>
        public string SenderEmail { get; set; }
        /// <summary>
        /// Maili gönderecek adresin şifresini tutar.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Maili gönderecek adresin SMTP sunucusunun isim bilgisini tutar.
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// Maili gönderecek adresin SMTP sunucusunun Port bilgisini tutar.
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// SSL bağlantı bilgisini tutar.
        /// True : Açık, False:Kapalı. Not : Belirtmezseniz False Gönderir.
        /// </summary>
        public bool SSL { get; set; }


        ///////////////////////////////////////////////////////////////////////////
        
        /// <summary>
        /// Exceptionları Tutar.
        /// Class içinde kullanılır.
        /// </summary>
        private string Exception;
        /// <summary>
        /// Mail Gönderim Durumunu Tutar.
        /// Class içinde kullanılır.
        /// </summary>
        private bool   mailState;


        /// <summary>
        /// CHelperMail objesindeki propertileri referans alıp mail gönderir, geriye bool tipinde sonuç döndürür.
        /// True : Gönderim Başarılı. False : Gönderim Başarısız.
        /// </summary>
        /// <returns></returns>
        public bool Send()
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(From);

                foreach (var item in ToPart(To))
                {
                    mail.To.Add(item);
                }
                try
                {
                    mail.Attachments.Add(new Attachment(@Attachments));
                }
                catch
                {
                    // Ek yoksa Hata Vermemesi için....
                }
                mail.Subject = Subject;
                mail.Body = Body;

                SmtpClient smtp = new SmtpClient();

                smtp.Credentials = new NetworkCredential(SenderEmail, Password);
                smtp.Port = Port;
                smtp.Host = Host;
                smtp.EnableSsl = SSL;

                try
                {
                    mailState = true;
                    smtp.Send(mail);
                }
                catch (SmtpException ex)
                {
                    mailState = false;
                    Exception = ex.GetBaseException().ToString();
                }  
            }
            catch (Exception ex)
            {

                Exception = ex.ToString();
            }

            return mailState;
        }
        /// <summary>
        /// Mail Gönderimi Sonrası Mail Durumunu string olarak geri döndürür.
        /// </summary>
        /// <returns></returns>
        public string SendState()
        {
            if (mailState)
            {
                return "Mail Gönderimi Başarılı.";
            }
            else if (Exception != "")
            {
                return Exception;
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// Virgülle ayrılan mail adreslerini string diziye cevip geri döndürür.
        /// Class içinde kullanılır.
        /// </summary>
        /// <param name="to"></param>
        /// <returns></returns>
        private string[] ToPart(string to)
        {
            string[] toList = to.Split(',');
            string[] newToList = new string[toList.Length];
            for (int i = 0; i < toList.Length; i++)
            {
                newToList[i] = toList[i].Trim();
            }

            return newToList;
        }

    }
}
