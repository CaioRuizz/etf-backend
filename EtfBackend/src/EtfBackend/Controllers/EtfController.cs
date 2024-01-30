using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using EtfBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace EtfBackend.Controllers;

[Route("api/v1/[controller]")]
public class EtfController : ControllerBase
{
    private ILogger<EtfController> _logger;
    private DynamoDBContext _context;
    
    public EtfController(ILogger<EtfController> logger, IAmazonDynamoDB dynamoDb)
    {
        _logger = logger;
        _context = new(dynamoDb);
        
    }
    
    [HttpPost]
    public async Task<IActionResult> AdicionarIndice([FromBody] Etf etf)
    {
        await _context.SaveAsync(etf);
        
        return Ok(etf);
    }

    [HttpGet("tickers")]
    public async Task<IActionResult> ListarTickers()
    {
        List<ScanCondition> conditions = new();

        var result = await _context.ScanAsync<Etf>(conditions).GetRemainingAsync();

        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{ticker}")]
    public async Task<IActionResult> BuscarDadosEtf([FromRoute] string ticker)
    {
        var result = await _context.LoadAsync<Etf>(ticker);

        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }
}