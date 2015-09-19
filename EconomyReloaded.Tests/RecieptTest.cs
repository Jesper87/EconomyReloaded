using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using EconomyReloaded.Controllers;
using EconomyReloaded.Core.Database;
using EconomyReloaded.Core.Factories.Economy;
using EconomyReloaded.Core.Factories.User;
using EconomyReloaded.Core.Repositories.Economy;
using EconomyReloaded.Core.Repositories.User;
using EconomyReloaded.Services.Services.Economy;
using EconomyReloaded.Services.Services.User;
using EconomyReloaded.ViewModels;
using EconomyReloaded.ViewModelServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Core;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace EconomyReloaded.Tests
{
  /// <summary>
  /// Summary description for RecieptTest
  /// </summary>
  [TestFixture]
  public class RecieptTest
  {
    public RecieptTest()
    {
      //
      // TODO: Add constructor logic here
      //
    }

    [Test]
    public void EnusureMonthsAreSortedLowToHighNumber()
    {
      //Arrange
      var data = MockData();

      //Act
      var test = SortReceiptViewModelsByDate.Sort(data);

      //Assert
      var firstEle = test.First().Key.Split('-');
      var lastEle = test.Last().Key.Split('-');

      Assert.LessOrEqual(firstEle[1], lastEle[1]);
    }

    private List<ReceiptViewModel> MockData()
    {
      var list = new List<ReceiptViewModel>
      {
        new ReceiptViewModel
        {
          ReceiptDate = new DateTime(2015, 11, 2),
          ReceiptId = 1,
          ReceiptName = "Test1",
          ReceiptTotal = 123
        },
        new ReceiptViewModel
        {
          ReceiptDate = new DateTime(2015, 2, 3),
          ReceiptId = 2,
          ReceiptName = "Test2",
          ReceiptTotal = 123
        },
        new ReceiptViewModel
        {
          ReceiptDate = new DateTime(2015, 3, 12),
          ReceiptId = 3,
          ReceiptName = "Test3",
          ReceiptTotal = 123
        },
        new ReceiptViewModel
        {
          ReceiptDate = new DateTime(2015, 12, 7),
          ReceiptId = 4,
          ReceiptName = "Test4",
          ReceiptTotal = 123
        },
        new ReceiptViewModel
        {
          ReceiptDate = new DateTime(2015, 4, 2),
          ReceiptId = 5,
          ReceiptName = "Test4",
          ReceiptTotal = 123
        },
        new ReceiptViewModel
        {
          ReceiptDate = new DateTime(2015, 1, 12),
          ReceiptId = 6,
          ReceiptName = "Test6",
          ReceiptTotal = 123
        },
        new ReceiptViewModel
        {
          ReceiptDate = new DateTime(2015, 11, 22),
          ReceiptId = 2,
          ReceiptName = "Test6",
          ReceiptTotal = 123
        },
        new ReceiptViewModel
        {
          ReceiptDate = new DateTime(2015, 1, 2),
          ReceiptId = 1,
          ReceiptName = "Test1",
          ReceiptTotal = 123
        },
        new ReceiptViewModel
        {
          ReceiptDate = new DateTime(2015, 2, 3),
          ReceiptId = 2,
          ReceiptName = "Test2",
          ReceiptTotal = 123
        },
        new ReceiptViewModel
        {
          ReceiptDate = new DateTime(2015, 3, 12),
          ReceiptId = 3,
          ReceiptName = "Test3",
          ReceiptTotal = 123
        },
        new ReceiptViewModel
        {
          ReceiptDate = new DateTime(2015, 4, 7),
          ReceiptId = 4,
          ReceiptName = "Test4",
          ReceiptTotal = 123
        },
        new ReceiptViewModel
        {
          ReceiptDate = new DateTime(2015, 4, 2),
          ReceiptId = 5,
          ReceiptName = "Test4",
          ReceiptTotal = 123
        },
        new ReceiptViewModel
        {
          ReceiptDate = new DateTime(2015, 7, 27),
          ReceiptId = 6,
          ReceiptName = "Test6",
          ReceiptTotal = 123
        },
        new ReceiptViewModel
        {
          ReceiptDate = new DateTime(2015, 11, 22),
          ReceiptId = 2,
          ReceiptName = "Test6",
          ReceiptTotal = 123
        }
      };

      return list;
    }
  }
}
