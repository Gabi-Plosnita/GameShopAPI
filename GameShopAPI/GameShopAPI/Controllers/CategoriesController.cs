using GameShop.BusinessLogic.Services;
using GameShop.EntityLayer.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameShop.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/Categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //Returns all categories
        //Can be accessed by anyone
        //200Ok is returned if the request is successful
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<CategoryResponseDto>> GetAll()
        {
            return Ok(_categoryService.GetAll());
        }

        //Returns a category by id
        //Can't be accessed by anyone
        //200Ok is returned if the request is successful
        //401Unauthorized is returned if the user is not authorized
        //404NotFound is returned if the category is not found
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CategoryResponseDto> GetById([FromRoute] int id)
        {
            return Ok(_categoryService.GetById(id));
        }

        //Creates a new category
        //Can't be accessed by anyone
        //201Created is returned if the request is successful
        //400BadRequest is returned if the request is invalid
        //401Unauthorized is returned if the user is not authorized
        //409Conflict is returned if the category already exists
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult Create([FromBody] CategoryRequestDto categoryDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _categoryService.Create(categoryDto);
            return Created();
        }

        //Updates a category by id
        //Can't be accessed by anyone
        //204NoContent is returned if the request is successful
        //400BadRequest is returned if the request is invalid
        //401Unauthorized is returned if the user is not authorized
        //404NotFound is returned if the category is not found
        //409Conflict is returned if the category already exists
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult Update([FromRoute] int id, [FromBody] CategoryRequestDto updatedCategoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _categoryService.Update(id, updatedCategoryDto);
            return NoContent();
        }

        //Deletes a category by id
        //Can't be accessed by anyone
        //204NoContent is returned if the request is successful
        //401Unauthorized is returned if the user is not authorized
        //404NotFound is returned if the category is not found
        //409Conflict is returned if the category has games associated with it
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult Delete([FromRoute] int id)
        {
            _categoryService.Delete(id);
            return NoContent();
        }
    }
}
