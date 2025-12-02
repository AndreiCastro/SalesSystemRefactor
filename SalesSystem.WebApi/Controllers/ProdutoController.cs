using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesSystem.WebApi.Queries.ObterListaProdutos;

namespace SalesSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController(ISender sender) : ControllerBase
    {
        #region Delete
        #endregion Delete

        #region Get
        /// <sumarry>
        /// Metodo para Listar todos os produtos
        /// </sumarry>
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken = default)
        {
            Result<List<ObterListaProdutosResponse>> result = await sender.Send(new ObterListaProdutosQuery(), cancellationToken);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Errors[0].Message);
        }
        #endregion Get

        #region Post
        #endregion Post

        #region Put
        #endregion Put
    }
}
