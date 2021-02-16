﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travely.SchedulerManager;

namespace Travely.SchedulerManager.API.ConfigManager
{
    public class ConnectionStrings
    {
        public const string Section = "ConnectionStrings";
        public string Jobs { get; set; }
        public string Notifier { get; set; }
        public string Repository { get; set; }
    }
}