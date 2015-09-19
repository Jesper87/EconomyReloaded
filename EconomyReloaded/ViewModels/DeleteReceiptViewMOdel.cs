using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EconomyReloaded.ViewModels
{
    public class DeleteReceiptViewModel
    {
        [Required]
        public string ReceiptId { get; set; }
    }
}