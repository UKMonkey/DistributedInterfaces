using System;
using DistributedSharedInterfaces.Messages;
using DistributedShared.Network;

namespace DistributedServerInterfaces.Networking
{
    public delegate void ConnectionCallback(IConnection soc);
    public delegate void MessageCallback(IConnection soc, Message data);

    public interface IConnectionManager
    {
        event ConnectionCallback NewConnectionMade;
        event ConnectionCallback ConnectionLost;

        void ListenForConections(int port);
        void StopListening();

        void RegisterMessageBypassingSecurity(Type messageType);
        void RegisterMessageListener(Type msgType, MessageCallback messageHandler);
        void SendMessage(IConnection connection, Message msg);
        void SendMessageToAll(Message msg);
    }
}
