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

namespace eTickets_Web.Controllers
{
    // Bu controllerın injecte edilmiş Identity alt-yapısını kullanabilmesini sağlamak ve bizim kendi yapımızla UserRoles.cs birleştirebilmek için
    [Authorize(Roles =UserRoles.Admin)]

    public class ActorsController : Controller
    {
        private readonly AppDbContext _context;

        // artık olayı genel yapıdan servis yapısına döndüreceğim için
        // genel context yapısını kullanmak yerine zaten servis üzerinde tanımlanmış sekilde IActorsService yapısısı kullan.
        private readonly IActorsService _service;

        //public ActorsController(AppDbContext context)
        public ActorsController(IActorsService service)
        {
            _service = service;
        }

        // GET: Actors
        [AllowAnonymous] // Herhangi bir yetkilendirme kullanılmıyor.
        public async Task<IActionResult> Index()
        {
            // Actor tablosunu Db tarafından okuyup View tarafına gönderiyor. 

            //var actorsdata = _context.Actors.ToList();
            var actorsdata = _service.GetAll(); 

            return View(actorsdata); // actorsdata içeriğini gönder

              //return _context.Actors != null ? 
              //            View(await _context.Actors.ToListAsync()) :
              //            Problem("Entity set 'AppDbContext.Actors'  is null.");
        }

        // GET: Actors/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _context.Actors == null)
            {
                return NotFound();
            }

            var actor = await _context.Actors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }

        // GET: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Actors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // Create View tarafından gönderilen veriyi burası yakalıyor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProfilePictureURL,FullName,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                // Modelim uygyun değilse varolan ekran yine ekranda kalacak
                return View(actor);
            }

            //_context.Add(actor);
            _service.Add(actor);

            //await _context.SaveChangesAsync(); zaten servisin altında var

            return RedirectToAction(nameof(Index));

        }

        // GET: Actors/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            // Eski yapı
            //if (id == null || _context.Actors == null)
            //{
            //    return NotFound();
            //}

            //var actor = await _context.Actors.FindAsync(id);
            //if (actor == null)
            //{
            //    return NotFound();
            //}
            //return View(actor);


            var actorDetails = _service.GetById(id);

            if (actorDetails == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(actorDetails);
            }

        }

        // POST: Actors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")] Actor actor)
        {
            if (id != actor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActorExists(actor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(actor);
        }

        // GET: Actors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Actors == null)
            {
                return NotFound();
            }

            var actor = await _context.Actors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }

        // POST: Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Actors == null)
            {
                return Problem("Entity set 'AppDbContext.Actors'  is null.");
            }
            var actor = await _context.Actors.FindAsync(id);
            if (actor != null)
            {
                _context.Actors.Remove(actor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActorExists(int id)
        {
          return (_context.Actors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
