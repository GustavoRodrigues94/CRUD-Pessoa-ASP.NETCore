using CRUDPessoa.Cadastros.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUDPessoa.Cadastros.Infra.Mapeamentos
{
    public class PessoaMapeamento : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoas");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasColumnType("varchar(250)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("varchar(250)").IsRequired();
            builder.OwnsOne(x => x.Documento, d =>
            {
                d.Property(x => x.NumeroDocumento).HasColumnName("NumeroDocumento").HasColumnType("varchar(250)").IsRequired();
                d.Property(x => x.TipoPessoa).HasColumnName("TipoPessoa").HasColumnType("varchar(15)").HasConversion<string>().IsRequired();
            });
        }
    }
}
