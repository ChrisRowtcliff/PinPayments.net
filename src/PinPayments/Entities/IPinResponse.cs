namespace PinPayments.Entities
{
    using System.Collections.Generic;

    internal interface IPinResponse
    {
        string Error { get; set; }

        string ErrorDescription { get; set; }

        List<PinErrorMessage> Messages { get; set; }
    }
}