using Dapper;
using Microsoft.Data.SqlClient;
using SalesSystem.Mvc.Models;

namespace SalesSystem.WebApi.Repositories;

public class VendaRepository : IVendaRepository
{
    private readonly string _connection;

    public VendaRepository(IConfiguration configuration)
    {
        _connection = configuration.GetConnectionString("connect");
    }

    public async Task<List<VendaModel>> GetAllVendasAsync(CancellationToken cancellationToken)
    {
        var listVendas = new List<VendaModel>();
        var query = @"SELECT
                            Id
                            , DataVenda
                            , QuantidadeProduto
                            , ValorTotal
                            , Descricao
                            , Desconto
                        FROM
                            Vendas WITH(NOLOCK)";

        using(var con = new SqlConnection(_connection))
        {
            try
            {
                await con.OpenAsync();
                var ListVendas = (await con.QueryAsync<VendaModel>(query)).ToList();

                if (ListVendas is null)
                    return null;

                return ListVendas;
                
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

    public async Task<VendaModel> GetVendaByIdAsync(int idVenda, CancellationToken cancellationToken)
    {
        var query = @"SELECT
                        Id
                        , DataVenda
                        , QuantidadeProduto
                        , ValorTotal
                        , Descricao
                        , Desconto
                        , IdCliente
                        , IdProduto
                    FROM
                        Vendas WITH(NOLOCK)
                    WHERE
                        Id = @id";

        using (var con = new SqlConnection(_connection))
        {
            try
            {
                await con.OpenAsync();
                var venda = await con.QueryFirstOrDefaultAsync<VendaModel>(query, new { id = idVenda });

                if (venda is null)
                    return null;

                return venda;
                 
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
