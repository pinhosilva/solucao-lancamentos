using System;

namespace Infrastructure.Core
{
    public class EventStore
    {
        public int Id { get; set; }
        public Guid AggregateId { get; set; }
        public DateTime Data { get; set; }
        public string Evento { get; set; }
        public string Dados { get; set; }

        public EventStore()
        {

        }

        public EventStore(Guid aggregateId) : this()
        {
            AggregateId = aggregateId;
        }

        public EventStore Criar(DateTime data, string evento, string dados) => new(AggregateId)
        {
            Data = data,
            Evento = evento,
            Dados = dados
        };
    }
}