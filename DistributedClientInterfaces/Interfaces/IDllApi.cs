using System;
using DistributedSharedInterfaces.Jobs;
using System.Collections.Generic;

namespace DistributedClientInterfaces.Interfaces
{
    public delegate void DllApiCallback(IDllApi item);

    /************************************************************************/
    /* The supporting data for jobs must be ready before the jobs are      **/
    /* Returned                                                            **/
    /* This is the interface that all the dlls that wish to provide work   **/
    /* must implement                                                      **/
    /************************************************************************/
    public interface IDllApi : IDisposable
    {
        Dictionary<String, byte[]> SupportingData { set; }

        void OnDllLoaded(IClientApi client);
        byte[] ProcessJob(IJobData job);
    }
}
