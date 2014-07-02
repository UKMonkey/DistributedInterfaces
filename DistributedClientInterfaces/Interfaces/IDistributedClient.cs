namespace DistributedClientInterfaces.Interfaces
{
    /************************************************************************/
    /* This is the interface that is available to programs that wish to run */
    /* a distributed client                                                 */
    /************************************************************************/
    public interface IDistributedClient
    {
        // TODO - event on disconnect
        // TODO - event on job complete
        // TODO - events on dll change

        // connects to the server - returns true if the connection was a success, false otherwise
        bool Connect(string host, int port, 
            string newDllDirectory, string workingDllDirectory,
            string userName, string password);

        // force the client to disconnect
        void Disconnect();

        // TODO - connection stats
        // TODO - job stats / dll
    }
}
