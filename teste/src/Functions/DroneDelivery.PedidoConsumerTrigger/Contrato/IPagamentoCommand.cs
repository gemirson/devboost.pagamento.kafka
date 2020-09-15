
using DroneDelivery.Shared.Domain.Core.Events.Pedidos;
using System.Threading.Tasks;

namespace DroneDelivery.PedidoConsumerTrigger.Contrato
{
    public interface IPagamentoCommand
    {
        Task<bool> PedidoAsync( PedidoCriadoEvent @event);
    }
}
