using System;

namespace command {

    public class GetFtp : IReceiver
    {
        public void Action(string[] state)
        {
            string ip = (state.Length > 0)? state[0] : "127.0.0.1";
            Console.WriteLine("[Action] GET FTP\t{0}", ip);
        }
    }

    public class GetHttp : IReceiver
    {
        public void Action(string[] state)
        {
            string url = (state.Length > 0)? state[0] : "localhost";
            Console.WriteLine("[Action] GET HTTP\t{0}", url);
        }
    }

    public class CopyFile : IReceiver
    {
        public void Action(string[] state)
        {
            if(state.Length == 2) {
                string from = state[0];
                string to = state[1];
                Console.WriteLine("[Action] Copy file\t{0} → {1}", from, to);
            }
        }
    }
}