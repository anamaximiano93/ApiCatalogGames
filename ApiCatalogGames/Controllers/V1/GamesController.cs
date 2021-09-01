using ApiCatalogGames.Exceptions;
using ApiCatalogGames.InputModel;
using ApiCatalogGames.Services;
using ApiCatalogGames.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogGames.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GamesViewModel>>> getGames([FromQuery, Range(1, int.MaxValue)] int page = 1, [FromQuery, Range(1,50)] int count = 5)
        {
            var games = await _gameService.Get(page, count);

            if(games.Count() == 0)
            {
                return NoContent();
            }

            return Ok(games);
        } 

        [HttpGet("{idGame:guid}")]
        public async Task<ActionResult<GamesViewModel>> getGames( [FromRoute]Guid idGame)
        {
            var game = await _gameService.Get(idGame);

            if (game == null)
                return NoContent();

            return Ok(game);
        } 

        [HttpPost]
        public async Task<ActionResult<GamesViewModel>> CreateGame([FromBody]GameInputModel gameinputModel)
        {
            try
            {
                var game = await _gameService.Create(gameinputModel);
                return Ok(game);
            }
            catch (JogoJaCadastradoExecption )
            {

                return UnprocessableEntity("There is already a game with this name for this producer.");
            }
        }

        [HttpPut("{idGame:guid}")]
        public async Task<ActionResult> UpadateGame([FromRoute]Guid idGame,[FromBody] GameInputModel gameinputModel)
        {
            try
            {
                await _gameService.Update(idGame, gameinputModel);

                return Ok();
            }
            catch (JogoNaoCadastradoExecption)
            {

                return NotFound("No exists this game.");
            }
        } 
        
        [HttpPatch("{idGame:guid}/preco/{preco:double}")]
        public async Task<ActionResult> UpadateGame([FromRoute]Guid idGame,[FromRoute] double preco)
        {

            try
            {
                await _gameService.Update(idGame, preco);

                return Ok();
            }
            catch (JogoNaoCadastradoExecption)
            {

                return NotFound("No exists this game.");
            }
        }

        [HttpDelete("{idGame:guid}")]

        public async Task<ActionResult> DeleteGame([FromRoute] Guid idGame)
        {
            try
            {
                await _gameService.Delete(idGame);
                return Ok();
            }
            catch (JogoNaoCadastradoExecption)
            {

                return NotFound("No exists this game.");
            }
        }
        }
    
}
