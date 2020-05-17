using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UdemyJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KimlikController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult GirisYap()
        {
            return Created("",new TokenOlusturucu().TokenOlustur());
        }

        [HttpGet("[action]")]
        public IActionResult AdminGirisYap()
        {
            return Created("", new TokenOlusturucu().AdminTokenOlusturcu());
        }

        [Authorize(Roles ="Admin,Member")]
        [HttpGet("[action]")]
        public IActionResult AdminSayfasi()
        {

            var sehir = User.Claims.Where(I => I.Type == "Ankara").FirstOrDefault();
            var username = User.Identity.Name;

            return Ok("Token admin Oluşturldu");
        }
        [Authorize]
        [HttpGet("[action]")]
        public IActionResult Erisim()
        {
            return Ok("Token Oluşturldu");
        }

   
    
    
    
    }
}