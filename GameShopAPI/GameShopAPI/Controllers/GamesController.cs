using GameShop.BusinessLogic.Services;
using GameShop.EntityLayer.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameShop.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/Games")]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }


        //Returns all games
        //Can be accessed by anyone
        //200Ok is returned if the request is successful
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<GameResponseDto>>GetAll()
        {
            return Ok(_gameService.GetAll());
        }


        //Returns a game by id
        //Only admins can access this endpoint
        //200Ok is returned if the request is successful
        //401Unauthorized is returned if the user is not authorized
        //404NotFound is returned if the game is not found
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<GameResponseDto> GetById([FromRoute] int id)
        {
           return Ok(_gameService.GetById(id));
        }


        //Creates a new game
        //Only admins can access this endpoint
        //200Ok is returned if the request is successful
        //400BadRequest is returned if the request is invalid
        //401Unauthorized is returned if the user is not authorized
        //409Conflict is returned if the game already exists
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult Create([FromBody] GameRequestDto gameDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _gameService.Create(gameDto);
            return Ok();
        }

        
        //Updates a game by id
        //Only admins can access this endpoint
        //204NoContent is returned if the request is successful
        //400BadRequest is returned if the request is invalid
        //401Unauthorized is returned if the user is not authorized
        //404NotFound is returned if the game is not found
        //409Conflict is returned if the game already exists
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult Update([FromRoute] int id, [FromBody] GameRequestDto updatedGameDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _gameService.Update(id, updatedGameDto);
            return NoContent();
        }


        //Deletes a game by id
        //Only admins can access this endpoint
        //204NoContent is returned if the request is successful
        //401Unauthorized is returned if the user is not authorized
        //404NotFound is returned if the game is not found
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete([FromRoute] int id)
        {
            _gameService.Delete(id);
            return NoContent();
        }
    }
}
