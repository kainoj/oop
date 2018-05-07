namespace datahandler {
    /*
     * Template design pattern  
     */
    public abstract class DataAccessHandler {

        public abstract void Connect();
        public abstract void Select();
        public abstract void Process();
        public abstract void Disconnect();

        public void Execute() {
            Connect();
            Select();
            Process();
            Disconnect();
        }
    }
}