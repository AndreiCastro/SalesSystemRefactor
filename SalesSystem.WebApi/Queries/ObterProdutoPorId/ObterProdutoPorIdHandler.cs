using FluentResults;
using MediatR;
using SalesSystem.WebApi.Services;

namespace SalesSystem.WebApi.Queries.ObterProdutoPorId;

public sealed class ObterProdutoPorIdHandler : IRequestHandler<ObterProdutoPorIdQuery, Result<ObterProdutoPorIdResponse>>
{
    private readonly IProdutoService _produtoService;

    public ObterProdutoPorIdHandler(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    public async Task<Result<ObterProdutoPorIdResponse>> Handle(ObterProdutoPorIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _produtoService.ObterProdutoPorIdAsync(request.Id, cancellationToken);
            if (result.Value is null)
                return Result.Fail("Nenhum produto encontrado");

            var produto = new ObterProdutoPorIdResponse
            (
                result.Value.Id,
                result.Value.Nome,
                result.Value.Descricao,
                result.Value.Preco, 
                result.Value.Quantidade,
                result.Value.UnidadeMedida,
                result.Value.Peso,
                result.Value.DataValidade
            );

            return Result.Ok(produto);

        }
        catch (Exception ex)
        {
            return Result.Fail($"Erro: {ex.Message}");
        }
    }
}
