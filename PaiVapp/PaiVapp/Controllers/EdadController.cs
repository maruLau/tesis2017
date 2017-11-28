using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PaiVapp.Data;
using PaiVapp.Models;

namespace PaiVapp.Controllers
{
    public class EdadController : Controller
    {
        private readonly PaiVContext _context;

        public EdadController(PaiVContext context)
        {
            _context = context;
        }

        // GET: Edad
        public async Task<IActionResult> Index()
        {
            return View(await _context.Edades.ToListAsync());
        }

        // GET: Edad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var edad = await _context.Edades
                .SingleOrDefaultAsync(m => m.EdadID == id);
            if (edad == null)
            {
                return NotFound();
            }

            return View(edad);
        }

        // GET: Edad/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Edad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EdadID,NEdad,Semanas,Estado")] Edad edad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(edad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(edad);
        }

        // GET: Edad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var edad = await _context.Edades.SingleOrDefaultAsync(m => m.EdadID == id);
            if (edad == null)
            {
                return NotFound();
            }
            return View(edad);
        }

        // POST: Edad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EdadID,NEdad,Semanas,Estado")] Edad edad)
        {
            if (id != edad.EdadID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(edad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EdadExists(edad.EdadID))
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
            return View(edad);
        }

        // GET: Edad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var edad = await _context.Edades
                .SingleOrDefaultAsync(m => m.EdadID == id);
            if (edad == null)
            {
                return NotFound();
            }

            return View(edad);
        }

        // POST: Edad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var edad = await _context.Edades.SingleOrDefaultAsync(m => m.EdadID == id);
            _context.Edades.Remove(edad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EdadExists(int id)
        {
            return _context.Edades.Any(e => e.EdadID == id);
        }
    }
}
