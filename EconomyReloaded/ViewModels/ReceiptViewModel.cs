using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EconomyReloaded.ViewModels
{
    public class ReceiptViewModel
    {
        public string ReceiptName { get; set; }
        public decimal ReceiptTotal { get; set; }
        public DateTime ReceiptDate { get; set; }
    }
}