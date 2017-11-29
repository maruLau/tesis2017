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
    public class DosisController : Controller
    {
        private readonly PaiVContext _context;

        public DosisController(PaiVContext context)
        {
            _context = context;
        }

        // GET: Dosis
        /*public async Task<IActionResult> Index()
        {
            return View(await _context.Dosis.ToListAsync());
        }*/
        public async Task<IActionResult> Index(int? page)
        {

            var dosis = from p in _context.Dosis orderby p.Estado select p;


            //cantidad de rows por pagina
            int pageSize = 10;
            return View(await PaginatedList<Dosis>.CreateAsync(dosis.AsNoTracking(), page ?? 1, pageSize));
        }

        // GET: Dosis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dosis = await _context.Dosis
                .SingleOrDefaultAsync(m => m.DosisID == id);
            if (dosis == null)
            {
                return NotFound();
            }

            return View(dosis);
        }

        // GET: Dosis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dosis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DosisID,NDosis")] Dosis dosis)
        {
            if (ModelState.IsValid)
            {
                dosis.Estado = true;
                _context.Add(dosis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dosis);
        }

        // GET: Dosis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dosis = await _context.Dosis.SingleOrDefaultAsync(m => m.DosisID == id);
            if (dosis == null)
            {
                return NotFound();
            }
            return View(dosis);
        }

        // POST: Dosis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DosisID,NDosis,Estado")] Dosis dosis)
        {
            if (id != dosis.DosisID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dosis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DosisExists(dosis.DosisID))
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
            return View(dosis);
        }

        // GET: Dosis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dosis = await _context.Dosis
                .SingleOrDefaultAsync(m => m.DosisID == id);
            if (dosis == null)
            {
                return NotFound();
            }

            return View(dosis);
        }

        // POST: Dosis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dosis = await _context.Dosis.SingleOrDefaultAsync(m => m.DosisID == id);
            dosis.Estado = false;
            _context.Dosis.Remove(dosis);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DosisExists(int id)
        {
            return _context.Dosis.Any(e => e.DosisID == id);
        }
    }
}
