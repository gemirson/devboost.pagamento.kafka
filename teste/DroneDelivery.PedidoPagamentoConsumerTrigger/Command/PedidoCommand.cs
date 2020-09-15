using DroneDelivery.PedidoPagamentoConsumerTrigger.Config;
using DroneDelivery.PedidoPagamentoConsumerTrigger.Contrato;
using DroneDelivery.Shared.Domain.Core.Events.Pedidos;
using DroneDelivery.Shared.Infra.Interfaces;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;


namespace DroneDelivery.PedidoPagamentoConsumerTrigger.Command
{
    public class PedidoCommand : IPedidoCommand
    {
        private readonly IPedidoHttpFactory   _pedidoHttpFactory;
        private readonly AppConfig            _appConfig;

        public PedidoCommand(IOptions<AppConfig> options, IPedidoHttpFactory pedidoHttpFactory)
        {          
            _appConfig = options.Value;
            _pedidoHttpFactory = pedidoHttpFactory;
        }

        public async Task<bool> PedidoAsync(PedidoAtualizadoEvent @event)
        {
            var result = await _pedidoHttpFactory.AtualizarPedidoStatus(_appConfig.Login, _appConfig.Senha, @event);
            return result;
        }
    }

}
