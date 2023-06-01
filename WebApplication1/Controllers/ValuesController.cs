using Domain.Interfaces.Services;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IArtcleService _artcleService;

        public ValuesController(IArtcleService artcleService)
        {
            _artcleService = artcleService;
        }

        [HttpGet]
        public IEnumerable<ArticleDTO> Get()
        {
           return _artcleService.GetAllActive();
        }
    }
}
