using System.Collections.Generic;
using DistributedSharedInterfaces.Serialisation;
using System;

namespace DistributedSharedInterfaces.Jobs
{
    public interface IJobGroup : ISerialisable
    {
        int JobCount { get; }
        IEnumerable<IJobData> GetJobs();
    }
}
