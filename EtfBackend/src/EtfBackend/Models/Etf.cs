using Amazon.DynamoDBv2.DataModel;

namespace EtfBackend.Models;

[DynamoDBTable("EtfCarteiras")]
public class Etf
{
    [DynamoDBHashKey]
    public string Ticker { get; set; }
    public string Type { get; set; }
    public string UpdatedAt { get; set; }
    public List<Holding> Holdings { get; set; }
}