using Eclipseworks.Model;
using Eclipseworks.Service;
using Microsoft.AspNetCore.Mvc;

namespace Eclipseworks.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TarefasController : ControllerBase
{
    private readonly ITarefasService _tarefasService;
    private readonly ILogger<TarefasController> _logger;
    public TarefasController(ITarefasService TarefasService, ILogger<TarefasController> logger)
    {
        _tarefasService = TarefasService;
        _logger = logger;
    }

    //Visualiza��o de Tarefas
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var Tarefass = await _tarefasService.GetAllTarefas();
        return Ok(Tarefass);
    }

    //Cria��o de Tarefas
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Tarefa TarefaObject)
    {
        var result = await _tarefasService.AddTarefa(TarefaObject);

        if (result == -1)
        {
            return BadRequest(new
            {
                message = "O projeto n�o pode ter mais de 20 tarefas.",
                id = TarefaObject.IdProjeto
            });
        }
        else
        {
            return Ok(new
            {
                message = "Tarefa inclu�da com sucesso!!!",
                id = result
            });
        }
    }

    //Atualiza��o de Tarefas
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Tarefa tarefasObject)
    {
        var tarefa = await _tarefasService.UpdateTarefa(id, tarefasObject);

        if (tarefa == null)
        {
            return NotFound();
        }

        return Ok(new
        {
            message = "Tarefa modificada com sucesso!!!",
            id = tarefa!.Id
        });
    }

    //Remo��o de Tarefas
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        if (!await _tarefasService.DeleteTarefaByID(id))
        {
            return NotFound();
        }

        return Ok(new
        {
            message = "Tarefa deletada com sucesso!!!",
            id = id
        });
    }
}
