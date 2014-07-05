using DistributedSharedInterfaces.Serialisation;
namespace DistributedSharedInterfaces.Jobs
{
    public interface IJobResultData : ISerialisable
    {
        IJobData Job { get; }

        long CyclesSpentWorking { get; }
        bool CyclesSpentWorkingIsReliable { get; }
    }
}
