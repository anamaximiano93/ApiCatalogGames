using ApiCatalogGames.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogGames.Repositories
{
    public class GameRepository : IGameRepository
    {
        private static Dictionary<Guid, Game> games = new Dictionary<Guid, Game>()
        {
            {Guid.Parse("23bb896f-f11c-417b-8d57-312f8725e5e4"),new Game{Id= Guid.Parse("23bb896f-f11c-417b-8d57-312f8725e5e4"),Nome="Fifa 2021", Produtora="EA", Preco=200} }, 
            {Guid.Parse("bd9c25de-3ef2-4792-983f-2ff792f093b3"),new Game{Id= Guid.Parse("bd9c25de-3ef2-4792-983f-2ff792f093b3"),Nome="Fifa 2020", Produtora="EA", Preco=80} },
            {Guid.Parse("caa7489c-8178-4863-935f-8c2214a656ce"),new Game{Id= Guid.Parse("caa7489c-8178-4863-935f-8c2214a656ce"),Nome="The Witcher 3", Produtora="CdProjects", Preco=70} },
            {Guid.Parse("04ff1242-3cdc-47b0-9657-5d8704a91ac8"),new Game{Id= Guid.Parse("04ff1242-3cdc-47b0-9657-5d8704a91ac8"),Nome="GTA V", Produtora="RockStart Games", Preco=200} },
            {Guid.Parse("e516386b-9c72-4bfb-b572-c4cf4edecdb3"),new Game{Id= Guid.Parse("e516386b-9c72-4bfb-b572-c4cf4edecdb3"),Nome="Watch Dogs", Produtora="Ubisoft", Preco=200} },
            {Guid.Parse("a6f1d8fe-c41f-4763-8753-5cd300616dbd"),new Game{Id= Guid.Parse("a6f1d8fe-c41f-4763-8753-5cd300616dbd"),Nome="Blair Witch", Produtora="Bloober Team", Preco=200} },
        };
        public Task Create(Game game)
        {
            games.Add(game.Id, game);
            return Task.CompletedTask;
        }

        public Task Delete(Guid id)
        {
            games.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
           // throw new NotImplementedException();
        }

        public Task<List<Game>> Get(int page, int count)
        {
            return Task.FromResult(games.Values.Skip((page - 1) * count).Take(count).ToList());
        }

        public Task<Game> Get(Guid id)
        {
            if (!games.ContainsKey(id))
                return null;

            return Task.FromResult(games[id]);
        }

        public Task<List<Game>> Get(string Name, string produtora)
        {
            return Task.FromResult(games.Values.Where(game => game.Nome.Equals(Name) && game.Produtora.Equals(produtora)).ToList());
        }
         public Task<List<Game>> GetSemLambda(string Name, string produtora)
        {
            var retorno = new List<Game>();

            foreach(var game in games.Values)
            {
                if(game.Nome.Equals(Name) && game.Produtora.Equals(produtora))
                {
                    retorno.Add(game);
                }
            }

            return Task.FromResult(retorno);
        }

        public Task Update(Game game)
        {
            games[game.Id] = game;
            return Task.CompletedTask;
        }
    }
}
