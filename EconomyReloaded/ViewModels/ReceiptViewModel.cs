using System;

namespace EconomyReloaded.ViewModels
{
  public class ReceiptViewModel
  {
    public int ReceiptId { get; set; }
    public string ReceiptName { get; set; }
    public decimal ReceiptTotal { get; set; }
    public DateTime ReceiptDate { get; set; }
  }
}