using DroneDelivery.Shared.Domain.Core.Events.Pedidos;
using DroneDelivery.Shared.Infra.Interfaces;
using System.Threading.Tasks;

namespace DroneDelivery.Pagamento.Api.Tests.MockHttpFacotry
{
    public class MockPedidoHttpFactory : IPedidoHttpFactory
    {
        public Task<bool> AtualizarPedidoStatus(PedidoAtualizadoEvent @event)
        {
            return Task.FromResult(true);
        }

        public Task<bool> AtualizarPedidoStatus(string email, string password, PedidoAtualizadoEvent @event)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> EnviarPedidoParaEntrega(string email, string password, PedidoCriadoEvent @event)
        {
            throw new System.NotImplementedException();
        }
    }
}
