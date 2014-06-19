using System;
using System.Collections.Generic;
using DistributedSharedInterfaces.Jobs;

namespace DistributedServerInterfaces.Interfaces
{
    public delegate void DllApiCallback(IDllApi item);

    /************************************************************************/
    /* The supporting data for jobs must be ready before the jobs are      **/
    /* Returned                                                            **/
    /************************************************************************/
    public interface IDllApi : IDisposable
    {
        event DllApiCallback SupportingDataChanged;
        
        byte[] SupportingData { get; }

        void OnDllLoaded(IServerApi server);
        IJobGroup GetNextJobGroup(int jobCount);
        void DataProvided(IJobResultData request);
    }
}
