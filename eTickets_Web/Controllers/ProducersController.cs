﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eTickets_Web.Data;
using eTickets_Web.Models;
using eTickets_Web.Data.Interfaces;

namespace eTickets_Web.Controllers
{
    public class ProducersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IProducersService _service;


        public ProducersController(IProducersService service)
        {
            _service = service;

        }

        // GET: Producers
        public async Task<IActionResult> Index()
        {
            var producersdata = _service.GetAll();

            return View(producersdata);

              //return _context.Producers != null ? 
              //            View(await _context.Producers.ToListAsync()) :
              //            Problem("Entity set 'AppDbContext.Producers'  is null.");
        }

        // GET: Producers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Producers == null)
            {
                return NotFound();
            }

            var producer = await _context.Producers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producer == null)
            {
                return NotFound();
            }

            return View(producer);
        }

        // GET: Producers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Producers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")] Producer producer)
        {
            if (ModelState.IsValid)
            {
                _service.Add(producer);

                return RedirectToAction(nameof(Index));
            }

            return View(producer);
        }

        // GET: Producers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Producers == null)
            {
                return NotFound();
            }

            var producer = await _context.Producers.FindAsync(id);
            if (producer == null)
            {
                return NotFound();
            }
            return View(producer);
        }

        // POST: Producers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")] Producer producer)
        {
            if (id != producer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProducerExists(producer.Id))
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
            return View(producer);
        }

        // GET: Producers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Producers == null)
            {
                return NotFound();
            }

            var producer = await _context.Producers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producer == null)
            {
                return NotFound();
            }

            return View(producer);
        }

        // POST: Producers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Producers == null)
            {
                return Problem("Entity set 'AppDbContext.Producers'  is null.");
            }
            var producer = await _context.Producers.FindAsync(id);
            if (producer != null)
            {
                _context.Producers.Remove(producer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProducerExists(int id)
        {
          return (_context.Producers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
