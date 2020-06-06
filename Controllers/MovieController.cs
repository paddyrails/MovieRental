using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DVDMovie.Models;
using DVDMovie.Models.BindingTargets;

namespace DVDMovie.Controllers
{
    [Route("api/movies")]
    public class MovieController : Controller
    {

        private DataContext context;
        public MovieController(DataContext ctx)
        {
            context = ctx;
        }

        [HttpGet("{id}")]
        public Movie GetMovie(long id)
        {
            Movie result = context.Movies
                .Include(m => m.Studio).ThenInclude(s=>s.Movies)
                .Include(m => m.Ratings)
                .FirstOrDefault(m => m.MovieId == id);

            if(result != null)
            {
                if(result.Studio != null){
                    result.Studio.Movies = result.Studio.Movies.Select(s=>
                        new Movie{
                            MovieId = s.MovieId,
                            Image = s.Image,
                            Name = s.Name,
                            Category = s.Category,
                            Description = s.Description,
                            Price = s.Price
                        }
                    );
                }
                if(result.Ratings != null)
                {
                    foreach(Rating r in result.Ratings){
                        r.Movie = null;
                    }
                }
            }
            return result;

        }

        [HttpGet]
        public IActionResult GetMovies(string category, 
                    string search, bool metadata = true, bool related = false)
        {
            IQueryable<Movie> query = context.Movies;
            if(!string.IsNullOrWhiteSpace(category))
            {
                string catLower = category.ToLower();
                query = query.Where(m => m.Category.ToLower().Contains(catLower));
            }
            if(!string.IsNullOrWhiteSpace(search))
            {
                string searchLower = search.ToLower();
                query = query.Where(m=>m.Name.ToLower().Contains(searchLower));
            }


            if(related){
                query = query.Include(m => m.Studio).Include(m=>m.Ratings);
                List<Movie> data = query.ToList();
                data.ForEach(m =>{
                    if(m.Studio != null)
                    {
                        m.Studio.Movies = null;
                    }
                    if(m.Ratings != null)
                    {
                        m.Ratings.ForEach(r => r.Movie = null);
                    }
                });
                return metadata ? CreateMetadata(data) : Ok(data);
            }else{
                return metadata ? CreateMetadata(query) : Ok(query);
            }
        }

        private IActionResult CreateMetadata(IEnumerable<Movie> movies)
        {
            return Ok(new{
                data = movies,
                categories = context.Movies.Select(m => m.Category)
                    .Distinct().OrderBy(m => m)
            });
        }

        [HttpPost]
        public IActionResult CreateMovie([FromBody] MovieData mdata)
        {
            if(ModelState.IsValid)
            {
                Movie m = mdata.Movie;
                if(m.Studio != null && m.Studio.StudioId != 0)
                {
                    context.Attach(m.Studio);
                }
                context.Add(m);
                context.SaveChanges();
                return Ok(m.MovieId);
            }
            else{
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public IActionResult ReplaceMovie(long id, [FromBody] MovieData mData)
        {
            if(ModelState.IsValid){
                Movie m = mData.Movie;
                m.MovieId = id;
                if(m.Studio != null && m.Studio.StudioId != 0)
                {
                    context.Attach(m.Studio);
                }
                context.Update(m);
                context.SaveChanges();
                return Ok();
            }else{
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(long id)
        {
            context.Movies.Remove(new Movie {MovieId = id});
            context.SaveChanges();
            return Ok();
        }
        
    }
}





// private static string[] Summaries = new[]
        // {
        //     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        // };

        // [HttpGet("[action]")]
        // public IEnumerable<WeatherForecast> WeatherForecasts()
        // {
        //     var rng = new Random();
        //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //     {
        //         DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
        //         TemperatureC = rng.Next(-20, 55),
        //         Summary = Summaries[rng.Next(Summaries.Length)]
        //     });
        // }

        // public class WeatherForecast
        // {
        //     public string DateFormatted { get; set; }
        //     public int TemperatureC { get; set; }
        //     public string Summary { get; set; }

        //     public int TemperatureF
        //     {
        //         get
        //         {
        //             return 32 + (int)(TemperatureC / 0.5556);
        //         }
        //     }
        // }