using Microsoft.AspNetCore.Mvc;
using tpmodul10_103022300057.Models;

namespace tpmodul10_103022300057.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MahasiswaController : ControllerBase
    {
        private static List<Mahasiswa> _mahasiswaList =
        [
            new Mahasiswa("Mochammad Syaifuddin Zuhri", "103022300057"),
            new Mahasiswa("LeBron James", "1302000001"),
            new Mahasiswa("Stephen Curry", "1302000002")
        ];

        // GET: api/mahasiswa
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mahasiswaList);
        }

        // GET: api/mahasiswa/{index}
        [HttpGet("{index}")]
        public IActionResult Get(int index)
        {
            if (index < 0 || index >= _mahasiswaList.Count)
            {
                return NotFound("Mahasiswa not found");
            }

            return Ok(_mahasiswaList[index]);
        }

        // POST: api/mahasiswa
        [HttpPost]
        public IActionResult Post([FromBody] Mahasiswa mahasiswa)
        {
            _mahasiswaList.Add(mahasiswa);
            return CreatedAtAction(nameof(Get), new { index = _mahasiswaList.Count - 1 }, mahasiswa);
        }

        // DELETE: api/mahasiswa/{index}
        [HttpDelete("{index}")]
        public IActionResult Delete(int index)
        {
            if (index < 0 || index >= _mahasiswaList.Count)
            {
                return NotFound("Mahasiswa not found");
            }

            _mahasiswaList.RemoveAt(index);
            return NoContent();
        }
    }
}