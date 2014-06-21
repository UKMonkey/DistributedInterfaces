using System;

namespace DistributedSharedInterfaces.Jobs
{
    public interface IJobData
    {
        String DllName { get; set; }
        long SupportingDataVersion { get; set; }
        long JobId { get; set; }

        byte[] Data { get; set; }
    }
}
