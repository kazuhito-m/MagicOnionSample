using System;
using System.Threading.Tasks;
using Interface;
using MagicOnion.Server.Hubs;

namespace Server
{
    public class SampleHub : StreamingHubBase<ISampleHub, ISampleReceiver>, ISampleHub
    {
        IGroup group;


        public async Task JoinAsync(string id)
        {
            Console.WriteLine("JoinAsinc:" + id);
            group = await Group.AddAsync(id);
            Console.WriteLine("Group.AddAsync()終わった！次OnJoin");
            Broadcast(group).OnJoin("接続完了しました。");
            Console.WriteLine("OnJoin()終わった。");
        }

        public async Task LeaveAsync()
        {
            Console.WriteLine("LeaveAsync");
            Broadcast(group).OnLeave("切断完了しました。");
            Console.WriteLine("OnLeave()終わった。");
        }

        public async Task SendMessageAsync(string message)
        {
            Console.WriteLine("SendMessageAsync:" + message);
            Broadcast(group).OnSendMessage("サーバからの返答です:" + message);
            Console.WriteLine("OnSendMessage()終わった。");
        }
    }
}
