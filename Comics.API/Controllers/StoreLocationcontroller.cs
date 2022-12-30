using Microsoft.AspNetCore.Mvc;

namespace Comics.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreLocationcontroller : ControllerBase
    {
        private IStoreLocationService _storeService;

        public StoreLocationcontroller(IStoreLocationService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStores()
        {
            var stores = await _storeService.GetStores();
            return Ok(stores);
        }

        // https//:localhostXXXX/api/StoreLocation/id -> https//:localhostXXXX/api/StoreLocation/3
        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetStore(int id)
        {
            var store = await _storeService.GetStoreById(id);
            if (store is null)
                return NotFound();
            else
                return Ok(store);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] StoreLocationCreate model)
        {
            //check modelstate -> did user fill out form correctly?
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _storeService.AddStoreLocation(model))
                return Ok("Success!");
            else
                return StatusCode(500, "Internal Server Error!");
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] StoreLocationEdit model)
        {
            if (id != model.Id || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _storeService.UpdateStoreLocation(id, model))
            {
                return Ok("Update Success!");
            }
            else
            {
                return StatusCode(500, "Internal Server Error!");
            }
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _storeService.DeleteStoreLocation(id))
                return Ok("Deletion Complete.");
            else
                return StatusCode(500, "Internal Server Error!");
        }

    }
}