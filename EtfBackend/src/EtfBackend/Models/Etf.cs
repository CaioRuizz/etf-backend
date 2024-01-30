using Amazon.DynamoDBv2.DataModel;

namespace EtfBackend.Models;

[DynamoDBTable("CarteirasEtfs")]
public class Etf
{
    [DynamoDBHashKey]
    public string Ticker { get; set; }
    [DynamoDBRangeKey]
    public string Type { get; set; }
    public string UpdatedAt { get; set; }
    public List<Holding> Holdings { get; set; }
}