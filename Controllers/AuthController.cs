using Microsoft.AspNetCore.Mvc;
using RaceDAY_API.Database;
using RaceDAY_API.Models;
using BCrypt.Net;

namespace RaceDAY_API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly store_info db = new store_info();

        [HttpPost("login")]
        public IActionResult Login(
            [FromQuery] string email,
            [FromQuery] string password)
        {
            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                return BadRequest("Email and password are required.");
            }

            User? user = db.getUserByEmail(email);

            if (user == null)
                return Unauthorized("Invalid email or password.");

            bool validPassword;

            try
            {
                validPassword = BCrypt.Net.BCrypt.Verify(password, user.password);
            }
            catch
            {
                validPassword = false;
            }

            if (!validPassword)
                return Unauthorized("Invalid email or password.");

            HttpContext.Session.SetInt32("userID", user.userID);
            HttpContext.Session.SetString("userRole", user.userRole);

            return Ok(new
            {
                message = "Login successful.",
                userID = user.userID,
                fullName = user.fullName,
                emailAddress = user.emailAddress,
                userRole = user.userRole
            });
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Ok("Logout successful.");
        }
    }
}