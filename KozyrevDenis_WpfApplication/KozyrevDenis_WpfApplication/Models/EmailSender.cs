using System;
using System;
using System.Net;
using System.Net.Mail;

namespace KozyrevDenis_WpfApplication.Models
{
    public static class EmailSender
    {
        public static void Send(string strUser, string strPass,string server,string from,string to)
        {
            //На mail.ru следующие настройки:
            //Сервер исходящей почты(SMTP - сервер): SMTP.< домен >, где < домен > 
            //-домен Вашего почтового ящика(для почтового ящика mailname@mail.ru - smtp.mail.ru,
            //listname @list.ru - smtp.list.ru, bkname@bk.ru - smtp.bk.ru, inboxname@inbox.ru - smtp.inbox.ru).
            //    порт - 2525 // 465 навсякий
            //денисыч123123
            _server = server;
            _from = from;
            _to = to;
            //for (int i = 0; i < 10; i++)
            //{
                try
                {
                    using (var message = new MailMessage(_from, _to, "Test message", "Test messae body"))
                    {
                        using (var client = new SmtpClient(_server, 2525)
                        {
                            EnableSsl = true,
                            Credentials = new NetworkCredential(strUser, strPass)
                        })
                        {
                            client.Send(message);
                        }
                    }
                }
                catch (SmtpException error)
                {
                    throw new SmtpException(error.Message);
                }
            // }
        }
        private static string _server, _from, _to;
        //я вот пока не знаю как лучше создать статический конструктор и заполнять нужные переменные
        //или через функцию заполнять
        //и должны быть они открытыми, свойства и тд. По ходу видно будет
    }
}
