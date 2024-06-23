using GameShop.BusinessLogic.Services;
using GameShop.EntityLayer.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameShop.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/GameCompanies")]
    public class GameCompaniesController : ControllerBase
    {
        private readonly IGameCompanyService _gameCompanyService;

        public GameCompaniesController(IGameCompanyService gameCompanyService)
        {
            _gameCompanyService = gameCompanyService;
        }

        //Returns all game companies
        //Can be accessed by anyone
        //200Ok is returned if the request is successful
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<GameCompanyResponseDto>> GetAll()
        {
            return Ok(_gameCompanyService.GetAll());
        }

        //Returns a game company by id
        //Only admins can access this endpoint
        //200Ok is returned if the request is successful
        //401Unauthorized is returned if the user is not authorized
        //404NotFound is returned if the game company is not found
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<GameCompanyResponseDto> GetById([FromRoute] int id)
        {
            return Ok(_gameCompanyService.GetById(id));
        }

        //Creates a new game company
        //Only admins can access this endpoint
        //200Ok is returned if the request is successful
        //400BadRequest is returned if the request is invalid
        //401Unauthorized is returned if the user is not authorized
        //409Conflict is returned if the game company already exists
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult Create([FromBody] GameCompanyRequestDto gameCompanyDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _gameCompanyService.Create(gameCompanyDto);
            return Ok();
        }

        //Updates a game company by id
        //Only admins can access this endpoint
        //204NoContent is returned if the request is successful
        //400BadRequest is returned if the request is invalid
        //401Unauthorized is returned if the user is not authorized
        //404NotFound is returned if the game company is not found
        //409Conflict is returned if the game company already exists
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult Update([FromRoute] int id, [FromBody] GameCompanyRequestDto updatedGameCompanyDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _gameCompanyService.Update(id, updatedGameCompanyDto);
            return NoContent();
        }

        //Deletes a game company by id
        //Only admins can access this endpoint
        //204NoContent is returned if the request is successful
        //401Unauthorized is returned if the user is not authorized
        //404NotFound is returned if the game company is not found
        //409Conflict is returned if the game company has games on the market
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult Delete([FromRoute] int id)
        {
            _gameCompanyService.Delete(id);
            return NoContent();

        }   
    }
}
