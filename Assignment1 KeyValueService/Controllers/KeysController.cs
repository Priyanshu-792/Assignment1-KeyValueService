using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Assignment1_KeyValueService.Data;
using Assignment1_KeyValueService.Models;

namespace Assignment1_KeyValueService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KeysController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public KeysController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{key}")]
        public async Task<IActionResult> Get(string key)

        { // Retrieve the key-value pair from the database by the given key
            var keyValue = await _context.CustomKeyValuePairs.FirstOrDefaultAsync(kvp => kvp.Key == key);

            if (keyValue != null)
            {
                return Ok(new { key = keyValue.Key, value = keyValue.Value });
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [HttpPut]
        public async Task<IActionResult> PostOrPut(CustomKeyValuePair model)
        {  // Check if the key already exists in the database If key already exists, return 409 Conflict
            var existingKeyValuePair = await _context.CustomKeyValuePairs.FirstOrDefaultAsync(kvp => kvp.Key == model.Key);

            if (existingKeyValuePair != null)
            {
                return Conflict();
            }

            _context.CustomKeyValuePairs.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { key = model.Key }, model);
        }

        [HttpPatch("{key}/{value}")]
        public async Task<IActionResult> Patch(string key, string value)
        {  // Retrieve the key-value pair from the database by the given key
            var existingKeyValuePair = await _context.CustomKeyValuePairs.FirstOrDefaultAsync(kvp => kvp.Key == key);

            if (existingKeyValuePair == null)
            {
                return NotFound();
            }

            existingKeyValuePair.Value = value;
            await _context.SaveChangesAsync();

            return Ok(new { key = existingKeyValuePair.Key, value = existingKeyValuePair.Value });
        }

        [HttpDelete("{key}")]
        public async Task<IActionResult> Delete(string key)
        {
            var existingKeyValuePair = await _context.CustomKeyValuePairs.FirstOrDefaultAsync(kvp => kvp.Key == key);

            if (existingKeyValuePair == null)
            {
                return NotFound();
            }

            _context.CustomKeyValuePairs.Remove(existingKeyValuePair);
            await _context.SaveChangesAsync();
            // Return 204 No Content indicating successful deletion
            return NoContent();
        }
    }
}
