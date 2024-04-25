using Amazon.DynamoDBv2.DataModel;

namespace EtfBackend.Models;

[DynamoDBTable("Etf_Preco")]
public class Preco
{
    [DynamoDBHashKey]
    public string Id { get; set; }
    public string Ticker { get; set; }
    public Double PrecoFechamento { get; set; }
    public DateTime Data { get; set; }
}