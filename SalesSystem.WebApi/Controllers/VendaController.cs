using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SalesSystem.WebApi.Repositories;

namespace SalesSystem.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VendaController : ControllerBase
{
    private readonly IVendaRepository _repository;
    private readonly IProdutoRepository _produtoRepository;

    public VendaController(IVendaRepository repository, IProdutoRepository produtoRepository)
    {
        _repository = repository;
        _produtoRepository = produtoRepository;
    }
    #region DELETE


    #endregion DELETE

    #region GET
    /// <summary>
    /// Método para retornar todas as vendas
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken = default)
    {
        //Result<List<ObterListaVendaResponse>> result = await sender.Send(new ObterListaVendaQuery(), cancellationToken);
        //return result.IsSuccess ? Ok(result) : BadRequest(result.Errors[0].Message);
        return Ok();
    }
    #endregion GET

    #region POST

    #endregion POST

    #region PUT

    #endregion PUT
}
