using SalesSystem.Mvc.Models;

namespace SalesSystem.WebApi.Repositories;

public interface IProdutoRepository
{
    Task<List<ProdutoModel>> GetAllProdutosAsync(CancellationToken cancellationToken);

    Task<ProdutoModel> GetProdutoByIdAsync(int idProduto, CancellationToken cancellationToken);
}
