using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace EconomyReloaded.Data
{
    public class DatabaseConnection
    {
        private string _connectionString;
        public string ConnectionString
        {
            get
            {
                if (_connectionString == null)
                {
                    var connectionString = ConfigurationManager.ConnectionStrings["EconomyReloadedDB"].ConnectionString;

                    if (connectionString != null)
                        _connectionString = connectionString;
                }
                return _connectionString;
            }
        }
    }
}