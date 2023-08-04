using CPObjects.Infrastructure.Data;
using Infrastructure.Core;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Infra.EF.Data
{
    public class SolutionContext : DbContext
    {
        public DbSet<EventStore> Events { get; set; }

        public SolutionContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(bool accept, CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                await EventStoreAdd();
                return await base.SaveChangesAsync(accept, cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        private async Task EventStoreAdd()
        {
            ChangeTracker.DetectChanges();

            var eventStories = new List<EventStore>();

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Aggregate aggregate)
                {
                    var eventStorie = new EventStore(aggregate.AggregateId);

                    foreach (var @event in aggregate.UncommittedEvents)
                    {
                        var evento = @event.Data.GetType().Name;
                        var dados = JsonConvert.SerializeObject(@event.Data);

                        eventStorie = eventStorie.Criar(@event.CreatedAt, evento, dados);
                        eventStories.Add(eventStorie);
                    }
                }
            }

            await Events.AddRangeAsync(eventStories);
        }
    }
}