using System;
using HelperCSharp;

namespace HelperCSharpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date = Convert.ToDateTime("14.08.2016 18:30:00");

            DateTime GununIlkSaati              = CHelper.ConvertToDateTimeStartHour(date);         
            // Çıktı : "14.08.2016 00:00:00"

            DateTime GununSonSaati              = CHelper.ConvertToDateTimeEndHour(date);           
            // Çıktı : "14.08.2016 23:59:59"

            DateTime AyinIlkGunu                = CHelper.ConvertToDateStartOfTheMonth(date);       
            // Çıktı : "01.08.2016 00:00:00"

            DateTime AyinSonGunu                = CHelper.ConvertToDateEndOfTheMonth(date);         
            // Çıktı : "31.08.2016 23:59:59"

            date = Convert.ToDateTime("14.08.2016 18:30:00"); // Pazar

            DateTime HaftaSonuOncesiCuma        = CHelper.WeekendDateChangePreviousFriday(date);    
            // Çıktı : "12.08.2016 18:30:00"

            date = Convert.ToDateTime("14.08.2016 18:30:00"); // Pazar

            DateTime HaftaSonuSonrakiPazartesi  = CHelper.WeekendDateChangeNextMonday(date);        
            // Çıktı : "15.08.2016 18:30:00"

            string EngKarakterliMetin           = CHelper.TurkishCharactersChangeEng( "Bu metin, içindeki Türkçe karakterler İngilizce karaktere çevrilerek geri döndürülecek ! ");
            //Çıktı : "Bu metin, icindeki Turkce karakterler Ingilizce karaktere cevrilerek geri dondurulecek ! "

            string resgeleKod                   = CHelper.RandomCode(15);
            // Örnek Çıktı : "bNz9ukaZVfPkWjj"



            //HelperMail();

            Console.ReadLine();
        }

        public static void HelperMail()
        {
            CHelperYandexMail mail =new CHelperYandexMail();

            /////////////// Begin : Settings ///////////////         
            mail.SetSenderEmail = "okan.celik@yandex.com";
            mail.SetPassword    = "26subat1989";
            /////////////// End   : Settings ///////////////

            /////////////// Begin : Mail     ///////////////
            mail.From           = "okan.celik@yandex.com";
            mail.To             = "okan.celik@outlook.com";
            mail.CC             = "iokancelik@icloud.com";
            mail.Attachments    = @"C:\\Users\\Okan\\Desktop\\Document.docx";
            mail.Subject        = "Test Mail";
            mail.Body           = "Mail Test";
            /////////////// End   : Mail     ///////////////

            mail.Send();
            Console.WriteLine(mail.SendState());

            try
            {

            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
