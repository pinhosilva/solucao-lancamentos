using Infrastructure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EF.Data.Mappins
{
    public class EventStoreMap : IEntityTypeConfiguration<EventStore>
    {
        public void Configure(EntityTypeBuilder<EventStore> builder)
        {
            builder
                .ToTable("Events", "WM")
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");

            builder
                .Property(x => x.AggregateId)
                .HasColumnName("AggregateId");

            builder
                .Property(x => x.Data)
                .HasColumnName("Data");

            builder
                .Property(x => x.Evento)
                .HasColumnName("Evento");

            builder
                .Property(x => x.Dados)
                .HasColumnName("Dados");

        }
    }
}