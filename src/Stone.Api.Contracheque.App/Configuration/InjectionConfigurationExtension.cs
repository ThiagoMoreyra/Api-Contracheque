using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Stone.Api.Contracheque.App.AutoMapper;
using Stone.Api.Contracheque.Domain.Services;
using Stone.Api.Contracheque.Domain.Shared.Interfaces;
using Stone.Api.Contracheque.Domain.Shared.Notify;
using Stone.Api.Contracheque.Repository.Context;
using Stone.Api.Contracheque.Repository.Repositories;

namespace Stone.Api.Contracheque.App.Configuration
{
    public static class InjectionConfigurationExtension
    {
        public static void InjectionConfigurationServices(this IServiceCollection services)
        {
            services.AddSingleton(typeof(ILogger<>), (typeof(Logger<>)));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<FuncionarioContext>();

            //Services
            services.AddScoped<IFuncionarioService, FuncionarioService>();
            services.AddScoped<IExtratoService, ExtratoService>();

            //Repository
            services.AddScoped<IFuncionarioRepositorio, FuncionarioRepositorio>();

            //Notification
            services.AddScoped<INotificacao, Notificador>();

            //Mapping
            services.AddAutoMapper(typeof(DomainToOutputMappingProfile), typeof(InputToDomainMappingProfile));
        }
    }
}
