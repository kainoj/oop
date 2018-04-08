using System;
using System.IO;
using smtp;

namespace proxy {

    public class SmtpProxyProtector : SmtpFacade {

        public int hour {get; set;} = 7;
      
        public SmtpProxyProtector(string server, int port, string user, string pw)
             : base(server, port, user, pw) {
        
        }
        public void Send(string From, string To, string Subject, string Body,
                    Stream Attachment = null, string AttachmentMimeType = "" ) {

            int hour = 7;

            if ( 8 <= hour && hour < 22 ) {
                base.Send(From, To, Subject, Body, Attachment, AttachmentMimeType);
            }
            else {
                throw new Exception("Sending() is available 8-22 only");
            }
        }
    }

    public class SmtpProxyLogger : SmtpFacade {

        enum Status {INFO, OK, ERROR};

        private void log(string str, string who = "*", Status s=Status.INFO) {

            string date = DateTime.Now.ToString("h:mm:ss");


            string msg = String.Format("[{0}] [{1}] [{2}] \t{3}", date, s, who, str);
            
            // TODO
            Console.WriteLine(msg);
        }

        private void logInfo(string str, string who = "*") {
            log(str, who, Status.INFO);
        }

        private void logOk(string str, string who = "*") {
            log(str, who, Status.OK);
        }

        private void logErr(string str, string who = "*") {
            log(str, who, Status.ERROR);
        }

        public SmtpProxyLogger(string server, int port, string user, string pw)
             : base(server, port, user, pw) {
                
            logInfo(String.Format("Created new smtp fascade: {0}:{1}", server, port), "SmtpFacade");
        }

        public void Send(string From, string To, string Subject, string Body,
                    Stream Attachment = null, string AttachmentMimeType = "" ) {

            logInfo("Sending email...", "SmtpFacade.Send");

            Boolean success = true;
            string exMsg = "";

            try {
                base.Send(From, To, Subject, Body, Attachment, AttachmentMimeType);
            }
            catch (Exception ex) {
                success = false;
                exMsg = ex.ToString();
            }

            if (success) {
                logOk("...sent successfully!", "SmtpFacade.Send");
            }
            else {
                logErr(exMsg, "SmtpFacade.Send");
            }
        }
    }
}