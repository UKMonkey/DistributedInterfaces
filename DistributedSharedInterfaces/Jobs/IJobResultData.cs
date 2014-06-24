using DistributedSharedInterfaces.Serialisation;
namespace DistributedSharedInterfaces.Jobs
{
    public interface IJobResultData : ISerialisable
    {
        string DllName { get; }
        long JobId { get; }

        long CyclesSpentWorking { get; }
        bool CyclesSpentWorkingIsReliable { get; }
    }
}
