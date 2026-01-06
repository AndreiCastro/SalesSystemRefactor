using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesSystem.WebApi.Queries.Produto.ObterListaProdutos;
using SalesSystem.WebApi.Queries.Produto.ObterProdutoPorId;

namespace SalesSystem.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutoController(ISender sender) : ControllerBase
{
    #region DELETE
    #endregion DELETE

    #region GET
    /// <sumarry>
    /// Metodo para Listar todos os produtos
    /// </sumarry>
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken = default)
    {
        Result<List<ObterListaProdutosResponse>> result = await sender.Send(new ObterListaProdutosQuery(), cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Errors[0].Message);
    }

    /// <sumarry>
    /// Metodo para Obter produto por id
    /// </sumarry>
    /// <param name="idProduto"></param>
    [HttpGet("{idProduto:int}")]
    public async Task<IActionResult> GetById(int idProduto, CancellationToken cancellationToken = default)
    {
        Result<ObterProdutoPorIdResponse> result = await sender.Send(new ObterProdutoPorIdQuery(idProduto), cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Errors[0].Message);
    }
    #endregion GET

    #region POST
    #endregion POST

    #region PUT
    #endregion PUT
}
