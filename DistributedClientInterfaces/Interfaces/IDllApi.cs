using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DistributedSharedInterfaces.Jobs;

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
        byte[] SupportingData { set; }

        void OnDllLoaded(IClientApi client);
        byte[] ProcessJob(IJobData job);
    }
}
