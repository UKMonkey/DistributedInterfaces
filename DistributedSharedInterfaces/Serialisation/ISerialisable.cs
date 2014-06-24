using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributedSharedInterfaces.Serialisation
{
    public interface ISerialisable
    {
        byte[] Data { get; set; }
    }
}
