using Microsoft.Data.SqlClient;
using SalesSystem.WebApi.Dtos;
using Dapper;

namespace SalesSystem.WebApi.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly string _connection;

    public ClienteRepository(IConfiguration configuration)
    {
        _connection = configuration.GetConnectionString("connect");
    }

    public async Task<List<ClienteDto>> GetAllClientesAsync(CancellationToken cancellationToken)
    {
        var clientList = new List<ClienteDto>();
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
                var clientes = await con.QueryAsync<ClienteDto>(sql);

                foreach (var item in clientes)
                {
                    clientList.Add(
                        new ClienteDto()
                        {
                            Id = item.Id,
                            Nome = item.Nome,
                            Email = item.Email,
                            CpfCnpj = item.CpfCnpj,
                            Logradouro = item.Logradouro,
                            Bairro = item.Bairro,
                            Uf = item.Uf,
                            Cep = item.Cep,
                            Cidade = item.Cidade,
                            Telefone = item.Telefone                         
                        });
                }
                return clientList;
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

    public async Task<ClienteDto> GetClientForIdAsync(int idCliente, CancellationToken cancellationToken)
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
                var cliente = await con.QueryFirstOrDefaultAsync<ClienteDto>(sql, new { id = idCliente});

                if (cliente is null)
                    return null;

                return new ClienteDto()
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    Email = cliente.Email,
                    CpfCnpj = cliente.CpfCnpj,
                    Logradouro = cliente.Logradouro,
                    Bairro = cliente.Bairro,
                    Uf = cliente.Uf,
                    Cep = cliente.Cep,
                    Cidade = cliente.Cidade,
                    Telefone = cliente.Telefone
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
