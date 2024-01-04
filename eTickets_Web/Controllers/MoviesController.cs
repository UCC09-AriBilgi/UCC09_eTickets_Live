using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eTickets_Web.Data;
using eTickets_Web.Models;
using Microsoft.AspNetCore.Authorization;
using eTickets_Web.Data.Static;
using eTickets_Web.Data.Interfaces;
using eTickets_Web.Data.ViewModels;

namespace eTickets_Web.Controllers
{
    [Authorize(Roles =UserRoles.Admin)]

    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;
        private readonly AppDbContext _context;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }

        // GET: Movies
        [AllowAnonymous] // Bu Index sayfasına herkes ulaşabilir
        public async Task<IActionResult> Index()
        {
            //var movieList = _context.Movies
            //    .Include(m => m.Cinema)
            //    .Include(m => m.Producer);

            //return View(await movieList.ToListAsync());

            var allmovies = _service.GetAll(c => c.Cinema); // Include yapısı içerecek. EntityBaseRepository.cs altında

            return View(allmovies);

        }

        // Movies ler için arama işlemi
        [AllowAnonymous]
        public IActionResult Filter(string searchString)
        {
            var allMovies = _service.GetAll(n => n.Cinema);

            // Bana gelen parametre-searchString boş/dolu mu
            if (!string.IsNullOrEmpty(searchString))
            {
                // asağıda LINQ yapısı kullanılıyor.
                // Movie adı ve description ı üzerinde arama işlemi
                var filteredResultNew=allMovies.Where(n=> string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString,StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index",filteredResultNew);
            }

            // eğer parametre boş geliyorsa tüm filmleri listele

            return View("Index", allMovies);

        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int id)
        {
            // Eski yapı
            //if (id == null || _context.Movies == null)
            //{
            //    return NotFound();
            //}

            //var movie = await _context.Movies
            //    .Include(m => m.Cinema)
            //    .Include(m => m.Producer)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (movie == null)
            //{
            //    return NotFound();
            //}

            //return View(movie);

            var movieDetail = _service.GetMovieById(id);

            return View(movieDetail);
        }

        // Create işlemini sadece admin yetkisine sahip olan kullanıcı yapabilecektir.
        // GET: Movies/Create
        public IActionResult Create()
        {
            var movieDropdownData = _service.GetNewMovieDropdownsValues(); // movie servisinde olacak

            // ekranda görüleek select lerim
            ViewBag.Cinemas=new SelectList(movieDropdownData.Cinemas,"Id","Name");
            ViewBag.Producers=new SelectList(movieDropdownData.Producers,"Id","FullName");
            ViewBag.Actors=new SelectList(movieDropdownData.Actors,"Id","FullName");

            //ViewData["CinemaId"] = new SelectList(_context.Cinemas, "Id", "Name");
            //ViewData["ProducerId"] = new SelectList(_context.Producers, "Id", "Bio");

            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = _service.GetNewMovieDropdownsValues();

                // ekranda görüleek select lerim
                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

                return View(movie);
            }

            _service.AddNewMovie(movie);

            return RedirectToAction(nameof(Index));

        }

        // Edit kısmını da sadece admin yapabilir.
        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails=_service.GetMovieById(id);

            if (movieDetails == null)
            {
                return View("NotFound");
            }

            // üzerinde değişklik yapılma
            var response = new NewMovieVM()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                ImageURL = movieDetails.ImageURL,
                MovieCategory = movieDetails.MovieCategory,
                CinemaId = movieDetails.CinemaId,
                ProducerId = movieDetails.ProducerId,
                ActorIds = movieDetails.Actors_Movies.Select(n => n.ActorId).ToList()
            };

            var movieDropdownsData = _service.GetNewMovieDropdownsValues();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View(response);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
            if (id != movie.Id)
            {
                return View("NotFound"); // eğer ilgili movie değilsse
            }

            if (!ModelState.IsValid)
            {
                var movieDropdownsData = _service.GetNewMovieDropdownsValues();

                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

                return View(movie);

            }

            _service.UpdateMovie(movie); // view dan gelen data postalanıyor.

            return RedirectToAction(nameof(Index));


            // Old
            //if (id != movie.Id)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(movie);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!MovieExists(movie.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["CinemaId"] = new SelectList(_context.Cinemas, "Id", "Name", movie.CinemaId);
            //ViewData["ProducerId"] = new SelectList(_context.Producers, "Id", "Bio", movie.ProducerId);
            //return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .Include(m => m.Cinema)
                .Include(m => m.Producer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Movies == null)
            {
                return Problem("Entity set 'AppDbContext.Movies'  is null.");
            }
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
          return (_context.Movies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
