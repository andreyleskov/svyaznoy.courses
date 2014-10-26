using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    using Microsoft.SqlServer.Server;

    /// <summary>
    /// Проведите рефакторинг, обеспечив лёгкое добавление правил валидации 
    /// </summary>
    static class MailSender
    {
        public static void Main(string[] args)
        {
            CheckBehaivior();
            Console.WriteLine("All is ok");
            Console.ReadLine();
        }


        public static string SendMail(string mail, string server, string port, string address)
        {
            string resultAdress = null;
            if (!server.Contains("smtp.")) resultAdress = "Error";
            if (!server.Contains("ru") && !server.Contains("com")) resultAdress = "Error";

            if(resultAdress != null)
                return resultAdress + ": invalid server address";

            string resultPort = null;      
            bool portIsValid = port == "8080" ||
                               port == "1523" ||
                               port == "3126";

            if (portIsValid) resultPort = null;
            else resultPort = "Error:";


            if (resultPort != null)
                return resultPort + " invalid port";


            string recipietnAdress = null;
            if (address.Contains("@")) recipietnAdress = null;
            else recipietnAdress = "Error";

            if (recipietnAdress != null)
                return recipietnAdress + ": invalid recipient address";

            string text = mail;
            if(server != "smtp.unsecure.com")
                text = mail.Trim().Replace("bad man", "<censored>");

            string replacedTest = text;
            if (text == "")
                replacedTest = "<noText>";

           
            return string.Format("Success: Sended to {0} using {1}:{2} - '{3}'",address,server,port, replacedTest ?? mail);
        }


        private static void CheckBehaivior()
        {
            string case1 = SendMail("Hello!", "smtp.mail.ru", "8080", "test@mail.ru");
            Debug.Assert(case1 == "Success: Sended to test@mail.ru using smtp.mail.ru:8080 - 'Hello!'");
            Console.WriteLine("1 pass");

            Debug.Assert(SendMail("Hello! ", "pop3.mail.ru", "8080", "test@mail.ru") ==
                                         "Error: invalid server address");
            Console.WriteLine("2 pass");

            Debug.Assert(SendMail("Hello! ", "hsh.mail.ru", "1010", "test@mail.ru") ==
                                        "Error: invalid server address");
            Console.WriteLine("3 pass");

            string case4 = SendMail("Hello! ", "smtp.mail.lplk", "8080", "test@mail.ru");
            Debug.Assert(case4 == "Error: invalid server address");
            Console.WriteLine("4 pass");

            string case5 = SendMail("Hello! ", "smtp.mail.com", "1523", "test@mail.ru");
            Debug.Assert(case5 == "Success: Sended to test@mail.ru using smtp.mail.com:1523 - 'Hello!'");
            Console.WriteLine("5 pass");

            string case6 = SendMail("Hello! ", "smtp.mail.com", "abc", "test@mail.ru");
            Debug.Assert(case6 == "Error: invalid port");
            Console.WriteLine("6 pass");

            Debug.Assert(SendMail("Hello! ", "smtp.mail.com", "-1", "test@mail.ru") ==
                                        "Error: invalid port");
            Console.WriteLine("7 pass");

            Debug.Assert(SendMail("Hello! ", "smtp.mail.com", "3126", "testmail.ru") ==
                                        "Error: invalid recipient address");
            Console.WriteLine("8 pass");

            string case9 = SendMail("Hello, bad man!", "smtp.mail.com", "3126", "test@mail.ru");
            Debug.Assert(case9 == "Success: Sended to test@mail.ru using smtp.mail.com:3126 - 'Hello, <censored>!'");
            Console.WriteLine("9 pass");

            string case10 = SendMail("Hello, bad man!", "smtp.mail.com", "3126", "test@mail.ru");

            Debug.Assert(case10 == "Success: Sended to test@mail.ru using smtp.mail.com:3126 - 'Hello, <censored>!'");
            Console.WriteLine("10 pass");


            string case11 = SendMail("", "smtp.mail.com", "3126", "test@mail.ru");
            Debug.Assert(case11 ==
                                        "Success: Sended to test@mail.ru using smtp.mail.com:3126 - '<noText>'");
            Console.WriteLine("11 pass");

            Debug.Assert(SendMail("Hello, bad man!", "smtp.unsecure.com", "3126", "test@mail.ru")
                                == "Success: Sended to test@mail.ru using smtp.unsecure.com:3126 - 'Hello, bad man!'");
            Console.WriteLine("12 pass");
        }
  
}
}
