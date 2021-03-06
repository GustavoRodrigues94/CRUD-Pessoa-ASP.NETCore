// <auto-generated />
using System;
using CRUDPessoa.Cadastros.Infra.Contextos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CRUDPessoa.Cadastros.Infra.Migrations
{
    [DbContext(typeof(CadastrosContexto))]
    [Migration("20210615205202_PrimeiraMigration")]
    partial class PrimeiraMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CRUDPessoa.Cadastros.Dominio.Entidades.Pessoa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("CRUDPessoa.Cadastros.Dominio.Entidades.Pessoa", b =>
                {
                    b.OwnsOne("CRUDPessoa.Cadastros.Dominio.Entidades.ObjetosDeValor.Documento", "Documento", b1 =>
                        {
                            b1.Property<Guid>("PessoaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("NumeroDocumento")
                                .IsRequired()
                                .HasColumnType("varchar(250)")
                                .HasColumnName("NumeroDocumento");

                            b1.Property<string>("TipoPessoa")
                                .IsRequired()
                                .HasColumnType("varchar(15)")
                                .HasColumnName("TipoPessoa");

                            b1.HasKey("PessoaId");

                            b1.ToTable("Pessoas");

                            b1.WithOwner()
                                .HasForeignKey("PessoaId");
                        });

                    b.Navigation("Documento");
                });
#pragma warning restore 612, 618
        }
    }
}
