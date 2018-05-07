using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace datahandlerstrategy {
    /*
     * Template design pattern  
     */
    public interface IDataAccessHandlerStrategy {

        void Connect();
        void Select();
        void Process();
        void Disconnect();
    }

    public class XmlDataContext
    {
        IDataAccessHandlerStrategy strategy;
        public XmlDataContext(IDataAccessHandlerStrategy idata) {
            this.strategy = idata;
        }

        public void Execute() {
            strategy.Connect();
            strategy.Select();
            strategy.Process();
            strategy.Disconnect();
        }
    }

    public class XmlStrategy : IDataAccessHandlerStrategy
    {
        XDocument d;
        List<string> nodes = new List<string>();

       public void Connect()
        {
            d = XDocument.Load("books.xml");
        }

        public void Select()
        {
            foreach(var node in d.Descendants()) {
                nodes.Add(node.Name.ToString());
            }
        }

        public void Process()
        {
            nodes.Sort((a, b) => b.Length.CompareTo(a.Length)); // descending
        }

        public void Disconnect()
        {
            Console.WriteLine("Longest node name: \"{0}\" ({1} chars)", 
                               nodes[0], nodes[0].Length);
        }
    }
}