using System.Security.Cryptography;
using System.Text;

namespace Trabalho_Agenda_Contatos.Auxiliar
{
    public static class Criptografia
    {
        public static string GerarHash(this string value) //this faz com se torne possível ser um método de extensão
        {
            var hash = SHA1.Create();
            var encoding = new ASCIIEncoding();
            var array = encoding.GetBytes(value);

            array = hash.ComputeHash(array);

            var strHex = new StringBuilder();

            foreach (var item in array)
            {
                strHex.Append(item.ToString("x2"));
            }

            return strHex.ToString();
        }
    }
}
