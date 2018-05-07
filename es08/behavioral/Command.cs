using System;
using System.Collections.Concurrent;

namespace command {

    public interface IReceiver
    {
        void Action(string[] state);        
    }

    public abstract class Command {
        
        IReceiver receiver;

        public Command(IReceiver receiver) {
            this.receiver = receiver;
        }

        public void Execute(string[] state) {
            receiver.Action(state);
        }
    }

    public class Invoker {

        ConcurrentQueue<Tuple<Command, string[]>> queue;
        
        public Invoker() {
            queue = new ConcurrentQueue<Tuple<Command, string[]>>();
        }
        
        public void Enqueue(Command command, string[] state) {
            queue.Enqueue(new Tuple<Command, string[]>(command, state));
        }

        public void Dequeue() {
            Tuple<Command, string[]> tup;
            queue.TryDequeue(out tup);
            tup.Item1.Execute(tup.Item2);
        }
    }


    public class FtpCommand : Command {
        public FtpCommand(IReceiver receiver) : base(receiver) {}
    }

    public class HttpCommand : Command {
        public HttpCommand(IReceiver receiver) : base(receiver) {}
    }

    public class CopyFileCommand : Command
    {
        public CopyFileCommand(IReceiver receiver) : base(receiver) {}
    }
}