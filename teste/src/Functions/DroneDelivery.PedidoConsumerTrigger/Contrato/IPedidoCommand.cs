
using DroneDelivery.Shared.Domain.Core.Events.Pedidos;
using System.Threading.Tasks;

namespace DroneDelivery.PedidoConsumerTrigger.Contrato
{
    public interface IPedidoCommand
    {
        Task<bool> PedidoAsync( PedidoCriadoEvent @event);
    }
}
