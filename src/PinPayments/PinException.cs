namespace PinPayments
{
    using System;
    using System.Collections.Generic;
    using PinPayments.Entities;

    public class PinException : Exception
    {
        public PinException(string message)
            : base(message)
        {
            this.Messages = new List<PinErrorMessage>();
        }

        public string ErrorDescription { get; set; }

        public List<PinErrorMessage> Messages { get; set; }

        public string ErrorType { get; set; }
    }
}