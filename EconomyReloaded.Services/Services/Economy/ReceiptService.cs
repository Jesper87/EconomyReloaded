using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EconomyReloaded.Core.Models.Economy;
using EconomyReloaded.Core.Repositories.Economy;

namespace EconomyReloaded.Services.Services.Economy
{
    public class ReceiptService : IReceiptService
    {
        private readonly IReceiptRepository _receiptRepository;

        public ReceiptService(IReceiptRepository receiptRepository)
        {
            _receiptRepository = receiptRepository;
        }

        public IEnumerable<Receipt> GetReceiptsOnUserId(int userId)
        {
            var receipts = _receiptRepository.GetReceiptsOnUserId(userId);
            if (receipts != null)
                return receipts;
            return null;

            //throw new ReceiptsNotFoundException("No receipts found on userId");
        }

        public void InsertReceipt(Receipt receipt)
        {
            if (receipt.UserId > 0)
                _receiptRepository.Insert(receipt);
        }
    }
}
