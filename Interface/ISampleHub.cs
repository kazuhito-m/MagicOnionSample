using System.Threading.Tasks;
using MagicOnion;

namespace Interface
{
    public interface ISampleHub : IStreamingHub<ISampleHub, ISampleReceiver>
    {
        Task JoinAsync(string id);
        Task LeaveAsync();
        Task SendMessageAsync(string message);
    }
}
