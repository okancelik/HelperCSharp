using System;
using System.Diagnostics;
using System.IO;

namespace HelperCSharp
{
    public class CHelper
    {
        /// <summary>
        /// Gelen parametreyi "DateTime" türüne çevirip geri döndürür. 
        /// Eğer gelen parametre çevrilemiyorsa geriye "DateTime.MinValue" döndürür.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static DateTime ConvertToDateTime(object obj)
        {
            try
            {
                return Convert.ToDateTime(obj);
            }
            catch (Exception e)
            {
                SetEventLog("ConvertToDateTime Exception : " + e, 3);
                return DateTime.MinValue;
            }
        }
        /// <summary>
        /// Gelen tarihin saatini günün ilk saati yapıp geri döndürür.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime ConvertToDateTimeStartHour(DateTime date)
        {
            try
            {
                return Convert.ToDateTime(date.Day + "." + date.Month + "." + date.Year + " 00:00:00");
            }
            catch(Exception e)
            {
                SetEventLog("ConvertToDateEndOfTheMonth Exception : " + e, 3);
                return date;
            }
        }
        /// <summary>
        /// Gelen tarihin saatini günün son saati yapıp geri döndürür.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime ConvertToDateTimeEndHour(DateTime date)
        {
            try
            {
                return Convert.ToDateTime(date.Day + "." + date.Month + "." + date.Year + " 23:59:59");
            }
            catch(Exception e)
            {
                SetEventLog("ConvertToDateEndOfTheMonth Exception : " + e, 3);
                return date;
            }
        }
        /// <summary>
        /// Gönderilen tarihin bulunduğu ayın son gününü döndürür.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime ConvertToDateEndOfTheMonth(DateTime date)
        {
            try
            {
                DateTime newDate = date.AddMonths(1);
                return ConvertToDateTime("01." + newDate.Month + "." + newDate.Year + " 23:59:59").AddDays(-1);
            }
            catch (Exception e)
            {
                SetEventLog("ConvertToDateEndOfTheMonth Exception : " + e, 3);
                return date;
            }
        }
        /// <summary>
        /// Gönderilen tarihin bulunduğu ayın ilk gününü döndürür.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime ConvertToDateStartOfTheMonth(DateTime date)
        {
            try
            {
                return ConvertToDateTime("01." + date.Month + "." + date.Year + " 00:00:00");
            }
            catch (Exception e)
            {
                SetEventLog("ConvertToDateStartOfTheMonth Exception : " + e, 3);
                return date;
            }
        }
        /// <summary>
        /// Gelen Tarih Hafta Sonuna Denk Gelirse Bir önceki Cuma Gününün Tarihini Döndürür.
        /// Hafta sonuna denk gelmiyorsa tarihi geldiği şekilde geri döndürür.
        /// Hata durumunda gelen tarihi geri döndürür.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime WeekendDateChangePreviousFriday(DateTime date)
        {
            try
            {
                if (date.DayOfWeek == DayOfWeek.Saturday)
                {
                    return date.AddDays(-1);
                }
                else if (date.DayOfWeek == DayOfWeek.Sunday)
                {
                    return date.AddDays(-2);
                }
                else
                {
                    return date;
                }
            }
            catch (Exception e)
            {
                SetEventLog("WeekendDateChangePreviousFriday Exception : " + e, 3);
                return date;
            }
        }
        /// <summary>
        /// Gelen Tarih Hafta Sonuna Denk Gelirse Bir Sonraki Pazartesi Gününün Tarihini Döndürür.
        /// Hafta sonuna denk gelmiyorsa tarihi geldiği şekilde geri döndürür.
        /// Hata durumunda gelen tarihi geri döndürür.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime WeekendDateChangeNextMonday(DateTime date)
        {
            try
            {
                if (date.DayOfWeek == DayOfWeek.Saturday)
                {
                    return date.AddDays(2);
                }
                else if (date.DayOfWeek == DayOfWeek.Sunday)
                {
                    return date.AddDays(1);
                }
                else
                {
                    return date;
                }
            }
            catch(Exception e)
            {
                SetEventLog("WeekendDateChangeNextMonday Exception : " + e, 3);
                return date;
            }

        }
        /// <summary>
        /// Gelen String'in içindeki Türkçe Karakterleri Inglizce Karaktere çevirir.
        /// Hata durumunda gelen string'i geri döndürür.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string TurkishCharactersChangeEng(string text)
        {
            string newText = "";
            try
            {
                foreach (var item in text)
                {
                    switch (item)
                    {
                        case 'ö': newText += 'o'; break;
                        case 'Ö': newText += 'O'; break;
                        case 'ü': newText += 'u'; break;
                        case 'Ü': newText += 'U'; break;
                        case 'ş': newText += 's'; break;
                        case 'Ş': newText += 'S'; break;
                        case 'ğ': newText += 'g'; break;
                        case 'Ğ': newText += 'G'; break;
                        case 'ç': newText += 'c'; break;
                        case 'Ç': newText += 'C'; break;
                        case 'İ': newText += 'I'; break;
                        case 'ı': newText += 'i'; break;
                        default: newText += item; break;
                    }
                }
            }
            catch(Exception e)
            {
                SetEventLog("TurkishCharactersChangeEng Exception : " + e, 3);
                newText = text;
            }

            return newText;
        }
        /// <summary>
        /// Belirtilen karakter uzunluğunda rastgele kod üretir.
        /// Hata durumunda "" (String) Döndürür.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string RandomCode(int length)
        {
            Random rnd = new Random();
            string randomCode = "";
            try
            {
                string[] strChars = { "A", "a", "B", "b", "C", "c", "D", "d", "E", "e", "F", "f", "G", "g", "H", "h", "I", "i", "J", "j", "K", "k", "L", "l", "M", "m", "N", "n", "O", "o", "P", "p", "Q", "q", "R", "r", "S", "s", "T", "t", "U", "u", "V", "v", "W", "w", "X", "x", "Y", "y", "Z", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

                for (int i = 0; i < length; i++)
                {
                    int rndNumber = rnd.Next(0, strChars.Length);

                    randomCode += strChars[rndNumber];
                }
            }
            catch (Exception e)
            {
                SetEventLog("RandomCode Exception : " + e, 3);
                randomCode = "";
            }
            return randomCode;
        }
        /// <summary>
        /// Proje ana dizinine text yazdırır.
        /// İhtiyaca göre uyarlanır.
        /// </summary>
        /// <param name="exception"></param>
        public void SetExceptionText(string exception)
        {
            try
            {
                try
                {
                    var Path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\Logs.txt"; // Proje ana klasörü içinde Log Klasörü içinde Log.txt...(Burası Kafamıza göre)
                    TextWriter Dosya = File.AppendText(Path);
                    Dosya.WriteLine("Date       : " + DateTime.Now);
                    Dosya.WriteLine("Exception  : " + exception);
                    Dosya.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                    Dosya.Flush();
                    Dosya.Close();
                }
                catch (Exception) // txt Dosyası yoksa oluşturur.
                {
                    var Path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\Logs.txt"; // Proje ana klasörü içinde Log Klasörü içinde Log.txt...(Burası Kafamıza göre)
                    TextWriter Dosya = File.CreateText(@Path);
                    Dosya.WriteLine("Date       : " + DateTime.Now);
                    Dosya.WriteLine("Exception  : " + exception);
                    Dosya.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                    Dosya.Flush();
                    Dosya.Close();
                }
            }
            catch (System.Exception e)
            {

            }
        }
        /// <summary>
        /// HelperCSharp ile ilgili hataları Olay Günlüğüne Kaydeder
        /// </summary>
        /// <param name="logMesaj">string Mesage</param>
        /// <param name="logType">1:Information, 2: Warning, 3:Error</param>
        private static void SetEventLog(string logMesaj, int logType)
        {
            EventLog log = new EventLog();
            log.Source   = "HelperCSharp";
            log.Log      = "HelperCSharp_Library_Logs";

            try
            {
                if (!EventLog.SourceExists("HelperCSharp"))
                {
                    EventLog.CreateEventSource("HelperCSharp", "HelperCSharp_Library_Logs");
                }

                switch (logType)
                {
                    case 1: log.WriteEntry(logMesaj, EventLogEntryType.Information); break;
                    case 2: log.WriteEntry(logMesaj, EventLogEntryType.Warning); break;
                    case 3: log.WriteEntry(logMesaj, EventLogEntryType.Error); break;
                }
            }
            catch(Exception e)
            {
                if (!EventLog.SourceExists("HelperCSharp"))
                {
                    EventLog.CreateEventSource("HelperCSharp", "HelperCSharp_Library_Logs");
                    log.WriteEntry("SetEventLog Exception : " + e, EventLogEntryType.Error);
                }    
            }
        }
    }
}
