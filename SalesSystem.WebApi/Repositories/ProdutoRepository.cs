using Dapper;
using Microsoft.Data.SqlClient;
using SalesSystem.Mvc.Models;

namespace SalesSystem.WebApi.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly string _connection;

    public ProdutoRepository(IConfiguration configuration)
    {
        _connection = configuration.GetConnectionString("connect");
    }

    public async Task<List<ProdutoModel>> GetAllProdutosAsync(CancellationToken cancellationToken)
    {
        var listProducts = new List<ProdutoModel>();
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
                var ListProdutos = (await con.QueryAsync<ProdutoModel>(query)).ToList();

                if (ListProdutos is null)
                    return null;

                return ListProdutos;
                
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

    public async Task<ProdutoModel> GetProdutoByIdAsync(int idProduto, CancellationToken cancellationToken)
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
                var produto = await con.QueryFirstOrDefaultAsync<ProdutoModel>(query, new { id = idProduto});

                if (produto is null)
                    return null;

                return produto;
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
