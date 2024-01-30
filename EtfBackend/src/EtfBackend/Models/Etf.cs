using Amazon.DynamoDBv2.DataModel;

namespace EtfBackend.Models;

[DynamoDBTable("CarteirasEtfs")]
public class Etf
{
    [DynamoDBHashKey]
    public string Ticker { get; set; }
    public string Tipo { get; set; }
    public List<Holding> Holdings { get; set; }
}