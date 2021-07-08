using GerenciamentoClientes.Infra.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoClientes.Historias.ClienteHistoria
{
   public class VerificarCpfCliente
    {
        private readonly GerenciamentoClienteContexto _contexto;

        public VerificarCpfCliente(GerenciamentoClienteContexto contexto)
        {
            _contexto = contexto;
        }

        public bool Executar(string cpf)
        {
            bool clienteJaCadastrado = _contexto.Cliente.Any(cliente => cliente.CPF == cpf);

            return clienteJaCadastrado;
        }
    }
}
