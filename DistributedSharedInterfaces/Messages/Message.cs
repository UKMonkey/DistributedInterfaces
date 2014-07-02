namespace DistributedSharedInterfaces.Messages
{
    public abstract class Message
    {
        public bool ValidToSerialise { get; set; }
        private long MessageSize { get; set; }

        protected Message()
        {
            ValidToSerialise = true;
        }

        public void PushToStream(IMessageInputStream target)
        {
            target.ResetStats();
            Serialise(target);
            MessageSize = target.GetDataSize();
        }

        public void LoadFromStream(IMessageOutputStream source)
        {
            source.ResetStats();
            Deserialise(source);
            MessageSize = source.GetDataSize();
        }

        protected abstract void Serialise(IMessageInputStream target);
        protected abstract void Deserialise(IMessageOutputStream source);

        public long GetMessageSize()
        {
            return MessageSize;
        }
    }
}
