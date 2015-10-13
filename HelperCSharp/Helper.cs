using System;

namespace HelperCSharp
{
    public class Helper
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
            catch
            {
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
            catch
            {
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
            catch
            {
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
            catch
            {
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
            catch
            {
                return DateTime.MinValue;
            }
        }

        /// <summary>
        /// Gelen tarihin saatini sıfırlayıp geri döndürür. 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime ConvertToDateTimeDefaultHour(DateTime date)
        {
            try
            {
                return Convert.ToDateTime(date.Day + "." + date.Month + "." + date.Year + " 00:00:00");
            }
            catch
            {
                return date;
            }
        }
        /// <summary>
        /// Gelen Tarih Hafta Sonuna Denk Gelirse Bir Önceki Cuma Gününün Tarihini Döndürür.
        /// Hafta Sonuna Denk Gelmiyorsa Tarihi Geldiği Şekilde Geri Döndürür.
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
            catch (Exception)
            {
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
            catch
            {

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
                    if (item == 'ö')
                    {
                        newText += 'o';
                    }
                    else if (item == 'Ö')
                    {
                        newText += 'O';
                    }
                    else if (item == 'ü')
                    {
                        newText += 'u';
                    }
                    else if (item == 'Ü')
                    {
                        newText += 'U';
                    }
                    else if (item == 'ş')
                    {
                        newText += 's';
                    }
                    else if (item == 'Ş')
                    {
                        newText += 'S';
                    }
                    else if (item == 'ğ')
                    {
                        newText += 'g';
                    }
                    else if (item == 'Ğ')
                    {
                        newText += 'G';
                    }
                    else if (item == 'ç')
                    {
                        newText += 'c';
                    }
                    else if (item == 'Ç')
                    {
                        newText += 'C';
                    }
                    else if (item == 'İ')
                    {
                        newText += 'I';
                    }
                    else if (item == 'ı')
                    {
                        newText += 'i';
                    }
                    else
                    {
                        newText += item;
                    }
                }
            }
            catch
            {

                newText = text;
            }
           

            return newText;
        }

        /// <summary>
        /// Gelen string'in içindeki ('_','-','$','&','#','?','%','/','\','~','*','+') karakteri varsa boşluğa (' ') çevirir.
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
                    if (item == '_' || item == '-'||item == '$'||item == '&'||item == '#'||item == '?'||item == '%'||item == '/'||item == '\\'||item == '~'||item == '*'||item == '+')
                    {
                        newText += ' ';
                    }
                    else
                    {
                        newText += item;
                    }
                }
            }
            catch
            {
                newText = text;
            }

            return newText;
        }
    }
}
