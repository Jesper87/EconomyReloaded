using System;
using System.Collections.Generic;
using System.Linq;
using EconomyReloaded.ViewModels;

namespace EconomyReloaded.ViewModelServices
{
  public class SortReceiptViewModelsByDate
  {
    public static Dictionary<string, List<ReceiptViewModel>> Sort(IEnumerable<ReceiptViewModel> model)
    {
      var sortedReceipts = new Dictionary<string, List<ReceiptViewModel>>();
      var sortedModel = model.OrderBy(r => r.ReceiptDate);

      foreach (var item in sortedModel)
      {
        var date = RemoveDays(item.ReceiptDate);
        if (!sortedReceipts.ContainsKey(date))
          sortedReceipts.Add(date, new List<ReceiptViewModel>());
      }

      foreach (var item in sortedModel)
      {
        var date = RemoveDays(item.ReceiptDate);
        if (sortedReceipts.ContainsKey(date))
        {
          sortedReceipts[date].Add(item);
        }
      }

      return sortedReceipts;
    }

    private static string RemoveDays(DateTime dateTime)
    {
      return dateTime.ToString("yyyy-MM");
    }
  }
}