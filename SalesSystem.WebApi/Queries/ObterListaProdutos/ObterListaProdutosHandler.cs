using FluentResults;
using MediatR;
using SalesSystem.WebApi.Services;

namespace SalesSystem.WebApi.Queries.ObterListaProdutos;

public sealed class ObterListaProdutosHandler : IRequestHandler<ObterListaProdutosQuery, Result<List<ObterListaProdutosResponse>>>
{
    private readonly IProdutoService _produtoService;

    public ObterListaProdutosHandler(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    public async Task<Result<List<ObterListaProdutosResponse>>> Handle(ObterListaProdutosQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var listProducts = new List<ObterListaProdutosResponse>();
            var result = await _produtoService.ObterTodosProdutosAsync(cancellationToken);

            if (result.Value.Count <= 0)
                return Result.Fail("Nenhum produto encontrado");

            foreach (var item in result.Value)
            {
                listProducts.Add(
                    new ObterListaProdutosResponse(
                        item.Id,
                        item.Nome,
                        item.Descricao,
                        item.Preco,
                        item.UnidadeMedida,
                        item.Quantidade,
                        item.Peso,
                        item.DataValidade));
            }
            return listProducts;
        }
        catch (Exception ex)
        {
            return Result.Fail($"Error: {ex.Message}");
        }        
    }
}
