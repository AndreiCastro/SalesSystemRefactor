using FluentResults;
using SalesSystem.WebApi.Dtos;

namespace SalesSystem.WebApi.Services;

public interface IProdutoService
{
    Task<Result<List<ProdutoDto>>> ObterTodosProdutosAsync(CancellationToken cancellationToken);

    Task<Result<ProdutoDto>> ObterProdutoPorIdAsync(int idProduto, CancellationToken cancellationToken);
}
