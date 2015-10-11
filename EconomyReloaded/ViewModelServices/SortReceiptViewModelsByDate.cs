using System;
using System.Collections.Generic;
using System.Linq;
using EconomyReloaded.ViewModels;

namespace EconomyReloaded.ViewModelServices
{
  public class SortReceiptViewModelsByDate
  {
    private const string DateFormat = "yyyy-MM";

    public static IEnumerable<IGrouping<string, ReceiptViewModel>> Sort(IEnumerable<ReceiptViewModel> model)
    {
      return model.OrderBy(x=>x.ReceiptDate).GroupBy(x => x.ReceiptDate.ToString(DateFormat));
    }
  }
}