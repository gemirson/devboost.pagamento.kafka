
using DroneDelivery.Shared.Domain.Core.Events.Pedidos;
using System.Threading.Tasks;

namespace DroneDelivery.PedidoPagamentoConsumerTrigger.Contrato
{
    public interface IPedidoCommand
    {
        Task<bool> PedidoAsync(PedidoAtualizadoEvent @event);
    }
}
