using System;
using Interface;

namespace Client
{
    public class SampleReceiver : ISampleReceiver
    {
        void ISampleReceiver.OnJoin(string info)
        {
            Console.WriteLine(info);
        }

        void ISampleReceiver.OnLeave(string info)
        {
            Console.WriteLine(info);
        }

        void ISampleReceiver.OnSendMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
