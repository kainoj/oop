using NUnit.Framework;
using smtp;

namespace Tests {

    public class SmtpFacadeTest {

        [Test]
        public void smtpTest() {

            SmtpFacade smtp = new SmtpFacade("smtp.mailtrap.io", 2525, "top", "secret");

            smtp.Send("from@example.com", "to@example.com", "A subject", "BODY");
        }
    }
}


