using ApiCatalogGames.Entities;
using ApiCatalogGames.Exceptions;
using ApiCatalogGames.InputModel;
using ApiCatalogGames.Repositories;
using ApiCatalogGames.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogGames.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<GamesViewModel> Create(GameInputModel game)
        {
            var entitieGame = await _gameRepository.Get(game.Nome, game.Produtora);

            if (entitieGame.Count > 0)
                throw new JogoJaCadastradoExecption();

            var gameInsert = new Game
            {
                Id = Guid.NewGuid(),
                Nome = game.Nome,
                Produtora = game.Produtora,
                Preco = game.Preco

            };

            await _gameRepository.Create(gameInsert);

            return new GamesViewModel
            {
                Id = gameInsert.Id,
                Nome = gameInsert.Nome,
                Produtora = gameInsert.Produtora,
                Preco = gameInsert.Preco
            };
        }

        public async Task Delete(Guid id)
        {
            var game = _gameRepository.Get(id);

            if (game == null)
                throw new JogoJaCadastradoExecption();

            await _gameRepository.Delete(id);
        }

        public void Dispose()
        {
            _gameRepository?.Dispose();
        }

        public async Task<List<GamesViewModel>> Get(int page, int count)
        {
            var games = await _gameRepository.Get(page, count);

            return games.Select(game => new GamesViewModel
            {
                Id = game.Id,
                Nome = game.Nome,
                Produtora = game.Produtora,
                Preco = game.Preco
            }).ToList();
        }

        public async Task<GamesViewModel> Get(Guid id)
        {
            var game = await _gameRepository.Get(id);

            if (game == null)
                return null;

            return new GamesViewModel
            {
                Id = game.Id,
                Nome = game.Nome,
                Produtora = game.Produtora,
                Preco = game.Preco
            };

        }

        public async Task Update(Guid id, GameInputModel game)
        {
            var entitiesGame = await _gameRepository.Get(id);

            if (entitiesGame == null)
                throw new JogoNaoCadastradoExecption();

            entitiesGame.Nome = game.Nome;
            entitiesGame.Produtora = game.Produtora;
            entitiesGame.Preco = game.Preco;

            await _gameRepository.Update(entitiesGame);
        }

        public async Task Update(Guid id, double preco)
        {
            var entitiesGame = await _gameRepository.Get(id);

            if (entitiesGame == null)
                throw new JogoNaoCadastradoExecption();

            
            entitiesGame.Preco =preco;

            await _gameRepository.Update(entitiesGame);
        }
    }
    
}
