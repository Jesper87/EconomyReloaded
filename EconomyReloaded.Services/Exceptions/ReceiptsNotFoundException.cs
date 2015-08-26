using System;
using System.Runtime.Serialization;

namespace EconomyReloaded.Services.Services.Economy
{
    [Serializable]
    internal class ReceiptsNotFoundException : Exception
    {
        public ReceiptsNotFoundException()
        {
        }

        public ReceiptsNotFoundException(string message) : base(message)
        {
        }

        public ReceiptsNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ReceiptsNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}