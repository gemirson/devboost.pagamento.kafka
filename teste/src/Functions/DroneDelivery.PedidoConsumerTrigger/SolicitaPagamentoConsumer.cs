using DroneDelivery.PedidoConsumerTrigger.Contrato;
using DroneDelivery.Shared.Domain.Core.Events.Pedidos;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Kafka;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace DroneDelivery.PedidoConsumerTrigger
{
    public class SolicitaPagamentoConsumer
    {
        private readonly IPagamentoCommand _pedidoCommand;

        public SolicitaPagamentoConsumer(IPagamentoCommand pedidoCommand)
        {
            _pedidoCommand = pedidoCommand;
        }

        [FunctionName(nameof(SolicitaPagamentoConsumer))]
        public async Task PedidoConsumerTrigger(
            [KafkaTrigger(
            "%BootstrapServers%",
            "%Topic%",
            ConsumerGroup = "%ConsumerGroupPagamento%")]
            KafkaEventData<string> kafkaEvent,
            ILogger logger)
        {
            logger.LogInformation(kafkaEvent.Value.ToString());

            var @event = JsonConvert.DeserializeObject<PedidoCriadoEvent>(kafkaEvent.Value);

            await _pedidoCommand.PedidoAsync(@event);
        }

    }
}
