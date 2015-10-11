using System.Data.SqlClient;
using EconomyReloaded.Core.Models.Economy;

namespace EconomyReloaded.Core.Factory.Economy
{
    public interface IReceiptFactory
    {
        Receipt CreateReceipt(SqlDataReader reader);
    }
}