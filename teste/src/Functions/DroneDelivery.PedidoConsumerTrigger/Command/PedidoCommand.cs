using DroneDelivery.PedidoConsumerTrigger.Config;
using DroneDelivery.PedidoConsumerTrigger.Contrato;
using DroneDelivery.PedidoConsumerTrigger.Model;
using DroneDelivery.Shared.Infra.Interfaces;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;


namespace DroneDelivery.PedidoConsumerTrigger.Command
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

        public async Task<bool> PedidoAsync(Shared.Domain.Core.Events.Pedidos.PedidoCriadoEvent @event)
        {
           var result = await _pedidoHttpFactory.EnviarPedidoParaEntrega(_appConfig.Login, _appConfig.Senha, @event);
            return result;
        }
    }

}
