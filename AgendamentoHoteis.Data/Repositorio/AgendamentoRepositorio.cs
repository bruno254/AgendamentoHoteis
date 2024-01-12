using AgendamentoHoteis.Business.Interfaces;
using AgendamentoHoteis.Business.Models;
using AgendamentoHoteis.Data.Context;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace AgendamentoHoteis.Data.Repositorio
{
    public class AgendamentoRepositorio : RepositorioBase<Agendamento>, IAgendamentoRepositorio
    {
        public AgendamentoRepositorio(AppDbContext context) : base(context)
        {
            
        }

        public void InserirFilaAgendamento(Agendamento agendamento)
        {
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "agendamento",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string mensagem = JsonSerializer.Serialize(agendamento);

                var body = Encoding.UTF8.GetBytes(mensagem);

                channel.BasicPublish(exchange: "",
                                     body: body,
                                     routingKey: "agendamento",
                                     basicProperties : null);
            }
        }

        public async Task CancelarAgendamento(long id)
        {
            Agendamento ag = new Agendamento();
            ag = await Db.Agendamento.FirstOrDefaultAsync(x => x.Id == id);

            if (ag == null)
            {
                // tratar para quando não existir agendamentos.
            }

            if (ag.Cancelado)
            {
                // tratar para quando existir um agendamento mas que ele ja esteja cancelado.
            } 
            else
            {
                ag.Cancelado = true;

                DbSet.Update(ag);
                await SaveChanges();
            }

            
        }

        public void InseriAgendamentos()
        {
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "agendamento",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var obj = Encoding.UTF8.GetString(body);

                    Agendamento agendamento = JsonSerializer.Deserialize<Agendamento>(obj);
                    agendamento.Cancelado = false;

                    /// Criar Validação para o agendamento 
                    //if (ValidaPeriodoAgendamento(agendamento.DataAgendamento)) {
                    //    DbSet.Add(agendamento);
                    //    SaveChanges();
                    //}
                };

                channel.BasicConsume(queue : "agendamento",
                                     autoAck : true,
                                     consumer : consumer);
            }
            
        }


        //public async bool ValidaPeriodoAgendamento(DateTime dataAgendamento)
        //{
        //    var ag = await Db.Agendamento.FirstOrDefaultAsync(x => x.DataAgendamento == dataAgendamento);
        //    if(ag == null)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
