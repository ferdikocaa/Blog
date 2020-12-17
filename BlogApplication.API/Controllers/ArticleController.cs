using AutoMapper;
using BlogApplication.Contracts;
using BlogApplication.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleContracts _articleService;
        private readonly IMapper _mapper;
        public ArticleController(IArticleContracts articleContracts,IMapper mapper)
        {
            _articleService = articleContracts;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Message()
        {
            var article = _articleService.GetAll();
            //_mapper.Map<ArticleDto>(article);
            return Ok(_articleService.Message("selam"));
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            var a = _articleService.GetAll();
            return Ok("bassarili");
        }
        
        //[HttpGet]
        //public async Task<IActionResult> TestMessage()
        //{
        //    return Ok(_articleService.Message());
        //}
    }
}
