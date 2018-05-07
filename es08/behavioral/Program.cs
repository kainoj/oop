﻿using System;
using System.Collections.Generic;
using command;

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
        }
    }
}