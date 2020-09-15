using System;

namespace DroneDelivery.Shared.Domain.Core.Events.Pedidos
{
    public class PedidoCriadoEvent : Event
    {
        public Guid Id { get; private set; }

        public double Peso { get; set; }

        public double Valor { get; private set; }

        public PedidoCriadoEvent(Guid id, double peso, double valor)
        {
            Id = id;
            Peso = peso;
            Valor = valor;
        }
    }
}
