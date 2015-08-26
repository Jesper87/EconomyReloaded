using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomyReloaded.Core.Models.Economy
{
    public class ReceiptRow
    {
        public int ReceiptRowId { get; set; }
        public int ReceiptId { get; set; }
        public string ProductName { get; set; }
        public decimal ProcuctPrice { get; set; }
        public int AmountOfProducts { get; set; }
    }
}
