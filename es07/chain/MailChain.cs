using System;
using mail;
using archive;

namespace mailchain
{
    public abstract class MailHandler {
            
        protected MailHandler next;

        public abstract void ProcessRequest(Mail mail);

        public void setNext(MailHandler nextHandler) {
            this.next = nextHandler;
        }

        protected bool contains(string text, string[] strs) {
            foreach(var str in strs) {
                if (text.IndexOf(str, StringComparison.OrdinalIgnoreCase) < 0) {
                    return false;
                }
            }
            return true;
        }

        protected void process(Mail mail, string[] keywords, string towho) {

            if (contains(mail.body, keywords)) {
                Console.WriteLine("[TO: {0}]\t{1}",towho, mail.body);
                Archives.Instance().archive(mail);
            }
            else {
                if (next != null)
                    next.ProcessRequest(mail);
            }
        }
    }


    public class Praise : MailHandler
    {
        string[] keywords = new string[] {"super", "wow", "good"};
        public override void ProcessRequest(Mail mail)
        {
            process(mail, keywords, "CEO");
        }
    }

    public class Complaint : MailHandler
    {
        string[] keywords2 = new string[] {"complain", "bad"};
        public override void ProcessRequest(Mail mail)
        {
            process(mail, keywords2, "law dept");
        }
    }
    
    public class Order : MailHandler
    {
       string[] keywords = new string[] {"order", "product"};
        public override void ProcessRequest(Mail mail)
        {
            process(mail, keywords, "orders");
        }
    }

    public class Unimportant : MailHandler
    {
        public override void ProcessRequest(Mail mail)
        {
             Console.WriteLine("[TO: {0}]\t{1}", "pr", mail.body);
            Archives.Instance().archive(mail);
        }
    }
}