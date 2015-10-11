using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EconomyReloaded.Core.Models.Economy;

namespace EconomyReloaded.Core.Factory.Economy
{
  public class ReceiptFactory : IReceiptFactory
  {
    public Receipt CreateReceipt(SqlDataReader reader)
    {
      var receipt = new Receipt();

      receipt.ReceiptId = Convert.ToInt32(reader["ReceiptId"]);
      receipt.UserId = Convert.ToInt32(reader["UserId"]);
      receipt.ReceiptName = reader["ReceiptName"].ToString();
      receipt.TotalPrice = Convert.ToDecimal(reader["TotalPrice"]);
      receipt.ReceiptRows = new List<ReceiptRow>();
      receipt.ReceiptDate = Convert.ToDateTime(reader["ReceiptDate"]);

      return receipt;
    }
  }
}
