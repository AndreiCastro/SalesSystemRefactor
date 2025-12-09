using Dapper;
using Microsoft.Data.SqlClient;
using SalesSystem.WebApi.Dtos;

namespace SalesSystem.WebApi.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly string _connection;

    public ProdutoRepository(IConfiguration configuration)
    {
        _connection = configuration.GetConnectionString("connect");
    }

    public async Task<List<ProdutoDto>> GetAllProdutosAsync(CancellationToken cancellationToken)
    {
        var listProducts = new List<ProdutoDto>();
        var query = @"SELECT
                            Id
                            , Nome
                            , Descricao
                            , Preco
                            , UnidadeMedida
                            , Quantidade
                            , Peso
                            , DataValidade
                        FROM
                            Produtos WITH(NOLOCK)";

        using(var con = new SqlConnection(_connection))
        {
            try
            {
                await con.OpenAsync();
                var produtos = await con.QueryAsync(query);

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
            finally 
            { 
                await con.CloseAsync(); 
            }
        }
    }

    public async Task<ProdutoDto> GetProdutoForIdAsync(int idProduto, CancellationToken cancellationToken)
    {
        var query = @"SELECT
                        Id
                        , Nome
                        , Descricao
                        , Preco
                        , UnidadeMedida
                        , Quantidade
                        , Peso
                        , DataValidade
                    FROM
                        Produtos WITH(NOLOCK)
                    WHERE
                        Id = @id";

        using (var con = new SqlConnection(_connection))
        {
            try
            {
                await con.OpenAsync();
                var produto = await con.QueryFirstOrDefaultAsync<ProdutoDto>(query, new { id = idProduto});

                if (produto is null)
                    return null;

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
            catch (Exception)
            {
                throw;
            }
            finally
            {
                await con.CloseAsync();
            }
        }
    }
}
