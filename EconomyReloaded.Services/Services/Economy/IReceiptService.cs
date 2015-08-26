using System.Collections.Generic;
using EconomyReloaded.Core.Models.Economy;

namespace EconomyReloaded.Services.Services.Economy
{
    public interface IReceiptService
    {
        IEnumerable<Receipt> GetReceiptsOnUserId(int userId);
        void InsertReceipt(Receipt receipt);
    }
}