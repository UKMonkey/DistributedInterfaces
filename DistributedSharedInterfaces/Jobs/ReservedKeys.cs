using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributedSharedInterfaces.Jobs
{
    /// <summary>
    /// Keys that are reserved for the Status / Supporting data.
    /// There aren't many, and they're quite obvious.
    /// </summary>
    public static class ReservedKeys
    {
        public const String Version = "__RESERVED__:Version";


        public static String[] AllReservedKeys = new String[]{Version};
    }
}
