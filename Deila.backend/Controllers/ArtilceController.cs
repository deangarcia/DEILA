using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using deila.backend.Entities;
using deila.backend.Services;
using deila.backend.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Diagnostics;

namespace deila.backend.Controllers
{
    [Route("api/articles")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleRepo _articleRepo;
        private readonly IMapper _mapper;

        public ArticleController(IArticleRepo articleRepo, IMapper mapper)
        {
            _articleRepo = articleRepo ?? throw new ArgumentNullException(nameof(articleRepo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/articles
        [HttpGet]
        public async Task<ActionResult<Article>> GetArticles()
        {
            var articleEntities = await _articleRepo.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ArticleDto>>(articleEntities));
        }

        // GET: api/articles/<id>
        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> GetArticle(int id)
        {
            var article = await _articleRepo.GetByIdAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ArticleDto>(article));
        }

        //PUT: api/articles/<id>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateArticle(int id, [FromBody] ArticleUpdateDto articleIn)
        {
            var article = await _articleRepo.GetByIdAsync(id);

            if (article == null)
            {
                return BadRequest();
            }

            _mapper.Map(articleIn, article);
            await _articleRepo.Update(article);

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialUpdateArticle(int id, [FromBody] JsonPatchDocument<ArticleUpdateDto> patchDoc)
        {
            var article = await _articleRepo.GetByIdAsync(id);

            if (article == null)
            {
                return BadRequest();
            }

            var articleToPatch = _mapper.Map<ArticleUpdateDto>(article);

            patchDoc.ApplyTo(articleToPatch, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _mapper.Map(articleToPatch, article);
            await _articleRepo.Update(article);

            return NoContent();
        }

        // POST: api/articles
        [HttpPost]
        public async Task<ActionResult<Article>> CreateArticle([FromBody] ArticleCreateDto article)
        {
            var articleIn = _mapper.Map<Article>(article);
            _articleRepo.Add(articleIn);
            await _articleRepo.SaveAsync();
            return CreatedAtAction("GetArticle", new { id = articleIn.Id }, articleIn);
        }

        //// DELETE: api/article/<id>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteArticle(int id)
        {
            var article = await _articleRepo.GetByIdAsync(id);
            if (article == null)
            {
                return NotFound();
            }

            _articleRepo.Remove(article);

            return NoContent();
        }
    }
}
