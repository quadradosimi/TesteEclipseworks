using Eclipseworks.Service;
using Microsoft.AspNetCore.Mvc;

namespace Eclipseworks.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RelatoriosController : ControllerBase
{
    private readonly IRelatoriosService _relatoriosService;
    private readonly ILogger<RelatoriosController> _logger;
    public RelatoriosController(IRelatoriosService RelatoriosService, ILogger<RelatoriosController> logger)
    {
        _relatoriosService = RelatoriosService;
        _logger = logger;
    }

    [HttpGet]
    [Route("RelatorioTarefasConcluidasUltimoMesPorUsuario")]
    //número médio de tarefas concluídas por usuário nos últimos 30 dias
    public async Task<IActionResult> RelatorioTarefasConcluidasUltimoMesPorUsuario(int idUsuario)
    {
        var relatorio = await _relatoriosService.RelatorioTarefasConcluidasUltimoMesPorUsuario(idUsuario);

        if (relatorio != null)
        {
            return Ok(relatorio);
        }
        else
        {
            return BadRequest(new
            {
                message = "Uusuário sem permissão para ver relatórios."
            });
        }
    }

    [HttpGet]
    [Route("RelatorioMediaTarefasConcluidasUltimoMes")]
    //número médio de tarefas concluídas por usuário nos últimos 30 dias
    public async Task<IActionResult> RelatorioMediaTarefasConcluidasUltimoMes(int idUsuario)
    {
        var relatorio = await _relatoriosService.RelatorioMediaTarefasConcluidasUltimoMes(idUsuario);
        
        if (relatorio > 0)
        {
            return Ok(relatorio);
        }
        else
        {
            return BadRequest(new
            {
                message = "Uusuário sem permissão para ver relatórios."
            });
        }
    }
}
