using Eclipseworks.Model;
using Eclipseworks.Service;
using Microsoft.AspNetCore.Mvc;

namespace Eclipseworks.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjetosController : ControllerBase
{
    private readonly IProjetosService _projetosService;
    private readonly ILogger<ProjetosController> _logger;
    public ProjetosController(IProjetosService ProjetosService, ILogger<ProjetosController> logger)
    {
        _projetosService = ProjetosService;
        _logger = logger;
    }

    //Listagem de Projetos
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var Projetoss = await _projetosService.GetAllProjetos();
        return Ok(Projetoss);
    }

    //Criação de Projetos
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Projeto projetoObject)
    {
        var Projetos = await _projetosService.AddProjeto(projetoObject);

        if (Projetos == null)
        {
            return BadRequest();
        }

        return Ok(new
        {
            message = "Projeto criado com sucesso!!!",
            id = Projetos!.Id
        });
    }

    //Remoção de Projetos
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var result = await _projetosService.DeleteProjetoByID(id);

        if (result == 0)
        {
            return NotFound();
        }
        else if (result == -1)
        {
            return BadRequest(new
            {
                message = "Projeto ainda possue tarefas ativas. Exclua essas tarefas primeiro, para depois excluir o projeto."
            });
        }
        else
        { 
            return Ok(new
            {
                message = "Tarefa deletada com sucesso!!!",
                id = id
            });
        }
    }

}
