namespace PinPayments
{
    public interface IPinList
    {
        int Current { get; set; }

        int? Next { get; set; }

        int Pages { get; set; }

        int PageSize { get; set; }

        int? Previous { get; set; }

        int Total { get; set; }
    }
}