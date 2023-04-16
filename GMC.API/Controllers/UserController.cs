using GMC.API.ViewModel.Create;
using GMC.API.ViewModel.Get;
using GMC.API.ViewModel.Update;
using GMC.Core;
using GMC.Data;
using GMC.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GMC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
       
        private readonly IUserService userService;
        private readonly DataContext dataContext;
        public UserController(IUserService userService, DataContext dataContext)
        {
            this.userService = userService;
            this.dataContext = dataContext;
            
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
            user.Token = CreateJwt(user);

            return Ok(new
            {
                Token= user.Token,
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
       /* private async Task<bool> CheckUserNameExistAsync(string username)
        {
            return await dataContext.User.AnyAsync(x=>x.Username == username);
        }*/
       private string CreateJwt(User user)
        {
            var jwtTokenHandler =  new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("veryverysecret..........");
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Name,$"{user.FirstName} {user.LastName}")
            });
            var  credentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256);
            var tokenDecriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDecriptor);
            return jwtTokenHandler.WriteToken(token);
        }
        [HttpGet("validate")]
        public async Task<IActionResult> ValidateToken()
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("veryverysecret..........");
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var username = jwtToken.Claims.First(x => x.Type == "sub").Value;

                // TODO: Add your logic here to verify the user and the token

                return Ok(new { Message = "Token is valid" });
            }
            catch
            {
                return Unauthorized();
            }
        }


    }
}
