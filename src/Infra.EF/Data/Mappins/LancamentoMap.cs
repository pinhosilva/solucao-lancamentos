using Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EF.Data.Mappins
{
    public class LancamentoMap : IEntityTypeConfiguration<LancamentoAggregate>
    {
        public void Configure(EntityTypeBuilder<LancamentoAggregate> builder)
        {
            builder
                .ToTable("Lancamentos", "RM")
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("Id");

            builder
                .Property(x => x.AggregateId)
                .HasColumnName("AggregateId");

            builder
                .Property(x => x.TimeStamp)
                .HasColumnName("DataCriacao");
            
            builder
                .Property(x => x.Saldo)
                .HasColumnName("Saldo");
        }
    }
}