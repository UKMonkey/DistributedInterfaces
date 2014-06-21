using System.Data.SQLite;

namespace DistributedServerInterfaces.Interfaces
{
    public interface IServerApi
    {
        /// <summary>
        /// Stops the server sending any new calls to "GetNextJobGroup".  It will continue to process any jobs that
        /// had already been queued.
        /// </summary>
        void HoldNewRequests();

        /// <summary>
        /// Undoes the "HoldNewRequests" call.
        /// </summary>
        void ContinueProcessingRequests();

        /// <summary>
        /// Returns if any new jobs will be requested.
        /// </summary>
        /// <returns></returns>
        bool IsAcceptingRequests();
    }
}
