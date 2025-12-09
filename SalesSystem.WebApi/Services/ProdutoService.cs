using FluentResults;
using SalesSystem.WebApi.Dtos;
using SalesSystem.WebApi.Repositories;

namespace SalesSystem.WebApi.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;            
    }

    public async Task<Result<ProdutoDto>> ObterProdutoPorIdAsync(int idProduto, CancellationToken cancellationToken)
    {
        var output = await _produtoRepository.GetProdutoForIdAsync(idProduto, cancellationToken);
        return output;
    }

    public async Task<Result<List<ProdutoDto>>> ObterTodosProdutosAsync(CancellationToken cancellationToken)
    {
        var output = await _produtoRepository.GetAllProdutosAsync(cancellationToken);
        return output;
    }
}
