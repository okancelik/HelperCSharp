using System;

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
            catch
            {
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
            catch
            {
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
            catch (Exception)
            {
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
            catch (Exception)
            {
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
        /// Gelen string'in içindeki ('_','-','$','&','#','?','%','/','\','~','*','+',"=") karakteri varsa boşluğa (' ') çevirir.
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
                    if (item == '_' || item == '-' || item == '$' || item == '&' || item == '#' || item == '?' || item == '%' || item == '/' || item == '\\' || item == '~' || item == '*' || item == '+' || item == '=')
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
                string[] strChars = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

                for (int i = 0; i < length; i++)
                {
                    int rndNumber = rnd.Next(0, strChars.Length);

                    randomCode += strChars[rndNumber];
                }
            }
            catch (Exception)
            {
                randomCode = "";
            }
            return randomCode;
        }
    }
}
