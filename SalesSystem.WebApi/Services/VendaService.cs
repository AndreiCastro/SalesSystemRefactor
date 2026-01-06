using FluentResults;
using SalesSystem.WebApi.Dtos;
using SalesSystem.WebApi.Repositories;

namespace SalesSystem.WebApi.Services;

public class VendaService : IVendaService
{
    private readonly IVendaRepository _repository;

    public VendaService(IVendaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<List<VendaDto>>> ObterTodasVendasAsync(CancellationToken cancellationToken)
    {
        try
        {
            var vendas = await _repository.GetAllVendasAsync(cancellationToken);
            var listVendas = new List<VendaDto>();
            foreach (var item in vendas)
            {
                listVendas.Add(
                    new VendaDto()
                    {
                        Id = item.Id,
                        DataVenda = item.DataVenda,
                        QuantidadeProduto = item.QuantidadeProduto,
                        ValorTotal = item.ValorTotal,
                        Desconto = item.Desconto,
                        Descricao = item.Descricao
                    }
                );
            }

            return listVendas;
        }
        catch (Exception)
        {
            throw;
        }        
    }

    public async Task<Result<VendaDto>> ObterVendaPorId(int idVenda, CancellationToken cancellationToken)
    {
        var venda = await _repository.GetVendaByIdAsync(idVenda, cancellationToken);
        return new VendaDto()
        {
            Id = venda.Id,
            DataVenda = venda.DataVenda,
            QuantidadeProduto = venda.QuantidadeProduto,
            ValorTotal = venda.ValorTotal,
            Desconto = venda.Desconto,
            Descricao = venda.Descricao
        };
    }
}
