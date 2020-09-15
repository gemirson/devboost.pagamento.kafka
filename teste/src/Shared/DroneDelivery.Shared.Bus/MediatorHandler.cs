using DroneDelivery.Shared.Domain.Core.Bus;
using DroneDelivery.Shared.Domain.Core.Commands;
using DroneDelivery.Shared.Domain.Core.Domain;
using DroneDelivery.Shared.Domain.Core.Events;
using DroneDelivery.Shared.Domain.Core.Events.Pedidos;
using DroneDelivery.Shared.Domain.Core.Queries;
using DroneDelivery.Shared.Infra.Interfaces;
using DroneDelivery.Shared.Infra.Services;
using MediatR;
using System.Threading.Tasks;

namespace DroneDelivery.Shared.Bus
{
    public class MediatorHandler : IEventBus
    {

        private readonly IMediator _mediator;
        private readonly IPedPagamentoProducer _pedPagamentoProducer;


        public MediatorHandler( IMediator mediator, IPedPagamentoProducer pedPagamentoProducer)
        {
            _mediator = mediator;
            _pedPagamentoProducer = pedPagamentoProducer;
           
        }

        public Task<ResponseResult> SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }

        public Task<ResponseResult> RequestQuery<T>(T query) where T : Query
        {
            return _mediator.Send(query);
        }

        public async Task Publish<T>(T @event) where T : Event
        {
            await  _pedPagamentoProducer.EnviarPagamento(@event as PedidoAtualizadoEvent);
        }
    }
}
