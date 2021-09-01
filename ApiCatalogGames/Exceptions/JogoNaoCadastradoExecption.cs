using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogGames.Exceptions
{
    public class JogoNaoCadastradoExecption:Exception
    {
        public JogoNaoCadastradoExecption():base("This game no is registered") { }
    }
}
