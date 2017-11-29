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
    public class BiologicoController : Controller
    {
        private readonly PaiVContext _context;

        public BiologicoController(PaiVContext context)
        {
            _context = context;
        }

        // GET: Biologico
        /*
        public async Task<IActionResult> Index()
        {
            return View(await _context.Biologicos.ToListAsync());
        }*/
        public async Task<IActionResult> Index(int? page)
        {

            var b = from p in _context.Biologicos orderby p.Estado select p;


            //cantidad de rows por pagina
            int pageSize = 10;
            return View(await PaginatedList<Biologico>.CreateAsync(b.AsNoTracking(), page ?? 1, pageSize));
        }

        // GET: Biologico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biologico = await _context.Biologicos
                .SingleOrDefaultAsync(m => m.BiologicoID == id);
            if (biologico == null)
            {
                return NotFound();
            }

            return View(biologico);
        }

        // GET: Biologico/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Biologico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BiologicoID,NBiologico,Descripcion")] Biologico biologico)
        {
            if (ModelState.IsValid)
            {
                biologico.Estado = true;
                _context.Add(biologico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(biologico);
        }

        // GET: Biologico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biologico = await _context.Biologicos.SingleOrDefaultAsync(m => m.BiologicoID == id);
            if (biologico == null)
            {
                return NotFound();
            }
            return View(biologico);
        }

        // POST: Biologico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BiologicoID,NBiologico,Descripcion,Estado")] Biologico biologico)
        {
            if (id != biologico.BiologicoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(biologico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BiologicoExists(biologico.BiologicoID))
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
            return View(biologico);
        }

        // GET: Biologico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biologico = await _context.Biologicos
                .SingleOrDefaultAsync(m => m.BiologicoID == id);
            if (biologico == null)
            {
                return NotFound();
            }

            return View(biologico);
        }

        // POST: Biologico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var biologico = await _context.Biologicos.SingleOrDefaultAsync(m => m.BiologicoID == id);
            biologico.Estado = false;
            _context.Biologicos.Remove(biologico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BiologicoExists(int id)
        {
            return _context.Biologicos.Any(e => e.BiologicoID == id);
        }
    }
}
