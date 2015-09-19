using System.ComponentModel.DataAnnotations;

namespace EconomyReloaded.ViewModels
{
    public class DeleteReceiptViewModel
    {
        [Required]
        public string ReceiptId { get; set; }
    }
}