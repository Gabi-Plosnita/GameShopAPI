using GameShop.BusinessLogic.Services;
using GameShop.EntityLayer.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GameShop.API.Controllers
{
    [Route("api/GameCompanies")]
    public class GameCompaniesController : ControllerBase
    {
        private readonly IGameCompanyService _gameCompanyService;

        public GameCompaniesController(IGameCompanyService gameCompanyService)
        {
            _gameCompanyService = gameCompanyService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public List<GameCompanyResponseDto> GetAll()
        {
            return _gameCompanyService.GetAll();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public GameCompanyResponseDto GetById([FromRoute] int id)
        {
            return _gameCompanyService.GetById(id);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public void Create([FromBody] GameCompanyRequestDto gameCompanyDto)
        {
            _gameCompanyService.Create(gameCompanyDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public void Update([FromRoute] int id, [FromBody] GameCompanyRequestDto updatedGameCompanyDto)
        {
            _gameCompanyService.Update(id, updatedGameCompanyDto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public void Delete([FromRoute] int id)
        {
            _gameCompanyService.Delete(id);
        }   
    }
}
