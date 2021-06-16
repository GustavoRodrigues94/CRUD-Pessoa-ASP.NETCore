using System;
using System.Text;
using CRUDPessoa.Cadastros.Aplicacao.Consultas;
using CRUDPessoa.Cadastros.Aplicacao.Manipuladores;
using CRUDPessoa.Cadastros.Dominio.Repositorios;
using CRUDPessoa.Cadastros.Infra.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CRUDPessoa.Services
{
    public static class MiddlewareService
    {
        public static void AdicionarSwagger(IServiceCollection services) => services.AddSwaggerGen(c =>
            c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "CRUD Pessoa",
                    Version = "v1",
                    Description = "API para CRUD de Pessoas",
                    Contact = new OpenApiContact
                    {
                        Name = "Gustavo Rodrigues da Silveira",
                        Url = new Uri("https://github.com/GustavoRodrigues94")
                    }
                }));

        public static void AdicionarInjecaoDependencia(IServiceCollection services)
        {
            services.AddTransient<IPessoaRepositorio, PessoaRespositorio>();
            services.AddTransient<PessoaManipulador, PessoaManipulador>();
            services.AddTransient<IPessoaConsultas, PessoaConsultas>();
        }
    }
}
