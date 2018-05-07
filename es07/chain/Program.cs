using System;
using mail;
using mailchain;

namespace chain
{
    class Program
    {
        static void Main(string[] args)
        {
            Mail mail = new Mail("wow, super product, good job!"); // ceo
            Mail mail2 = new Mail("wanna complain, this product is bad"); // law
            Mail mail3 = new Mail("wanna order product no 222"); // orders
            Mail mail4 = new Mail("asd"); // pr

            MailHandler handler = new Praise();
            MailHandler complaint = new Complaint();
            MailHandler order = new Order();
            MailHandler rest = new Unimportant();
            
            // Handler (praise) -> complaint -> order -> unimportant
            handler.setNext(complaint);
            complaint.setNext(order);
            order.setNext(rest);

            handler.ProcessRequest(mail);
            handler.ProcessRequest(mail2);
            handler.ProcessRequest(mail3);
            handler.ProcessRequest(mail4);            
        }
    }
}
