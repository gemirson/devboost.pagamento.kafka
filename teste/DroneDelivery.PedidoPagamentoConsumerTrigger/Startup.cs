﻿using DroneDelivery.PedidoPagamentoConsumerTrigger.Command;
using DroneDelivery.PedidoPagamentoConsumerTrigger.Config;
using DroneDelivery.PedidoPagamentoConsumerTrigger.Contrato;
using DroneDelivery.Shared.Infra.Clients;
using DroneDelivery.Shared.Infra.HttpFactories;
using DroneDelivery.Shared.Infra.Interfaces;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: FunctionsStartup(typeof(DroneDelivery.PedidoConsumerTrigger.Startup))]
namespace DroneDelivery.PedidoConsumerTrigger
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddOptions<AppConfig>()
                .Configure<IConfiguration>((s, c) =>
                {
                    c.GetSection("App").Bind(s);
                });

            HttpPedidoClient.Registrar(builder.Services, Environment.GetEnvironmentVariable("UrlBaseEntrega"));
            builder.Services.AddScoped<IPedidoCommand, PedidoCommand>();
            builder.Services.AddSingleton<IPedidoHttpFactory, PedidoHttpFactory>();

        }
    }
}
