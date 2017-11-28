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
    public class DosisBiologicoController : Controller
    {
        private readonly PaiVContext _context;

        public DosisBiologicoController(PaiVContext context)
        {
            _context = context;
        }

        // GET: DosisBiologico
        public async Task<IActionResult> Index()
        {
            var paiVContext = _context.DosisBiologicos.Include(d => d.Biologico).Include(d => d.Dosis).Include(d => d.Edad);
            return View(await paiVContext.ToListAsync());
        }

        // GET: DosisBiologico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dosisBiologico = await _context.DosisBiologicos
                .Include(d => d.Biologico)
                .Include(d => d.Dosis)
                .Include(d => d.Edad)
                .SingleOrDefaultAsync(m => m.DosisBiologicoID == id);
            if (dosisBiologico == null)
            {
                return NotFound();
            }

            return View(dosisBiologico);
        }

        // GET: DosisBiologico/Create
        public IActionResult Create()
        {
            ViewData["BiologicoID"] = new SelectList(_context.Biologicos, "BiologicoID", "BiologicoID");
            ViewData["DosisID"] = new SelectList(_context.Dosis, "DosisID", "DosisID");
            ViewData["EdadID"] = new SelectList(_context.Edades, "EdadID", "EdadID");
            return View();
        }

        // POST: DosisBiologico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DosisBiologicoID,EdadID,BiologicoID,DosisID,Descripcion")] DosisBiologico dosisBiologico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dosisBiologico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BiologicoID"] = new SelectList(_context.Biologicos, "BiologicoID", "BiologicoID", dosisBiologico.BiologicoID);
            ViewData["DosisID"] = new SelectList(_context.Dosis, "DosisID", "DosisID", dosisBiologico.DosisID);
            ViewData["EdadID"] = new SelectList(_context.Edades, "EdadID", "EdadID", dosisBiologico.EdadID);
            return View(dosisBiologico);
        }

        // GET: DosisBiologico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dosisBiologico = await _context.DosisBiologicos.SingleOrDefaultAsync(m => m.DosisBiologicoID == id);
            if (dosisBiologico == null)
            {
                return NotFound();
            }
            ViewData["BiologicoID"] = new SelectList(_context.Biologicos, "BiologicoID", "BiologicoID", dosisBiologico.BiologicoID);
            ViewData["DosisID"] = new SelectList(_context.Dosis, "DosisID", "DosisID", dosisBiologico.DosisID);
            ViewData["EdadID"] = new SelectList(_context.Edades, "EdadID", "EdadID", dosisBiologico.EdadID);
            return View(dosisBiologico);
        }

        // POST: DosisBiologico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DosisBiologicoID,EdadID,BiologicoID,DosisID,Descripcion")] DosisBiologico dosisBiologico)
        {
            if (id != dosisBiologico.DosisBiologicoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dosisBiologico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DosisBiologicoExists(dosisBiologico.DosisBiologicoID))
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
            ViewData["BiologicoID"] = new SelectList(_context.Biologicos, "BiologicoID", "BiologicoID", dosisBiologico.BiologicoID);
            ViewData["DosisID"] = new SelectList(_context.Dosis, "DosisID", "DosisID", dosisBiologico.DosisID);
            ViewData["EdadID"] = new SelectList(_context.Edades, "EdadID", "EdadID", dosisBiologico.EdadID);
            return View(dosisBiologico);
        }

        // GET: DosisBiologico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dosisBiologico = await _context.DosisBiologicos
                .Include(d => d.Biologico)
                .Include(d => d.Dosis)
                .Include(d => d.Edad)
                .SingleOrDefaultAsync(m => m.DosisBiologicoID == id);
            if (dosisBiologico == null)
            {
                return NotFound();
            }

            return View(dosisBiologico);
        }

        // POST: DosisBiologico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dosisBiologico = await _context.DosisBiologicos.SingleOrDefaultAsync(m => m.DosisBiologicoID == id);
            _context.DosisBiologicos.Remove(dosisBiologico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DosisBiologicoExists(int id)
        {
            return _context.DosisBiologicos.Any(e => e.DosisBiologicoID == id);
        }
    }
}
