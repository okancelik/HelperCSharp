using System;
using System.Net;
using System.Net.Mail;

namespace HelperCSharp
{
    public class CHelperGMail
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
        /// E-Postanin kime/kimlere CC olarak gönderilecegi bilgisini tutar.
        /// Not:Birden fazla adrese gönderilecekse aralarına virgül (,) koyun.
        /// </summary>
        public string CC { get; set; }
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
        public string SetSenderEmail { get; set; }
        /// <summary>
        /// Maili gönderecek adresin şifresini tutar.
        /// </summary>
        public string SetPassword { get; set; }

        /// <summary>
        /// Maili gönderecek adresin SMTP sunucusunun isim bilgisini tutar.
        /// </summary>
        private string SetHost = "smtp.gmail.com";

        /// <summary>
        /// Maili gönderecek adresin SMTP sunucusunun Port bilgisini tutar.
        /// </summary>
        private int SetPort = 587;

        /// <summary>
        /// SSL bağlantı bilgisini tutar.
        /// True : Açık, False:Kapalı. Not : Belirtmezseniz False Gönderir.
        /// </summary>
        private bool SetSSL = true;


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
        private bool mailState;


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

                foreach (var item in StringPart(To))
                {
                    mail.To.Add(item);
                }
                try
                {
                    foreach (var item in StringPart(CC))
                    {
                        mail.CC.Add(item);
                    }
                }
                catch (Exception)
                {
                    // CC yoksa Hata Vermemesi için....
                }
                try
                {
                    foreach (var item in StringPart(Attachments))
                    {
                        mail.Attachments.Add(new Attachment(@item));
                    }
                }
                catch
                {
                    // Ek yoksa Hata Vermemesi için....
                }
                mail.Subject = Subject;
                mail.IsBodyHtml = true;
                mail.Body = Body;

                SmtpClient smtp = new SmtpClient();

                smtp.Credentials = new NetworkCredential(SetSenderEmail, SetPassword);
                smtp.EnableSsl = SetSSL;
                smtp.Host = SetHost;
                smtp.Port = SetPort;
                smtp.Timeout = 50000;

                try
                {
                    smtp.Send(mail);
                    mailState = true;
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
        /// Virgülle ayrılan mail adreslerini veya Attachmentları string diziye cevip geri döndürür.
        /// Class içinde kullanılır.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string[] StringPart(string str)
        {
            try
            {
                string[] toList = str.Split(',');
                string[] newToList = new string[toList.Length];
                for (int i = 0; i < toList.Length; i++)
                {
                    newToList[i] = toList[i].Trim();
                }

                return newToList;
            }
            catch (Exception)
            {
                return new string[0];
            }
        }
    }
}
