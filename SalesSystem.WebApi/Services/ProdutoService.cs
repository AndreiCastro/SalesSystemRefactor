using FluentResults;
using SalesSystem.Mvc.Models;
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
        try
        {
            var produto = await _produtoRepository.GetProdutoByIdAsync(idProduto, cancellationToken);
            if(produto is not null)
            {
                return new ProdutoDto()
                {
                    Id = produto!.Id,
                    Nome = produto.Nome,
                    Descricao = produto.Descricao,
                    Preco = produto.Preco,
                    UnidadeMedida = produto.UnidadeMedida,
                    Quantidade = produto.Quantidade,
                    Peso = produto.Peso,
                    DataValidade = produto.DataValidade
                };
            }
            else
            {
                return null;
            }
            
        }
        catch (Exception)
        {
            throw;
        }        
    }

    public async Task<Result<List<ProdutoDto>>> ObterTodosProdutosAsync(CancellationToken cancellationToken)
    {
        try
        {
            var produtos = await _produtoRepository.GetAllProdutosAsync(cancellationToken);
            var listProducts = new List<ProdutoDto>();
            foreach (var item in produtos)
            {
                listProducts.Add(
                    new ProdutoDto()
                    {
                        Id = item.Id,
                        Nome = item.Nome,
                        Descricao = item.Descricao,
                        Preco = item.Preco,
                        UnidadeMedida = item.UnidadeMedida,
                        Peso = item.Peso,
                        DataValidade = item.DataValidade
                    }
                );
            }

            return listProducts;
        }
        catch (Exception)
        {
            throw;
        }        
    }
}
