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
}
