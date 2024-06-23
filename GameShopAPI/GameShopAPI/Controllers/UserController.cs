using GameShop.BusinessLogic.Services;
using GameShop.EntityLayer.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameShop.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/Users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        
        //Returns all users
        //Anyone can access this endpoint
        //200Ok is returned if the request is successful
        //400BadRequest is returned if the request is invalid
        //404NotFound is returned if the user is not found or role is not found
        //409Conflict is returned if the user already exists
        [AllowAnonymous]
        [HttpPost("/register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]

        public IActionResult Register([FromBody] UserRequestDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _userService.Register(user);
            return Ok();
        }


        //Logs in a user
        //Anyone can access this endpoint
        //200Ok is returned if the request is successful
        //400BadRequest is returned if the request is invalid
        //404NotFound is returned if the user is not found
        [AllowAnonymous]
        [HttpPost("/login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<string> Login([FromBody] LoginRequestDto login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } 

            string token = _userService.Login(login);
            return Ok(token);
        }


        //Returns all users
        //Only admins can access this endpoint
        //200Ok is returned if the request is successful
        //401Unauthorized is returned if the user is not authorized
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public ActionResult<List<UserResponseDto>> GetAll()
        {
            return Ok(_userService.GetAll());
        }


        //Returns a user by id
        //Only admins can access this endpoint
        //200Ok is returned if the request is successful
        //401Unauthorized is returned if the user is not authorized
        //404NotFound is returned if the user is not found
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<UserResponseDto> GetById([FromRoute] int id)
        {
            return Ok(_userService.Get(id));
        }


        //Updates a user by id
        //Only admins can access this endpoint
        //204NoContent is returned if the request is successful
        //400BadRequest is returned if the request is invalid
        //401Unauthorized is returned if the user is not authorized
        //404NotFound is returned if the user is not found or role is not found
        //409Conflict is returned if the user already exists
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]

        public IActionResult Update([FromRoute] int id, [FromBody] UserRequestDto updatedUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _userService.Update(id, updatedUser);
            return NoContent();
        }


        //Deletes a user by id
        //Only admins can access this endpoint
        //204NoContent is returned if the request is successful
        //401Unauthorized is returned if the user is not authorized
        //404NotFound is returned if the user is not found
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult Delete([FromRoute] int id)
        {
            _userService.Delete(id);
            return NoContent();
        }
    }
}
