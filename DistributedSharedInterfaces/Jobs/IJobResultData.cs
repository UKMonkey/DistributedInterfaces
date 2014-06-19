namespace DistributedSharedInterfaces.Jobs
{
    public interface IJobResultData
    {
        string DllName { get; }
        long JobId { get; }
        byte[] Data { get; }

        long CyclesSpentWorking { get; }
        bool CyclesSpentWorkingIsReliable { get; }
    }
}
