using System.Text;
using System.Text.Json;
using AgendamentoHoteis.Business.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var factory = new ConnectionFactory { HostName = "localhost", UserName = "guest", Password = "guest" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "agendamento",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

Console.WriteLine(" [*] Waiting for messages.");

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);

    Agendamento agendamento = JsonSerializer.Deserialize<Agendamento>(message);

    Console.WriteLine($"Data: {agendamento.DataAgendamento}; Usuario: {agendamento.IdUsuario};");

};
channel.BasicConsume(queue: "agendamento",
                     autoAck: true,
                     consumer: consumer);

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();