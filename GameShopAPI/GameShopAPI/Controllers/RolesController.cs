using GameShop.BusinessLogic.Services;
using GameShop.EntityLayer.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameShop.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/Roles")]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }


        //Returns all roles
        //Only admins can access this endpoint
        //200Ok is returned if the request is successful
        //401Unauthorized is returned if the user is not authorized
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<List<RoleResponseDto>> GetRoles()
        {
            return Ok(_roleService.GetAll());
        }


        //Returns a role by id
        //Only admins can access this endpoint
        //200Ok is returned if the request is successful
        //401Unauthorized is returned if the user is not authorized
        //404NotFound is returned if the role is not found
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<RoleResponseDto> GetRole([FromRoute] int id)
        {
            return Ok(_roleService.Get(id));           
        }


        //Creates a new role
        //Only admins can access this endpoint
        //200Ok is returned if the request is successful
        //400BadRequest is returned if the request is invalid
        //401Unauthorized is returned if the user is not authorized
        //409Conflict is returned if the role already exists
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]

        public IActionResult CreateRole([FromBody] RoleRequestDto role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _roleService.Create(role);
            return Ok();
        }


        //Updates a role by id
        //Only admins can access this endpoint
        //204NoContent is returned if the request is successful
        //400BadRequest is returned if the request is invalid
        //401Unauthorized is returned if the user is not authorized
        //404NotFound is returned if the role is not found
        //409Conflict is returned if the role already exists
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        
        public IActionResult UpdateRole([FromRoute] int id, [FromBody] RoleRequestDto updatedRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _roleService.Update(id, updatedRole);
            return NoContent();
        }


        //Deletes a role by id
        //Only admins can access this endpoint
        //204NoContent is returned if the request is successful
        //401Unauthorized is returned if the user is not authorized
        //404NotFound is returned if the role is not found
        //409Conflict is returned if the role has active users
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult DeleteRole([FromRoute] int id)
        {
            _roleService.Delete(id);
            return NoContent();
        }
    }
}
