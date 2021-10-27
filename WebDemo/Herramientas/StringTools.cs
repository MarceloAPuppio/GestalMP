using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDemo.Herramientas
{
    public static class StringTools
    {
        public static List<string> SplitString(string str, string separador) => str.Split(separador).ToList();
    }
}
