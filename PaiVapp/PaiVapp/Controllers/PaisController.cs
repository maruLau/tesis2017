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
    public class PaisController : Controller
    {
        private readonly PaiVContext _context;

        public PaisController(PaiVContext context)
        {
            _context = context;
        }
        /*
        // GET: Pais ORIGINAL INDEX
        public async Task<IActionResult> Index()
        {
            return View(await _context.Paises.ToListAsync());
        }*/
        //Get: Pais
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["PaisSort"] = string.IsNullOrEmpty(sortOrder) ? "pais_desc" : "";
            if(searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            var paises = from p in _context.Paises select p;
            //si el buscar no viene vacio, consulta si existe algo parecido
            if (!String.IsNullOrEmpty(searchString))
            {
                paises = paises.Where(p => p.NPais.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "pais_desc":
                    paises = paises.OrderByDescending(p => p.NPais);
                    break;
                default:
                    paises = paises.OrderBy(p => p.NPais);
                    break;
            }
            //cantidad de rows por pagina
            int pageSize = 10;
            return View(await PaginatedList<Pais>.CreateAsync(paises.AsNoTracking(), page ?? 1, pageSize));
        }
        // GET: Pais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pais = await _context.Paises
                .SingleOrDefaultAsync(m => m.ID == id);
            if (pais == null)
            {
                return NotFound();
            }

            return View(pais);
        }

        // GET: Pais/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NPais")] Pais pais)
        {
            pais.Estado = true;
            if (ModelState.IsValid)
            {
                _context.Add(pais);
              
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pais);
        }

        // GET: Pais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
       
            var pais = await _context.Paises.SingleOrDefaultAsync(m => m.ID == id);
        
            if (pais == null)
            {
                return NotFound();
            }
            return View(pais);
        }

        // POST: Pais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NPais, Estado")] Pais pais)
        {

            if (id != pais.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pais);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaisExists(pais.ID))
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
            return View(pais);
        }

        // GET: Pais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pais = await _context.Paises.SingleOrDefaultAsync(m => m.ID == id);
            if (pais == null)
            {
                return NotFound();
            }

            return View(pais);
        }

        // POST: Pais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var pais = await _context.Paises.SingleOrDefaultAsync(m => m.ID == id);
            pais.Estado = false;
            _context.Update(pais);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaisExists(int id)
        {
            return _context.Paises.Any(e => e.ID == id);
        }
    }
}
