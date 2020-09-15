using DroneDelivery.Shared.Domain.Core.Events.Pedidos;
using System.Threading.Tasks;

namespace DroneDelivery.Shared.Infra.Services
{
    public interface IPedPagamentoProducer
    {
        Task EnviarPagamento(PedidoAtualizadoEvent @event);
    }
}
