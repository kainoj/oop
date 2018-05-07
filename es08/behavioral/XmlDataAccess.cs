using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace datahandler {

    class XmlDataAccess : DataAccessHandler
    {
        XDocument d;
        List<string> nodes = new List<string>();

        public override void Connect()
        {
            /*
             * Example XML file taken from
             * https://msdn.microsoft.com/en-us/library/ms762271(v=vs.85).aspx
             */
            d = XDocument.Load("books.xml");
        }

        public override void Select()
        {
            foreach(var node in d.Descendants()) {
                nodes.Add(node.Name.ToString());
            }
        }

        public override void Process()
        {
            nodes.Sort((a, b) => b.Length.CompareTo(a.Length)); // descending
        }

        public override void Disconnect()
        {
            Console.WriteLine("Longest node name: \"{0}\" ({1} chars)", 
                               nodes[0], nodes[0].Length);
        }
    }
}