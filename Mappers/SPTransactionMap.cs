using CsvHelper.Configuration;
using TodoApi.Models;

namespace TodoApi.Mappers
{
    public class SPTransactionMap : ClassMap<SPTransaction>
    {
        public SPTransactionMap()
        {
            Map(m => m.TransactionType).Name("Transaction Type");
            Map(m => m.BlockchainTransactionId).Name("Blockchain Transaction ID");
            Map(m => m.Date).Name("Date");
            Map(m => m.AmountDebited).Name("Amount Debited");
            Map(m => m.DebitCurrency).Name("Debit Currency");
            Map(m => m.CreditCurrency).Name("Credit Currency");
            Map(m => m.BuySellRate).Name("Buy / Sell Rate");
            Map(m => m.Direction).Name("Direction");
            Map(m => m.SpotRate).Name("Spot Rate");
            Map(m => m.SourceDestination).Name("Source / Destination");
        }
    }
}
