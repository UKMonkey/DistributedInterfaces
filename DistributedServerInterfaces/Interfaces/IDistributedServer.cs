using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributedServerInterfaces.Interfaces
{
    public interface IDistributedServer
    {
        // TODO - events on client connection change
        // TODO - events on DLL changes
        // TODO - event on JobGroups complete

        // TODO - proxy server capabilities
        // (ie doesn't load any dlls, but holds many jobs for other clients to pick up)


        // Starts listening for clients.  Does not return unless there is a failure
        // or told to stop
        void StartListening(string newServerDlls, string workingServerDlls,
                            string newClientDlls, string workingClientDlls,
                            int port);

        void StopListening();

        // TODO - connection stats
        // TODO - client stats
        // TODO - job stats / dll
        // TODO - total job stats
        // TODO - database stats
    }
}
