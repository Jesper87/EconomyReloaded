using System;
using System.Collections.Generic;

namespace EconomyReloaded.Core.Models.Economy
{
    public class Receipt
    {
        public int UserId { get; set; }
        public int ReceiptId { get; set; }
        public string ReceiptName { get; set; }
        public List<ReceiptRow> ReceiptRows { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime ReceiptDate { get; set; }
    }
}
