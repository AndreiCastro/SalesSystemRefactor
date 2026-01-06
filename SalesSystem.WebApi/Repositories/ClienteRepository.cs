using Dapper;
using Microsoft.Data.SqlClient;
using SalesSystem.Mvc.Models;

namespace SalesSystem.WebApi.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly string _connection;

    public ClienteRepository(IConfiguration configuration)
    {
        _connection = configuration.GetConnectionString("connect");
    }

    public async Task<List<ClienteModel>> GetAllClientesAsync(CancellationToken cancellationToken)
    {
        const string sql = @"
            SELECT 
                Id As Id
                , Nome As Nome
                , Email As Email
                , CpfCnpj As CpfCnpj
                , Logradouro As Logradouro
                , Bairro As Bairro
                , Uf As Uf
                , Cep As Cep
                , Cidade As Cidade
                , Telefone As Telefone
            FROM 
                Clientes WITH(NOLOCK) 
            ORDER BY 
                Nome;";

        using (var con = new SqlConnection(_connection))
        {
            try
            {
                await con.OpenAsync();
                var listClientes = (await con.QueryAsync<ClienteModel>(sql)).ToList();

                if (listClientes is null)
                    return null;

                return listClientes;                
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

    public async Task<ClienteModel> GetClientForIdAsync(int idCliente, CancellationToken cancellationToken)
    {
        const string sql = @"SELECT
                                Id As Id
                                , Nome As Nome
                                , Email As Email
                                , CpfCnpj As CpfCnpj
                                , Logradouro As Logradouro
                                , Bairro As Bairro
                                , Uf As Uf
                                , Cep As Cep
                                , Cidade As Cidade
                                , Telefone As Telefone
                            FROM 
                                Clientes WITH(NOLOCK) 
                            WHERE
                                Id = @id;";

        using (var con = new SqlConnection(_connection))
        {
            try
            {
                await con.OpenAsync();
                var cliente = await con.QueryFirstOrDefaultAsync<ClienteModel>(sql, new { id = idCliente});

                if (cliente is null)
                    return null;

                return cliente;
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
