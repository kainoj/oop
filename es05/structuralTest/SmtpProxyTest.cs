using System;
using NUnit.Framework;
using proxy;

namespace Tests {
    public class SmtpProxyTest {

        [Test]
        public void SmtpProtectorTest() {
            
            SmtpProxyProtector p = new SmtpProxyProtector("smtp.mailtrap.io", 2525, "top", "secret");
            p.hour = 7;

            Assert.Throws<Exception>( 
            () => p.Send("from@example.com", "to@example.com", "A subject", "BODY")
            );
        }

        [Test]
        public void SmtpLoggerTest() {

            SmtpProxyLogger p = new SmtpProxyLogger("smtp.mailtrap.io", 2525, "top", "secret");
            p.Send("from@example.com", "to@example.com", "A subject", "BODY");

        }
    }
}