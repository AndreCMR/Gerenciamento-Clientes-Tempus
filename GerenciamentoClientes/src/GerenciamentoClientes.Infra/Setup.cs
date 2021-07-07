using GerenciamentoClientes.Infra.Contexto;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciamentoClientes.Infra
{
    public static class Setup
    {
        public static void AdicionarContexto(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GerenciamentoClienteContexto>(x => x.EnableSensitiveDataLogging().UseSqlServer(configuration.GetConnectionString("DbGerenciamentoCliente")));
        }
        public static void MigrationInitialisation(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                serviceScope.ServiceProvider.GetService<GerenciamentoClienteContexto>().Database.Migrate();
            }
        }
    }
}
