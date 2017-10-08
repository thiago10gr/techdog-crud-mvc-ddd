using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;
using Projeto.Dominio.Contratos.Utilitarios;

namespace Projeto.Infra.Util
{
    public class CriptografiaUtil : ICriptografiaUtil
    {
        public string EncriptarSenha(string senha)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            return BitConverter.ToString(md5.ComputeHash(
                Encoding.UTF8.GetBytes(senha))).Replace("-", string.Empty);
        }
    }
}
