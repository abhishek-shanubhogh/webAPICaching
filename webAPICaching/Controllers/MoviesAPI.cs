using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using webAPICaching.Data;
using webAPICaching.Model;
using webAPICaching.Services;

namespace webAPICaching.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesAPI : ControllerBase
    {
        private readonly ICache _cache;
        private readonly MovieDBContext _movieData;
        public MoviesAPI(ICache cache, MovieDBContext movieData)
        {
            _cache = cache;
            _movieData = movieData;
        }



        [HttpGet("Drivers")]
        public async Task<IActionResult> Get()
        {
            var res = _cache.getData<IEnumerable<Movies>>("drivers");

            if (res != null && res.Count() > 0)
            {
                return Ok(res);
            }
            var resDB = await _movieData.MovieTable.ToListAsync();

            var timeExpiry = DateTimeOffset.Now.AddSeconds(120);


            _cache.setData<IEnumerable<Movies>>("drivers", resDB, timeExpiry);
            return Ok(resDB);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Movies m)
        {
            await _movieData.MovieTable.AddAsync(m);
            await _movieData.SaveChangesAsync();
            return Ok(m + "Added succesfully");
        }

        [HttpDelete]

        public async Task<IActionResult> delete(int id)
        {
            var res = await _movieData.MovieTable.FirstOrDefaultAsync(x => x.Id == id);
            if (res == null)
            {
                return NotFound();
            }
             _movieData.MovieTable.Remove(res);
            await _movieData.SaveChangesAsync();
            return Ok(res);
        }

        [HttpGet]
        
        public async Task<IActionResult> GetbyId(int id)
        {

            var res = await _movieData.MovieTable.FirstOrDefaultAsync(x => x.Id == id);

            if(res !=null)
            {
                return Ok(res);
            }
            return NotFound();
        }



    }
}
