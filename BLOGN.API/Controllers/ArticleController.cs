using AutoMapper;
using BLOGN.Data.Services.IService;
using BLOGN.Models;
using BLOGN.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BLOGN.API.Controllers
{
     [Route("api/v1/Article")]
     //[Route("api/[controller]")]
     [ApiController]
     public class ArticleController : ControllerBase
     {
          private readonly IArticleService _categoryService;
          private readonly IMapper _mapper;
          public ArticleController(IArticleService categoryService, IMapper mapper)
          {
               _mapper = mapper;
               _categoryService = categoryService;
          }

          [HttpGet]
          public async Task<IActionResult> GetAll()
          {
               var articles = await _categoryService.GetAll();
               var articlesDto = _mapper.Map<IEnumerable<ArticleDto>>(articles);

               return Ok(articlesDto);
          }

          [HttpGet("{Id}")]
          public async Task<IActionResult> Get(int Id)
          {
               var category = await _categoryService.Get(Id);
               var categoryDto = _mapper.Map<ArticleDto>(category);
               return Ok(categoryDto);
          }

          [HttpPost]
          public async Task<IActionResult> Save(ArticleDto categoryDto)
          {
               var category = _mapper.Map<Article>(categoryDto);
               var newArticle = await _categoryService.Add(category);
               return Created(String.Empty, null); // _mapper.Map<ArticleDto>(newArticle));
          }

          [HttpPatch]
          public async Task<IActionResult> Patch(int Id, ArticleDto categoryDto)
          {
               if (Id == 0)
               {
                    return BadRequest();
               }

               var category = _mapper.Map<Article>(categoryDto);
               _categoryService.Update(category);
               return NoContent();
          }

          [HttpDelete("{Id}")]
          public IActionResult Delete(int Id)
          {
               var entity = _categoryService.Delete(Id);
               return NoContent();
          }
     }
}
