using System;
using System.Runtime.Serialization;

namespace EconomyReloaded.Api.Controllers
{
    [DataContract]
    public class ReceiptHalFormat
    {
        [DataMember]
        public int UserId { get; set; }

        [IgnoreDataMember]
        public int ReceiptId { get; set; }

        [DataMember]
        public string ReceiptName { get; set; }

        [DataMember]
        public decimal TotalPrice { get; set; }

        [DataMember]
        public DateTime ReceiptDate { get; set; }
    }
}