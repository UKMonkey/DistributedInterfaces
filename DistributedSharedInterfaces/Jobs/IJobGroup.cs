using System.Collections.Generic;
using DistributedSharedInterfaces.Serialisation;

namespace DistributedSharedInterfaces.Jobs
{
    public interface IJobGroup : ISerialisable
    {
        long GroupId { get; set; }
        long SupportingDataVersion { get; set; }

        int JobCount { get; }
        IEnumerable<IJobData> GetJobs();
    }
}
