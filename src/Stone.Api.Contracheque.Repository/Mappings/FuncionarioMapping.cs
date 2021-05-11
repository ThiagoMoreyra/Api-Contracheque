using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stone.Api.Contracheque.Domain.Entities;

namespace Stone.Api.Contracheque.Repository.Mappings
{
    public class FuncionarioMapping : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasKey(p => p.Id);           

            builder.Property(p => p.SalarioBruto)
                .IsRequired()
                .HasColumnType("decimal");

            builder.Property(p => p.Setor)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.DataDeAdmissao)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(p => p.PossuiDescontoPlanoDental)
                .IsRequired()
                .HasColumnType("bit");

            builder.Property(p => p.PossuiDescontoPlanoDeSaude)
                .IsRequired()
                .HasColumnType("bit");

            builder.Property(p => p.PossuiDescontoValeTransporte)
                .IsRequired()
                .HasColumnType("bit");

            builder.OwnsOne(p => p.NomeFuncionario, c =>
            {
                c.Property(c => c.Nome)
                    .HasColumnName("Nome")
                    .HasColumnType("VARCHAR(100)");

                c.Property(c => c.SobreNome)
                    .HasColumnName("SobreNome")
                    .HasColumnType("VARCHAR(100)");
            });

            builder.OwnsOne(p => p.CPF, c =>
            {
                c.Property(c => c.Documento)
                    .HasColumnName("CPF")
                    .HasColumnType("VARCHAR(100)");
            });

            builder.ToTable("tbFuncionario");
        }
    }
}
