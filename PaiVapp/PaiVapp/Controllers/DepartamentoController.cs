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
    public class DepartamentoController : Controller
    {
        private readonly PaiVContext _context;

        public DepartamentoController(PaiVContext context)
        {
            _context = context;
        }

        // GET: Departamento
        /*
        public async Task<IActionResult> Index()
        {
            var paiVContext = _context.Departamentos.Include(d => d.Pais);
            return View(await paiVContext.ToListAsync());
        }*/
        
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["DepartamentoV"] = string.IsNullOrEmpty(sortOrder) ? "departamento_desc" : "";
            ViewData["PaisV"] = string.IsNullOrEmpty(sortOrder) ? "pais_desc" : "";
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
            var departamento = from d in _context.Departamentos.Include(p=> p.Pais) select d;

            //si el buscar no viene vacio, consulta si existe algo parecido
            if (!String.IsNullOrEmpty(searchString))
            {
                departamento = departamento.Where(d => d.NDepartamento.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "depart_desc":
                    departamento = departamento.OrderByDescending(d => d.NDepartamento);
               break;
                case "pais_desc":
                    departamento = departamento.OrderByDescending(d => d.Pais.NPais);
                    break;
                case "cod_desc":
                    departamento = departamento.OrderByDescending(d => d.CodDepartamento);
                    break;
                default:
                    departamento = departamento.OrderBy(d => d.CodDepartamento);
               break;
            }
            //cantidad de rows por pagina
            int pageSize = 10;
            return View(await PaginatedList<Departamento>.CreateAsync(departamento.AsNoTracking(), page ?? 1, pageSize));
        }

        // GET: Departamento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamentos
                .Include(d => d.Pais)
                .SingleOrDefaultAsync(m => m.DepartamentoID == id);
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        // GET: Departamento/Create
        public IActionResult Create()
        {
            var query = from p in _context.Paises where p.Estado.Equals(true) select p;
            ViewData["PaisID"] = new SelectList(query, "PaisID", "NPais");
            return View();
        }

        // POST: Departamento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartamentoID,CodDepartamento,NDepartamento,PaisID")] Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                departamento.Estado = true;
                _context.Add(departamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaisID"] = new SelectList(_context.Paises, "PaisID", "NPais", departamento.PaisID);
            return View(departamento);
        }

        // GET: Departamento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamentos.SingleOrDefaultAsync(m => m.DepartamentoID == id);
            if (departamento == null)
            {
                return NotFound();
            }
            ViewData["PaisID"] = new SelectList(_context.Paises, "PaisID", "NPais", departamento.PaisID);
            return View(departamento);
        }

        // POST: Departamento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DepartamentoID,CodDepartamento,NDepartamento,Estado,PaisID")] Departamento departamento)
        {
            if (id != departamento.DepartamentoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartamentoExists(departamento.DepartamentoID))
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
            ViewData["PaisID"] = new SelectList(_context.Paises, "PaisID", "NPais", departamento.PaisID);
            return View(departamento);
        }

        // GET: Departamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamentos
                .Include(d => d.Pais)
                .SingleOrDefaultAsync(m => m.DepartamentoID == id);
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        // POST: Departamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departamento = await _context.Departamentos.SingleOrDefaultAsync(m => m.DepartamentoID == id);
            departamento.Estado = false;
            _context.Departamentos.Update(departamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartamentoExists(int id)
        {
            return _context.Departamentos.Any(e => e.DepartamentoID == id);
        }
    }
}
