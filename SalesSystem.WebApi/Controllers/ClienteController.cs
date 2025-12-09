using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesSystem.WebApi.Queries.ObterClientePorId;
using SalesSystem.WebApi.Queries.ObterListaClientes;

namespace SalesSystem.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClienteController(ISender sender) : ControllerBase
{
    #region Delete

    #endregion Delete

    #region Get
    /// <summary>
    /// Método para retornar todos os clientes
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken = default)
    {
        Result<List<ObterListaClientesResponse>> result = await sender.Send(new ObterListaClientesQuery(), cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Errors[0].Message);
    }

    /// <summary>
    /// Método para retornar um cliente
    /// </summary>
    /// <param name="idCliente"></param>
    [HttpGet("{idCliente:int}")]
    public async Task<IActionResult> GetById(int idCliente, CancellationToken cancellationToken = default)
    {
        Result<ObterClientePorIdResponse> result = await sender.Send(new ObterClientePorIdQuery(idCliente), cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Errors[0].Message);
    }
    #endregion Get

    #region Put

    #endregion Put

    #region Post
    /// <summary>
    /// Método para cadastrar um cliente
    /// </summary>
    //[HttpPost]
    //public async Task<IActionResult> Post(ClienteDto clienteDto)
    //{
    //    Result<>
    //}
    #endregion Post        
}
