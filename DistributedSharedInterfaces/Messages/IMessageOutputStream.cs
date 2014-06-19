namespace DistributedSharedInterfaces.Messages
{
    public interface IMessageOutputStream
    {
        int Read(byte[] buffer, int amount);

        void ResetStats();
        long GetDataSize();
    }
}
