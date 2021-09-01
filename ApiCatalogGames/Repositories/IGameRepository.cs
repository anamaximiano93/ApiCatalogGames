using ApiCatalogGames.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogGames.Repositories
{
   public interface IGameRepository:IDisposable
    {
        Task<List<Game>> Get(int page, int count);
        Task<Game> Get(Guid id);
        Task<List<Game>> Get(string Name, string produtora);
        Task Create(Game game);
        Task Update(Game game);
        Task Delete(Guid id);
      
    }
}
