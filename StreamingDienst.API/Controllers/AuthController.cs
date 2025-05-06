using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StreamingDienst.API.Data;
using StreamingDienst.API.Models;
using StreamingDienst.Shared.Dtos;

namespace StreamingDienst.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        #region Constructor
        public AuthController(AppDbContext context) 
        {
            _context = context;
        }

        #endregion

        #region Fields

        private readonly AppDbContext _context;
        #endregion

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            // Prüfe, ob E-Mail bereits existiert
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
                return BadRequest("Benutzer existiert bereits.");
            
            // Passwort hashen
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            // Benutzer speichern
            var user = new User
            {
                Email = dto.Email,
                PasswordHash = hashedPassword,
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("Registrierung erfolgreich.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null)
                return Unauthorized("Benutzer nicht gefunden.");

            bool isValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);
            if (!isValid)
                return Unauthorized("Falsches Passwort.");

            return Ok("Login erfolgreich.");
        }
    }
}
