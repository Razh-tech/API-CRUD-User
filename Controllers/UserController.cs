using Microsoft.AspNetCore.Mvc;
using API_CRUD_User.Models;

namespace API_CRUD_User.Controllers
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;
        
        public UserController(UserContext context)
        {
            _context = context;

            if (_context.Users.Any()) return;

            UserSeed.InitData(context);
        }

        // User List API
        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IQueryable<UserViewModel>> GetUser()
        {
            var result = _context.Users as IQueryable<UserViewModel>;

            return Ok(result
                .OrderBy(u => u.FullName));
        }

        // User Create API
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UserViewModel> PostUser([FromBody] UserViewModel user)
        {
            try
            {
                _context.Users.Add(user);   
                _context.SaveChanges();

                return new CreatedResult($"/user/{user.FullName}", user);
            }
            catch (Exception e)
            {
                return ValidationProblem(e.Message);
            }
        }

        // User Update API
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UserViewModel> PutUser([FromBody] UserViewModel user)
        {
            try
            {
                var userDb = _context.Users
                    .FirstOrDefault(u => u.FullName.Equals(user.FullName, StringComparison.InvariantCultureIgnoreCase));

                if (userDb == null) return NotFound();

                userDb.FullName = user.FullName;
                userDb.Address = user.Address;
                userDb.BirthDate = user.BirthDate;
                userDb.Sex = user.Sex;
                userDb.Photo = user.Photo;
                _context.SaveChanges();

                return Ok(user);
            }
            catch (Exception e)
            {
                return ValidationProblem(e.Message);
            }
        }

        // User Delete API
        [HttpDelete]
        [Route("{fullName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserViewModel> DeleteUser([FromRoute] string fullName)
        {
            var userDb = _context.Users
                .FirstOrDefault(u => u.FullName.Equals(fullName, StringComparison.InvariantCultureIgnoreCase));

            if (userDb == null) return NotFound();

            _context.Users.Remove(userDb);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
