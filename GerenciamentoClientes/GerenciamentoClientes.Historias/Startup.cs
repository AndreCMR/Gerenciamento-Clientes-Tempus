﻿using GerenciamentoClientes.Historias.ClienteHistoria;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoClientes.Historias
{
    public static class Startup
    {
        public static void AdicionarHistoria(this IServiceCollection services)
        {
            //Injeção
            services.AddScoped<CadastrarCliente>();
            services.AddScoped<ListarClientes>();
        }
    }
}
