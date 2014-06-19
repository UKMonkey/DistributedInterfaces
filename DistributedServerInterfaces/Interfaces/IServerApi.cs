using System.Data.SQLite;

namespace DistributedServerInterfaces.Interfaces
{
    public interface IServerApi
    {
        void HoldNewRequests();
        void ContinueProcessingRequests();

        bool IsAcceptingRequests();

        SQLiteConnection GetSQInterface();
    }
}
