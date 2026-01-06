using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SalesSystem.WebApi.Queries.Venda.ObterListaVendas;
using SalesSystem.WebApi.Queries.Venda.ObterVendaPorId;
using SalesSystem.WebApi.Repositories;

namespace SalesSystem.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VendaController(ISender sender) : ControllerBase
{
    #region DELETE


    #endregion DELETE

    #region GET
    /// <summary>
    /// Método para retornar vendas
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken = default)
    {
        Result<List<ObterListaVendasResponse>> result = await sender.Send(new ObterListaVendasQuery(), cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Errors[0].Message);
    }

    /// <sumarry>
    /// Metodo para Obter venda por id
    /// </sumarry>
    /// <param name="idVenda"></param>
    [HttpGet("{idVenda:int}")]
    public async Task<IActionResult> GetById(int idVenda, CancellationToken cancellationToken = default)
    {
        Result<ObterVendaPorIdResponse> result = await sender.Send(new ObterVendaPorIdQuery(idVenda), cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Errors[0].Message);
    }
    #endregion GET

    #region POST

    #endregion POST

    #region PUT

    #endregion PUT
}
