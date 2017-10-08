using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Dominio.Excecoes
{
    public class CustomException : Exception
    {
        public CustomException()
           : base()
        { }

        public CustomException(string message)
            : base(message)
        { }
    }
}
