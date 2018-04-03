using System;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace smtp {

    public class SmtpFacade {

        SmtpClient client;

        public SmtpFacade(string server, int port, string user, string pw) {
            client = new SmtpClient(server, port);
            client.Credentials = new NetworkCredential(user, pw);
            client.EnableSsl = true;            
        }

        public void Send(string From, string To, string Subject, string Body,
                            Stream Attachment = null, string AttachmentMimeType = "" ) {

            MailMessage message = new MailMessage(From, To);

            message.Subject = Subject;
            message.Body = Body;

            if (Attachment != null) {
                message.Attachments.Add(new Attachment(Attachment, 
                                                       AttachmentMimeType));
            }
            
            try {
                client.Send(message);
            }  
            catch (Exception ex) {
                Console.WriteLine("SmtpFacade: {0}", ex.ToString() );			  
            }
        }
    }
}