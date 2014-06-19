﻿using System;

namespace DistributedSharedInterfaces.Jobs
{
    public interface IJobData
    {
        String DllName { get; set; }
        String SupportingDataMd5 { get; set; }
        long JobId { get; set; }

        byte[] Data { get; set; }
    }
}