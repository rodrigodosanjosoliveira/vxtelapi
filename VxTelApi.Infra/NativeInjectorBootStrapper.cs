using Microsoft.Extensions.DependencyInjection;
using VxTel.Domain.Contracts.Repositories;
using VxTel.Domain.Contracts.Services;
using VxTelApi.Application.Services;
using VxTelApi.Data.Context;
using VxTelApi.Data.Repositories;

namespace VxTelApi.Infra
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<ICodigoAreaTarifaRepository, CodigoAreaTarifaRepository>();
            services.AddTransient<IPlanoRepository, PlanoRepository>();
            services.AddTransient<IPlanoService, PlanoService>();
            services.AddTransient<IVxTelChamadaService,VxTelChamadasService>();
            services.AddTransient<ICodigoAreaTarifaService, CodigoAreaTarifaService>();
            services.AddScoped<VxTelContext>();
        }
    }
}
