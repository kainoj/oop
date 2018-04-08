using NUnit.Framework;
using smtp;

namespace Tests {

    public class SmtpFacadeTest {

        [Test]
        public void smtpTest() {

            string user = "top";
            string pw = "secet";

            SmtpFacade smtp = new SmtpFacade("smtp.mailtrap.io", 2525, user, pw);
            smtp.Send("from@example.com", "to@example.com", "A subject", "BODY");
        }
    }
}


