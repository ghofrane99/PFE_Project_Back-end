using GMC.API.ViewModel.Create;
using GMC.API.ViewModel.Get;
using GMC.API.ViewModel.Update;
using GMC.Core;
using GMC.Data;
using GMC.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
       
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
            
        }
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var users = await userService.GetUsersAsync();
            return Ok(users);
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User userv)
        {
            if (userv == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var user = await userService.Authenticate(userv);
            if (user == null)
                return NotFound(new { Message = "User Not Found !" });

            return Ok(new
            {
                Message = "Login Success!"
            });
        }


        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {

            var createdUser = await userService.CreateUserAsync(user);
            return Ok(createdUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            var entityToUpdate = await userService.GetUserAsync(id);
            if (entityToUpdate == null)
            {
                return NotFound();
            }

            entityToUpdate.FirstName = user.FirstName;
            entityToUpdate.LastName = user.LastName;
            entityToUpdate.Username = user.Username;
            entityToUpdate.Password = user.Password;
            entityToUpdate.Token = user.Token;
            entityToUpdate.Role = user.Role;
            entityToUpdate.Email = user.Email;



            var updatedUser = await userService.UpdateUserAsync(entityToUpdate);
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await userService.GetUserAsync(id);
            if (user == null)
                return NotFound();
            var isSucces = await userService.DeleteUserAsync(id);
            return Ok();
        }

    }
}
