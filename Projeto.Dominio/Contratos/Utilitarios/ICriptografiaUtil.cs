using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Dominio.Contratos.Utilitarios
{
    public interface ICriptografiaUtil
    {
        string EncriptarSenha(string senha);
    }
}
