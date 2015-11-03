using System;
using System.Diagnostics;
using System.IO;

namespace HelperCSharp
{
    public class CHelper
    {
        /// <summary>
        /// Gelen parametreyi "Int32" türüne çevirip geri döndürür. 
        /// Eğer gelen parametre çevrilemiyorsa geriye 0 "sıfır" döndürür.
        /// </summary>
        /// <param name="obj"></param>
        public static int ConvertToInt(object obj)
        {
            try
            {
                return Convert.ToInt32(obj);
            }
            catch(Exception e)
            {
                SetEventLog("ConvertToInt Exception : " + e, 3);
                return 0;
            }
        }
        /// <summary>
        /// Gelen parametreyi "string" türüne çevirip geri döndürür. 
        /// Eğer gelen parametre çevrilemiyorsa geriye "String.Empty" döndürür.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ConvertToString(object obj)
        {
            try
            {
                return Convert.ToString(obj);
            }
            catch(Exception e)
            {
                SetEventLog("ConvertToString Exception : " + e, 3);
                return String.Empty;
            }
        }
        /// <summary>
        /// Gelen parametreyi "double" türüne çevirip geri döndürür. 
        /// Eğer gelen parametre çevrilemiyorsa geriye "0.0" döndürür.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double ConvertToDouble(object obj)
        {
            try
            {
                return Convert.ToDouble(obj);
            }
            catch(Exception e)
            {
                SetEventLog("ConvertToDouble Exception : " + e, 3);
                return 0.0;
            }
        }
        /// <summary>
        /// Gelen parametreyi "bool" türüne çevirip geri döndürür. 
        /// Eğer gelen parametre çevrilemiyorsa geriye "False" döndürür.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool ConvertToBoolean(object obj)
        {
            try
            {
                return Convert.ToBoolean(obj);
            }
            catch(Exception e)
            {
                SetEventLog("ConvertToBoolean Exception : " + e, 3);
                return false;
            }
        }
        /// <summary>
        /// Gelen parametreyi "DateTime" türüne çevirip geri döndürür. 
        /// Eğer gelen parametre çevrilemiyorsa geriye "DateTime.MinValue" döndürür.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime ConvertToDateTime(object obj)
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
                return ConvertToDateTime("01." + date.AddMonths(1).Month + "." + date.Year + " 23:59:59").AddDays(-1);
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
        /// Gelen string'in içindeki ('_','-','$','&','#','?','%','/','\','~','*','+',"=","<",">","{","}","[","]","(",")") karakteri varsa boşluğa (' ') çevirir.
        /// Hata durumunda gelen string'i geri döndürür.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string CharactersClean(string text)
        {
            string newText = "";
            try
            {
                foreach (var item in text)
                {
                    switch (item)
                    {
                        case '_': newText += ' '; break;
                        case '-': newText += ' '; break;
                        case '$': newText += ' '; break;
                        case '&': newText += ' '; break;
                        case '#': newText += ' '; break;
                        case '?': newText += ' '; break;
                        case '%': newText += ' '; break;
                        case '/': newText += ' '; break;
                        case '\\': newText += ' '; break;
                        case '~': newText += ' '; break;
                        case '*': newText += ' '; break;
                        case '+': newText += ' '; break;
                        case '=': newText += ' '; break;
                        case '<': newText += ' '; break;
                        case '>': newText += ' '; break;
                        case '{': newText += ' '; break;
                        case '}': newText += ' '; break;
                        case '[': newText += ' '; break;
                        case ']': newText += ' '; break;
                        case '(': newText += ' '; break;
                        case ')': newText += ' '; break;
                        default: newText += item; break;
                    }
                }
            }
            catch(Exception e)
            {
                SetEventLog("CharactersClean Exception : " + e, 3);
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
        /// 
        /// </summary>
        /// <param name="logMesaj">string Mesage</param>
        /// <param name="logType">1:Information, 2: Warning, 3:Error</param>
        private static void SetEventLog(string logMesaj, int logType)
        {
            try
            {
                EventLog log = new EventLog();
                if (!EventLog.SourceExists("HelperCSharp"))
                {
                    EventLog.CreateEventSource("HelperCSharp", "HelperCSharp_Library_Logs");
                }

                log.Source = "HelperCSharp";
                log.Log = "HelperCSharp_Library_Logs";

                switch (logType)
                {
                    case 1: log.WriteEntry(logMesaj, EventLogEntryType.Information); break;
                    case 2: log.WriteEntry(logMesaj, EventLogEntryType.Warning); break;
                    case 3: log.WriteEntry(logMesaj, EventLogEntryType.Error); break;
                }

                SetExceptionText(logMesaj);
            }
            catch(Exception e)
            {
                SetExceptionText("SetEventLog Exception : "+e);
            }
        }

        private static void SetExceptionText(string exception)
        {
            try
            {
                try
                {
                    TextWriter Dosya = File.AppendText(@"C:\\HelperCSharpeExceptions.txt");
                    Dosya.WriteLine("");
                    Dosya.Write(DateTime.Now);
                    Dosya.WriteLine("");
                    Dosya.WriteLine("______________________________________________________________________________________");
                    Dosya.WriteLine("");
                    Dosya.Write("\t" + exception);
                    Dosya.WriteLine("");
                    Dosya.WriteLine("\t==============================================================================");
                    Dosya.WriteLine("");

                    Dosya.Flush();
                    Dosya.Close();
                }
                catch (Exception)
                {
                    TextWriter Dosya = File.CreateText(@"C:\\HelperCSharpeExceptions.txt");

                    Dosya.WriteLine("");
                    Dosya.Write(DateTime.Now);
                    Dosya.WriteLine("");
                    Dosya.WriteLine("______________________________________________________________________________________");
                    Dosya.WriteLine("");
                    Dosya.Write("\t" + exception);
                    Dosya.WriteLine("");
                    Dosya.WriteLine("\t==============================================================================");
                    Dosya.WriteLine("");

                    Dosya.Flush();
                    Dosya.Close();
                }
            }
            catch (System.Exception e)
            {

            }

        }
    }
}
