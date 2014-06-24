using DistributedSharedInterfaces.Serialisation;
using System;

namespace DistributedSharedInterfaces.Jobs
{
    public interface IJobData : ISerialisable
    {
        String DllName { get; set; }
        long SupportingDataVersion { get; set; }
        long JobId { get; set; }
    }
}
