using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EconomyReloaded.ViewModels
{
  public class CreateReceiptViewModel
  {
    [Required(ErrorMessage = "Please enter a receipt name")]
    public string ReceiptName { get; set; }

    [Required(ErrorMessage = "Please enter the total cost for the receipt")]
    public string ReceiptTotal { get; set; }

    [HiddenInput]
    [Required]
    public string UserId { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime ReceiptDate { get; set; }
  }
}