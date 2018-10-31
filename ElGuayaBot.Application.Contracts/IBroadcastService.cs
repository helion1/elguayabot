namespace ElGuayaBot.Application.Contracts
{
    public interface IBroadcastService
    {
        void CommunicateToAll(string message);
    }
}