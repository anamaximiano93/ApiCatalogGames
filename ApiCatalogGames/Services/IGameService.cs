using ApiCatalogGames.InputModel;
using ApiCatalogGames.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogGames.Services
{
    public interface IGameService :IDisposable
    {
       
        Task<List<GamesViewModel>> Get(int page, int count);
        Task<GamesViewModel> Get(Guid id);
        Task<GamesViewModel> Create(GameInputModel game);
        Task Update(Guid id, GameInputModel game);
        Task Update(Guid id, double preco);
        Task Delete(Guid id);
    }
}
