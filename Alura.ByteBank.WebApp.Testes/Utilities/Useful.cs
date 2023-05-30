using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ByteBank.WebApp.Testes.Utilities
{
    public static class Useful
    {
        public static string CaminhoDriverNavegador()
            => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }
}
