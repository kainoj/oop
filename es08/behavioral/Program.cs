using System;
using System.Collections.Generic;
using command;
using datahandler;
using datahandlerstrategy;

namespace behavioral
{
    class Program
    {
        static void Main(string[] args)
        {
            Invoker invoker = new Invoker();
            invoker.Enqueue(new HttpCommand(new GetHttp()), new string[] {"wp.pl"});
            invoker.Enqueue(new FtpCommand(new GetFtp()), new string[] {"8.8.8.8"});
            invoker.Enqueue(new CopyFileCommand(new CopyFile()), new string[] {"a.txt", "b.txt"});

            invoker.Dequeue();
            invoker.Dequeue();
            invoker.Dequeue();

            Console.WriteLine("=================");

            Console.WriteLine("\n> XML pasrse using a TEMPLATE pattern");
            
            DataAccessHandler xml = new XmlDataAccess();
            xml.Execute();

            // Requires a Posgress DB
            // DataAccessHandler db = new DbDataAccess();
            // db.Execute();
            Console.WriteLine("\n> XML pasrse using a STRATEGY pattern");
            XmlDataContext xml2 = new XmlDataContext(new XmlStrategy());
            xml2.Execute();
        }
    }
}
