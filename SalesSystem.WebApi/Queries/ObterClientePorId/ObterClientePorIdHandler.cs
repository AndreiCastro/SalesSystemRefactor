using FluentResults;
using MediatR;
using SalesSystem.WebApi.Services;

namespace SalesSystem.WebApi.Queries.ObterClientePorId;

public sealed class ObterClientePorIdHandler : IRequestHandler<ObterClientePorIdQuery, Result<ObterClientePorIdResponse>>
{
    private readonly IClienteService _clienteServices;

    public ObterClientePorIdHandler(IClienteService clienteService)
    {
        _clienteServices = clienteService;
    }

    public async Task<Result<ObterClientePorIdResponse>> Handle(ObterClientePorIdQuery resquest, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _clienteServices.ObterClientePorIdAsync(resquest.Id, cancellationToken);
            if(result.Value is null)            
                return Result.Fail("Nenhum cliente encontrado.");

            var cliente = new ObterClientePorIdResponse
            (
                result.Value.Id,
                result.Value.Nome,
                result.Value.Email,
                result.Value.CpfCnpj,
                result.Value.Logradouro,
                result.Value.Bairro,
                result.Value.Uf,
                result.Value.Cep,
                result.Value.Cidade,
                result.Value.Telefone
            );

            return Result.Ok(cliente);            
        }
        catch (Exception ex)
        {
            return Result.Fail($"Erro: {ex.Message}");
        }
    }

}
