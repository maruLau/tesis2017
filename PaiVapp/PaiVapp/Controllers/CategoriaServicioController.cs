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
    public class CategoriaServicioController : Controller
    {
        private readonly PaiVContext _context;

        public CategoriaServicioController(PaiVContext context)
        {
            _context = context;
        }

        // GET: CategoriaServicio
        /*
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoriaServicios.ToListAsync());
        }*/
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["CatS"] = string.IsNullOrEmpty(sortOrder) ? "cat_desc" : "";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            var categoria = from c in _context.CategoriaServicios orderby c.NCategoria select c;
            //si el buscar no viene vacio, consulta si existe algo parecido
            if (!String.IsNullOrEmpty(searchString))
            {
                categoria = categoria.Where(c => c.Descripcion.Contains(searchString)).OrderByDescending(p => p.Estado);
            }
            switch (sortOrder)
            {
                case "cat_desc":
                    categoria = categoria.OrderByDescending(c=> c.Descripcion);
                    break;
                default:
                    categoria = categoria.OrderBy(c=> c.NCategoria );
                    break;
            }
            //cantidad de rows por pagina
            int pageSize = 10;
            return View(await PaginatedList<CategoriaServicio>.CreateAsync(categoria.AsNoTracking(), page ?? 1, pageSize));
        }

        // GET: CategoriaServicio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaServicio = await _context.CategoriaServicios
                .SingleOrDefaultAsync(m => m.CategoriaServicioID == id);
            if (categoriaServicio == null)
            {
                return NotFound();
            }

            return View(categoriaServicio);
        }

        // GET: CategoriaServicio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaServicio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoriaServicioID,NCategoria,Descripcion")] CategoriaServicio categoriaServicio)
        {
            if (ModelState.IsValid)
            {
                categoriaServicio.Estado = true;
                _context.Add(categoriaServicio);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaServicio);
        }

        // GET: CategoriaServicio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaServicio = await _context.CategoriaServicios.SingleOrDefaultAsync(m => m.CategoriaServicioID == id);
            if (categoriaServicio == null)
            {
                return NotFound();
            }
            return View(categoriaServicio);
        }

        // POST: CategoriaServicio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoriaServicioID,NCategoria,Descripcion,Estado")] CategoriaServicio categoriaServicio)
        {
            if (id != categoriaServicio.CategoriaServicioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaServicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaServicioExists(categoriaServicio.CategoriaServicioID))
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
            return View(categoriaServicio);
        }

        // GET: CategoriaServicio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaServicio = await _context.CategoriaServicios
                .SingleOrDefaultAsync(m => m.CategoriaServicioID == id);
            if (categoriaServicio == null)
            {
                return NotFound();
            }

            return View(categoriaServicio);
        }

        // POST: CategoriaServicio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriaServicio = await _context.CategoriaServicios.SingleOrDefaultAsync(m => m.CategoriaServicioID == id);
            _context.CategoriaServicios.Remove(categoriaServicio);
            categoriaServicio.Estado = false;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaServicioExists(int id)
        {
            return _context.CategoriaServicios.Any(e => e.CategoriaServicioID == id);
        }
    }
}
