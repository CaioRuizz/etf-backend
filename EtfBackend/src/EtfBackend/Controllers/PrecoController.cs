using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using EtfBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace EtfBackend.Controllers;

[Route("api/v1/[controller]")]
public class PrecoController : ControllerBase
{
    private ILogger<PrecoController> _logger;
    private DynamoDBContext _context;
    
    public PrecoController(ILogger<PrecoController> logger, IAmazonDynamoDB dynamoDb)
    {
        _logger = logger;
        _context = new(dynamoDb);
    }
}