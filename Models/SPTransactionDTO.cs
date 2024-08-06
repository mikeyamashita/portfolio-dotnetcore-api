using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models;
public class SPTransactionDTO
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string? TransactionType { get; set; }
    public string? BlockchainTransactionId { get; set; }
    public string? Date { get; set; }
    public float? AmountDebited { get; set; }
    public string? DebitCurrency { get; set; }
    public float? AmountCredited { get; set; }
    public string? CreditCurrency { get; set; }
    public float? BuySellRate { get; set; }
    public string? Direction { get; set; }
    public float? SpotRate { get; set; }
    public string? SourceDestination { get; set; }
}