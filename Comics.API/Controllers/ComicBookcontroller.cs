using Microsoft.AspNetCore.Mvc;

namespace Comics.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComicBookcontroller : ControllerBase
    {
        private IComicBookService _cService;

        public ComicBookcontroller(IComicBookService cService)
        {
            _cService = cService;
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var book = await _cService.GetComicBookById(id);
            if (book is null)
                return NotFound();
            else
                return Ok(book);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var books = await _cService.GetComicBooks();
            return Ok(books);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] ComicCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _cService.AddComicBook(model))
                return Ok("Comic Added To the database");
            else
                return StatusCode(500, "Internal Server Error.");
        }
        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _cService.DeleteComicBook(id))
                return Ok("Successful Deletion.");
            else
                return StatusCode(500, "Internal Server Error.");
        }
    }
}