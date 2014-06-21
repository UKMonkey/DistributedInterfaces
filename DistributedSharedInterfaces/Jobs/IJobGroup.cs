using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributedSharedInterfaces.Jobs
{
    public interface IJobGroup
    {
        byte[] Data { get; set; }
        long GroupId { get; set; }
        long SupportingDataVersion { get; set; }

        int JobCount { get; }
        IEnumerable<IJobData> GetJobs();
    }
}
