﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoMongoDB.Models
{
    public class BoMayDatabaseSettings : IBoMayDatabaseSettings
    {
        public string BoMaysCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface IBoMayDatabaseSettings
    {
        public string BoMaysCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
