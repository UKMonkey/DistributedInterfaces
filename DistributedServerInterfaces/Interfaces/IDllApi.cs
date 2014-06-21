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

        /// <summary>
        /// supporting data is 'global' data sent to all clients
        /// if updated during a "GetNextJobGroup" call, then all jobs in that group will have that supporting
        /// data or later - note that this means it's important that it is always backwards compatable.
        /// </summary>
        byte[] SupportingData { get; }

        /// <summary>
        /// The status is saved after each call to 'GetNextJobGroup'
        /// it is saved at the same time as the new collection of jobs to ensure that every job is created once
        /// and that all jobs will be performed that are provided.  Ie - for the same status, the next job group
        /// provided should be the same.
        /// 
        /// Set is guarenteed to be called rarely and in a thread safe way.  In all likelyhood, only
        /// once just after the dll is loaded.
        /// </summary>
        byte[] StatusData { get; set; }

        /// <summary>
        /// Allows the dll to prepare itself before any jobs are requested. Called only once when the dll is loaded
        /// </summary>
        /// <param name="server"></param>
        void OnDllLoaded(IServerApi server);

        /// <summary>
        /// requests a job group of a certain size.  There is no requirement that the job group is
        /// actually that size, but provides a target that the dll should aim for.
        /// only one thread will call this at a time, allowing the system to modify anything that
        /// would change the status byte array.  The status byte array and the provided jobs will be 
        /// saved atomicaly.
        /// </summary>
        /// <param name="jobCount"></param>
        /// <returns></returns>
        IJobGroup GetNextJobGroup(int jobCount);

        /// <summary>
        /// Called when a job has been completed.  This may be called by multiple threads, and at the 
        /// same time as the 'GetNextJobGroup'.  It is the responsibility of the dll to ensure that 
        /// there is no conflict.  It is acceptable for the supporting data to change during this, but
        /// not recommended, as there could be a large number of jobs.  It is better to queue any changes
        /// and apply them on the next call to 'GetNextJobGroup'
        /// </summary>
        /// <param name="request"></param>
        void DataProvided(IJobResultData request);

        /// <summary>
        /// Returns a job group that we can use after a system restore.  This will have the data content
        /// set by the controlling system, and expect to have all jobs retreivable as though it had been
        /// returned by the "GetNextJobGroup"
        /// </summary>
        /// <returns></returns>
        IJobGroup GetCleanJobGroup();
    }
}
