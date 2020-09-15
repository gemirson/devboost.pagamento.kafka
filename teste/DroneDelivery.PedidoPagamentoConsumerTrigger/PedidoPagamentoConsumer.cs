using DroneDelivery.PedidoPagamentoConsumerTrigger.Contrato;
using DroneDelivery.Shared.Domain.Core.Events.Pedidos;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Kafka;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace DroneDelivery.PedidoPagamentoConsumerTrigger
{
    public  class PedidoPagamentoConsumer
    {
            private readonly IPedidoCommand _pedidoCommand;

            public PedidoPagamentoConsumer(IPedidoCommand pedidoCommand)
            {
                _pedidoCommand = pedidoCommand;
            }

            [FunctionName(nameof(PedidoPagamentoConsumer))]
            public async Task PedidoPagamentoConsumerTrigger(
                [KafkaTrigger(
            "%BootstrapServers%",
            "%Topic%",
            ConsumerGroup = "%ConsumerGroup%")]
            KafkaEventData<string> kafkaEvent,
                ILogger logger)
            {
                logger.LogInformation(kafkaEvent.Value.ToString());

                var @event = JsonConvert.DeserializeObject<PedidoAtualizadoEvent>(kafkaEvent.Value);
                await _pedidoCommand.PedidoAsync(@event);
            }

        }
 }

