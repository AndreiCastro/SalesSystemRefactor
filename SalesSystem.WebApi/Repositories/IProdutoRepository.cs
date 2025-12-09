using SalesSystem.WebApi.Dtos;

namespace SalesSystem.WebApi.Repositories;

public interface IProdutoRepository
{
    Task<List<ProdutoDto>> GetAllProdutosAsync(CancellationToken cancellationToken);

    Task<ProdutoDto> GetProdutoForIdAsync(int idProduto, CancellationToken cancellationToken);
}
