using DroneDelivery.PedidoConsumerTrigger.Config;
using DroneDelivery.PedidoConsumerTrigger.Contrato;
using DroneDelivery.PedidoConsumerTrigger.Model;
using DroneDelivery.Shared.Infra.Interfaces;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;


namespace DroneDelivery.PedidoConsumerTrigger.Command
{
    public class PagamentoCommand : IPagamentoCommand
    {
        private readonly IPagamentoHttpFactory  _pagamentoHttpFactory;
       
        public PagamentoCommand(IPagamentoHttpFactory pagamentoHttpFactory)
        {          
             _pagamentoHttpFactory = pagamentoHttpFactory;
        }

        public async Task<bool> PedidoAsync(Shared.Domain.Core.Events.Pedidos.PedidoCriadoEvent @event)
        {
            var result = await _pagamentoHttpFactory.EnviarPedidoParaPagamento(@event);
            return result;
        }
    }

}
