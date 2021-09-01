using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogGames.Exceptions
{
    public class JogoJaCadastradoExecption:Exception
    {
        public JogoJaCadastradoExecption()
        
            :base("This game is already registered")
        { }
    }
}
