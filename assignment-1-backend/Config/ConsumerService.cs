using assignment_1_backend.Config.Models;
using assignment_1_backend.Models;
using assignment_1_backend.Models.DTOs;
using assignment_1_backend.Repositories;
using assignment_1_backend.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace assignment_1_backend.Config
{
    public class ConsumerService : BackgroundService
    {
        private IServiceProvider sp;
        private ConnectionFactory factory;
        private IConnection connection;
        private IModel channel;
        private readonly IHubContext<MeasurementHub> hub;
     

        public ConsumerService(IServiceProvider sp,
                                IHubContext<MeasurementHub> hub)
        {
            this.hub = hub;
            this.sp = sp;
  
            factory =  new ConnectionFactory
            {
                Uri = new Uri("amqps://rnjlwzmf:BG54g2oGW3oLhkVdpfoGDL-D9EAT2YYD@cow.rmq2.cloudamqp.com/rnjlwzmf"),
                Password = "BG54g2oGW3oLhkVdpfoGDL-D9EAT2YYD",
                UserName = "rnjlwzmf",
                VirtualHost = "rnjlwzmf",
            };

            this.connection = factory.CreateConnection();
            this.channel = connection.CreateModel();

            this.channel.QueueDeclare("measurements",
                                    durable: true,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
           
            if (stoppingToken.IsCancellationRequested)
            {
                channel.Dispose();
                connection.Dispose();
                return Task.CompletedTask;
            }

           
            var consumer = new EventingBasicConsumer(channel);

            
            consumer.Received += (model, ea) =>
            {
               
                var body =ea.Body;

                
                var message = JsonConvert.DeserializeObject<MeasurementMessage>(Encoding.UTF8.GetString(body.ToArray()));
              

                Task.Run(async () =>
                {



                    var measurement = new Measurment
                    {
                        ID = Guid.NewGuid(),
                        DeviceID = message.SensorID,
                        KWH = (double)message.Value,
                        TimeStamp = DateTimeOffset.FromUnixTimeSeconds(message.TimeStamp)
                    };

                    using(var scope = sp.CreateScope())
                    {
                        var context = scope.ServiceProvider.GetRequiredService<Context>();
                        var device = context.Devices.FirstOrDefault(d => d.ID == measurement.DeviceID);
                        var userName = context.Users.FirstOrDefault(u => u.Id == device.UserID)?.UserName;
                        if(measurement.KWH <= device.MAximumValue)
                        {
                            context.Measurments.Add(measurement);
                            context.SaveChanges();
                        }
                        else
                        {
                           
                            var notification = new NotificationDTO
                            {
                                UserName = userName,
                                Message = "Maximum value excedeed, please contact us!"
                            };
                            await hub.Clients.All.SendAsync("maximumValueExcedeed", notification);
                        }
                    }
                    
                });
            };

            channel.BasicConsume(queue: "measurements", autoAck: true, consumer: consumer);

            return Task.CompletedTask;
        }


    }
}

    