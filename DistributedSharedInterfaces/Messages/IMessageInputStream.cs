namespace DistributedSharedInterfaces.Messages
{
    public interface IMessageInputStream
    {
        void Write(byte[] buffer, int offset, int size);
        void Flush();

        void ResetStats();
        long GetDataSize();
    }
}
