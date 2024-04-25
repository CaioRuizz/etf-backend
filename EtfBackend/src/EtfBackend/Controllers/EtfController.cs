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

    private async Task<List<Etf>?> ListarEtfs()
    {
        List<ScanCondition> conditions = new();

        var result = await _context.ScanAsync<Etf>(conditions).GetRemainingAsync();

        return result;
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
        var result = await ListarEtfs();

        if (result is null)
        {
            return NotFound();
        }

        var response = result.Select(r => new
        {
            r.Ticker,
            r.Type,
        }).ToList();
        
        return Ok(response);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetEtfs()
    {
        var result = await ListarEtfs();

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