using System;
using DistributedSharedInterfaces.Jobs;
using System.Collections.Generic;

namespace DistributedServerInterfaces.Interfaces
{
    public delegate void DataChangedCallback(String key, byte[] newValue);

    /************************************************************************/
    /* Threading model:                                                     */
    /*   One thread will be responsible for getting the next job collection */
    /*   One thread will be responsible for offering the results            */
    /*   Any number of threads may call SupportingData / StatusData         */
    /*   Any number of threads may call GetCleanJobGroup                    */
    /*   It is essential that the supporting data and status                */
    /*   are updated only during the "GetNextJobGroup" or "DataProvided"    */
    /*   Clearly if they are changed it must be in a thread safe way        */
    /************************************************************************/
    public interface IDllApi : IDisposable
    {
        /// <summary>
        /// Supporting data is sent to every client.  All clients will have
        /// at least the version that is available when the job was created.  They may have a later
        /// one also; so it's important that the supporting data is backwards compatible.
        /// There is a single key that is reserved for the supporting data; using it will result in 
        /// data loss.  This key is
        /// "__RESERVED__:Version"
        /// This key contains the version of the supporting data currently available; which
        /// is provided to all jobs created
        /// </summary>
        event DataChangedCallback SupportingDataChanged;

        /// <summary>
        /// The status data is server data only that allows it to keep track of 
        /// what jobs need to be done.  Note that since the system guarentees that 
        /// a job will be done, it doesn't need to keep track of what jobs are left to do
        /// unless there is a reason that data is of use.
        /// 
        /// An example; for a prime number calculator, the supporting data would be the 
        /// known prime numbers.  The status would be largest number that has been queued, the numbers
        /// that have not yet been processed, and the largest number that can be queued (ie largest number 
        /// processed so far sqrded)  There is no need for the clients to know what numbers have / have not yet
        /// been processed, but the list of known primes would be essential for all clients and jobs.
        /// 
        /// Same as the supporting data, there is a reserved key;  "__RESERVED__:Version" which is the version of the status
        /// </summary>
        event DataChangedCallback StatusDataChanged;

        /// <summary>
        /// Allows the dll to prepare itself before any jobs are requested. Called only once when the dll is loaded
        /// The last known supporting data and status are provided.  It is in this function that the dll
        /// can tear apart these values and return itself to the last known good state
        /// Importantly, the events that the supporting data / status have changed will not be listened to
        /// until after this function has returned (but before any other function is called)
        /// </summary>
        /// <param name="server"></param>
        void OnDllLoaded(IServerApi server, Dictionary<String, byte[]> supportingData, Dictionary<String, byte[]> status);

        /// <summary>
        /// requests a job group of a certain size.  There is no requirement that the job group is
        /// actually that size, but provides a target that the dll should aim for.
        /// only one thread will call this at a time, allowing the system to modify anything that
        /// would change the status byte array.  The status byte array and the provided jobs will be 
        /// saved atomically.
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
