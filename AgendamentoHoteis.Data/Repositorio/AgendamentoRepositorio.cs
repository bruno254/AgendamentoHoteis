using AgendamentoHoteis.Business.Interfaces;
using AgendamentoHoteis.Business.Models;
using AgendamentoHoteis.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace AgendamentoHoteis.Data.Repositorio
{
    public class AgendamentoRepositorio : RepositorioBase<Agendamento>, IAgendamentoRepositorio
    {
        public AgendamentoRepositorio(AppDbContext context, IConfiguration configuration) : base(context, configuration)
        {
            
        }

        public async Task<List<Agendamento>> BuscaPorUsuario(long idUsuario)
        {
            
            return await Db.Agendamento.Where(x => x.IdUsuario == idUsuario).ToListAsync();
        }

        public async Task InserirFilaAgendamento(Agendamento agendamento)
        {
            ValidaAgendamento(agendamento);

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
            Agendamento ag = await Db.Agendamento.FirstOrDefaultAsync(x => x.Id == id);

            if (ag == null)
            {
                throw new Exception("Agendamento Não Encontrado");
            }

            if (ag.Cancelado)
            {
                throw new Exception("Agendamento Já Está cancelado");
            } 
            else
            {
                ag.Cancelado = true;

                DbSet.Update(ag);
                await SaveChanges();
            }
        }

        public void ValidaAgendamento(Agendamento ag)
        {
            var count = Db.Agendamento.Where(x => x.DataAgendamento == ag.DataAgendamento && x.NroQuarto == ag.NroQuarto && ag.Cancelado == false).Count();

            if(count > 0)
            {
                throw new Exception("Quarto já reservado para o período!");
            }
        }

       
    }
}
