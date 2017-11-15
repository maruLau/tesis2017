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
    public class DistritoController : Controller
    {
        private readonly PaiVContext _context;

        public DistritoController(PaiVContext context)
        {
            _context = context;
        }

        // GET: Distrito
        /*
        public async Task<IActionResult> Index()
        {
            var paiVContext = _context.Distritos.Include(d => d.Departamento);
            return View(await paiVContext.ToListAsync());
        }*/

        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["DepartamentoV"] = string.IsNullOrEmpty(sortOrder) ? "dep_desc" : "";
            ViewData["DistritoV"] = string.IsNullOrEmpty(sortOrder) ? "dist_desc" : "";
            ViewData["CodV"] = string.IsNullOrEmpty(sortOrder) ? "cod_desc" : "";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            var distrito = from d in _context.Distritos.Include(d => d.Departamento) select d;

            //si el buscar no viene vacio, consulta si existe algo parecido
            if (!String.IsNullOrEmpty(searchString))
            {
                distrito = distrito.Where(d => d.NDistrito.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "dist_desc":
                    distrito = distrito.OrderByDescending(d => d.NDistrito);
                    break;
                case "dep_desc":
                    distrito = distrito.OrderByDescending(d => d.Departamento.NDepartamento);
                    break;
                case "cod_desc":
                    distrito = distrito.OrderByDescending(d => d.CodDistrito);
                    break;
                default:
                    distrito = distrito.OrderBy(d => d.CodDistrito);
                    break;
            }
            //cantidad de rows por pagina
            int pageSize = 10;
            return View(await PaginatedList<Distrito>.CreateAsync(distrito.AsNoTracking(), page ?? 1, pageSize));
        }

        // GET: Distrito/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distrito = await _context.Distritos
                .Include(d => d.Departamento)
                .SingleOrDefaultAsync(m => m.DistritoID == id);
            if (distrito == null)
            {
                return NotFound();
            }

            return View(distrito);
        }

        // GET: Distrito/Create
        public IActionResult Create()
        {
            var query = from d in _context.Departamentos join p in _context.Paises on d.PaisID equals p.PaisID
                        where p.Estado.Equals(true) && d.Estado.Equals(true) select d;
            ViewData["DepartamentoID"] = new SelectList(query, "DepartamentoID",  "NDepartamento");
            return View();
        }

        // POST: Distrito/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DistritoID,CodDistrito,NDistrito,DepartamentoID")] Distrito distrito)
        {
            if (ModelState.IsValid)
            {
                distrito.Estado = true;
                _context.Add(distrito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartamentoID"] = new SelectList(_context.Departamentos, "DepartamentoID", "NDepartamento", distrito.DepartamentoID);
            return View(distrito);
        }

        // GET: Distrito/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distrito = await _context.Distritos.SingleOrDefaultAsync(m => m.DistritoID == id);
            if (distrito == null)
            {
                return NotFound();
            }
            ViewData["DepartamentoID"] = new SelectList(_context.Departamentos, "DepartamentoID", "NDepartamento", distrito.DepartamentoID);
            return View(distrito);
        }

        // POST: Distrito/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DistritoID,CodDistrito,NDistrito,Estado,DepartamentoID")] Distrito distrito)
        {
            if (id != distrito.DistritoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(distrito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DistritoExists(distrito.DistritoID))
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
            ViewData["DepartamentoID"] = new SelectList(_context.Departamentos, "DepartamentoID", "NDepartamento", distrito.DepartamentoID);
            return View(distrito);
        }

        // GET: Distrito/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distrito = await _context.Distritos
                .Include(d => d.Departamento)
                .SingleOrDefaultAsync(m => m.DistritoID == id);
            if (distrito == null)
            {
                return NotFound();
            }

            return View(distrito);
        }

        // POST: Distrito/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var distrito = await _context.Distritos.SingleOrDefaultAsync(m => m.DistritoID == id);
            distrito.Estado = false;
            _context.Distritos.Update(distrito);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DistritoExists(int id)
        {
            return _context.Distritos.Any(e => e.DistritoID == id);
        }
    }
}
