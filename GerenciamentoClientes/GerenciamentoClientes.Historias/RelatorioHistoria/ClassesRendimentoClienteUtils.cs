using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoClientes.Historias.RelatorioHistoria
{
    public class ClassesRendimentoClienteUtils
    {
        public string ClassesRendimentoDescricao(decimal rendimentoFamiliar)
        {
            return rendimentoFamiliar <= 980
                    ? "Classe C"
                    : rendimentoFamiliar <= 2500
                    ? "Classe B"
                    : "Classe A";

        }


    }
}
