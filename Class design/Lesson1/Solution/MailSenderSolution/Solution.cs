using System;
using System.Diagnostics;
using System.Linq;

namespace Petra1
{

    internal static class Solution
    {
        public static void Main()
        {
            CheckBehaivior();
            Console.WriteLine("All is ok");
            Console.ReadLine();
        }

        private class MailProperties
        {
            public readonly string Server;
            public readonly string Port;
            public readonly string Address;

            public MailProperties(string server, string port, string address)
            {
                Server = server;
                Port = port;
                Address = address;
            }
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

        private static readonly ICheckRule[] CheckRules = { new ServerCheckRule(), new AdressChechRule(), new PortChechRule() };
        private static readonly ITextAutoEditor[] AutoEditors = { new BadManUnsecureCensor(), new EmptyTextQualifier() };

        private static string SendMail(string mail, string server, string port, string address)
        {
            string checkResut = null;
            var mailProperties = new MailProperties(server, port, address);

            if (CheckRules.Any(rule => !rule.TryCheck(mailProperties, out checkResut)))
                return "Error: " + checkResut;

            mail = AutoEditors.Aggregate(mail, (current, editor) => editor.Edit(current, mailProperties));

            return string.Format("Success: Sended to {0} using {1}:{2} - '{3}'", address, server, port, mail);
        }

        private interface ICheckRule
        {
            bool TryCheck(MailProperties data, out string checkResultMessage);
        }

        private interface ITextAutoEditor
        {
            string Edit(string text, MailProperties properties);
        }

        class BadManUnsecureCensor : ITextAutoEditor
        {
            public string Edit(string text, MailProperties properties)
            {
                return properties.Server != "smtp.unsecure.com" ? text.Trim().Replace("bad man", "<censored>") : text;
            }
        }

        class EmptyTextQualifier : ITextAutoEditor
        {
            public string Edit(string text, MailProperties properties)
            {
                return text == "" ? "<noText>" : text;
            }
        }

        class ServerCheckRule : ICheckRule
        {
            public bool TryCheck(MailProperties data, out string checkResultMessage)
            {
                checkResultMessage = "";
                var server = data.Server;
                if (server.Contains("smtp.") && (server.Contains("ru") || server.Contains("com"))) return true;
                checkResultMessage = "invalid server address";
                return false;
            }
        }

        class PortChechRule : ICheckRule
        {
            public bool TryCheck(MailProperties data, out string checkResultMessage)
            {
                var port = data.Port;
                checkResultMessage = "";
                if (port == "8080" || port == "1523" || port == "3126") return true;
                checkResultMessage = "invalid port";
                return false;
            }
        }

        class AdressChechRule : ICheckRule
        {
            public bool TryCheck(MailProperties data, out string checkResultMessage)
            {
                checkResultMessage = "";
                var address = data.Address;
                if (address.Contains("@")) return true;
                checkResultMessage = "invalid recipient address";
                return false;
            }
        }
    }
}
