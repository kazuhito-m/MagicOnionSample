namespace Interface
{
    public interface ISampleReceiver
    {
        void OnJoin(string info);
        void OnLeave(string info);
        void OnSendMessage(string message);
    }
}
