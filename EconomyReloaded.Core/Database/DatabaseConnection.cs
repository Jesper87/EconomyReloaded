using System.Configuration;

namespace EconomyReloaded.Core.Database
{
    public sealed class DatabaseConnection : IDatabaseConnection
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