using System;
using proxy;

namespace structural
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            SmtpProxyLogger p = new SmtpProxyLogger("smtp.mailtrap.io", 2525, "top", "secret");
            p.Send("from@example.com", "to@example.com", "A subject", "BODY");
        }
    }
}
