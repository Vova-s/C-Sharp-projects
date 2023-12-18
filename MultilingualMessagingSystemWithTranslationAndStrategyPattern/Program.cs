using System;
using System.Web;
using System.Net;
using System.Text;
using static System.Console;

namespace MultilingualMessagingSystemWithTranslationAndStrategyPattern
{
    public interface Language
    {
        public string translate(string messageType);
    }
    class Program
    {
        Encoding utf8 = Encoding.UTF8;
        static void Main()
        {

            int index;
            string str;
            Console.WriteLine("Please choose the next language of the program:\n1.English\n2.Germany\n3.Continue Ukrainian");
            while (!int.TryParse(ReadLine(), out index) || (index <= 0) || (index > 3))
            {
                Write("Try again : ");
            }
            if (index == 1)
            {
                Language language = new English();
                Write(language.translate("Write a message: "));
                str = ReadLine();
                SystemMessage message = new InfoMessage(language);
                message.ShowMessage(str);
                WriteLine();
                SystemMessage sm = new ErrorWarning(language);
                sm.ShowMessage("");
            }
            else if (index == 2)
            {
                Language language = new Deutch();
                Write(language.translate("Write a message: "));
                str = ReadLine();
                SystemMessage message = new InfoMessage(language);
                message.ShowMessage(str);
                WriteLine();
                SystemMessage sm = new ErrorWarning(language);
                sm.ShowMessage("");
            }
            else
            {
                Language language = new Ukrainian();
                Write(language.translate("Write a message: "));
                str = ReadLine();
                SystemMessage message = new InfoMessage(language);
                message.ShowMessage(str);
                WriteLine();
                SystemMessage sm = new ErrorWarning(language);
                sm.ShowMessage("");
            }
        }
    }
    abstract public class SystemMessage
    {
        public Language language;
        public SystemMessage(Language language)
        {
            this.language = language;
        }
        abstract public void ShowMessage(string str);
    }
    public class ErrorWarning : SystemMessage
    {
        public ErrorWarning(Language language) : base(language) { }
        public override void ShowMessage(string str)
        {
            Write(language.translate("Error Message") + str);
        }
    }
    public class InfoMessage : SystemMessage
    {
        public InfoMessage(Language language) : base(language) { }
        public override void ShowMessage(string str)
        {
            Write(language.translate("Kitty wrote: " + str));
        }
    }
    class English : Language
    {
        public string translate(string input)
        {
            var fromLanguage = "uk";
            var toLanguage = "en";
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={fromLanguage}&tl={toLanguage}&dt=t&q={HttpUtility.UrlEncode(input)}";
            var webclient = new WebClient
            {
                Encoding = System.Text.Encoding.UTF8
            };
            var result = webclient.DownloadString(url);
            try
            {
                result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);
                return result;
            }
            catch (Exception e1)
            {
                return "error";
            }
        }
    }
    class Deutch : Language
    {
        public string translate(string input)
        {
            var fromLanguage = "uk";
            var toLanguage = "de";
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={fromLanguage}&tl={toLanguage}&dt=t&q={HttpUtility.UrlEncode(input)}";
            var webclient = new WebClient
            {
                Encoding = System.Text.Encoding.UTF8
            };
            var result = webclient.DownloadString(url);
            try
            {
                result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);
                return result;
            }
            catch (Exception e1)
            {
                return "error";
            }
        }
    }
    class Ukrainian : Language
    {
        public string translate(string input)
        {
            var fromLanguage = "en";
            var toLanguage = "uk";
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={fromLanguage}&tl={toLanguage}&dt=t&q={HttpUtility.UrlEncode(input)}";
            var webclient = new WebClient
            {
                Encoding = System.Text.Encoding.UTF8
            };
            var result = webclient.DownloadString(url);
            try
            {
                result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);
                return result;
            }
            catch (Exception e1)
            {
                return "error";
            }
        }
    }
}