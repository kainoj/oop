using System.IO;
using NUnit.Framework;
using caesar;
using System.Text;

namespace Tests {

    public class CSDTest {


        [Test]
        public void Test() {

            string testFile = "test.txt";
            string text = "traaaalalalala";
            
            byte[] textToFile = Encoding.ASCII.GetBytes(text);
            byte[] textFromFile = new byte[textToFile.Length];

            FileStream fileToWrite = File.Create(testFile);
            CaesarStream caeToWrite = new CaesarStream(fileToWrite, 5);

            caeToWrite.Write(textToFile, 0, textToFile.Length);
            fileToWrite.Close();

            FileStream fileToRead = File.Open(testFile, FileMode.Open);
            CaesarStream caeToRead = new CaesarStream(fileToRead, -5);
           
            
            caeToRead.Read(textFromFile, 0, textToFile.Length);
            string fromFile = Encoding.ASCII.GetString(textFromFile);

            Assert.AreEqual(textToFile, textFromFile);            
        }
    }
}