using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EconomyReloaded.Core.Models.Economy;

namespace EconomyReloaded.Core.Repositories.Economy
{
    public interface IReceiptRepository
    {
        IEnumerable<Receipt> GetReceiptsOnUserId(int userId);
        void Insert(Receipt receipt);
        void Delete(int receiptId);
    }
}
