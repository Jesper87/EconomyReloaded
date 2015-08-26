using System.Data.SqlClient;
using EconomyReloaded.Core.Models.Economy;

namespace EconomyReloaded.Core.Factories.Economy
{
    public interface IReceiptFactory
    {
        Receipt CreateReceipt(SqlDataReader reader);
    }
}