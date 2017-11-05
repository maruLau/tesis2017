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
    public class DepartamentosController : Controller
    {
        private PaiVContext _context = new PaiVContext(); 

        public DepartamentosController(PaiVContext context)
        {
            _context = context;
        }

        // GET: Departamentos
        /*
        public async Task<IActionResult> Index()
        {
            var departamentos = from s in _context.Departamentos.Include(d =>d.Pais.NPais) select s;
            return View(await _context.Departamentos.OrderBy(s=> s.CodDepartamento).ToListAsync());
        }*/
        //Get: Pais
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewData["DptoSort"] = sortOrder;
            ViewData["PaisSort"] = sortOrder;
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            var departamentos = from d in _context.Departamentos select d;
            //si el buscar no viene vacio, consulta si existe algo parecido
            if (!String.IsNullOrEmpty(searchString))
            {
                departamentos = departamentos.Where(d => d.NDepartamento.Contains(searchString) ||  d.Pais.NPais.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "dpto_desc":
                    departamentos = departamentos.OrderByDescending(d => d.CodDepartamento);
                    break;
                case "pais_desc":

                    break;
                default:
                    departamentos = departamentos.OrderBy(p => p.Pais.NPais);
                    break;
            }
            int pageSize = 3;
            return View(await PaginatedList<Departamento>.CreateAsync(departamentos.AsNoTracking(), page ?? 1, pageSize));
        }

        // GET: Departamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamentos
                .SingleOrDefaultAsync(m => m.ID == id);
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }
        private void PopulatePaisDropDownList(object selectPais = null)
        {
            var paisQuery = from d in _context.Paises
                                   orderby d.NPais
                                   select d;
            ViewBag.PaisID = new SelectList(paisQuery.AsNoTracking(), "ID", "NPais",  selectPais);
        }
        // GET: Departamentos/Create
        public IActionResult Create()
        {
            PopulatePaisDropDownList();
            
            return View();
        }

        // POST: Departamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("ID,CodDepartamento,NDepartamento, PaisID")] Departamento departamento)
        {
            departamento.Estado = true;
            if (ModelState.IsValid)
            {
                _context.Add(departamento);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            PopulatePaisDropDownList(departamento.Pais);
            
            return View(departamento);
        }

        // GET: Departamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           
            var departamento = await _context.Departamentos
                .Include(i=>i.Pais)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);
            if (departamento == null)
            {
                return NotFound();
            }
            PopulatePaisDropDownList(departamento.Pais);
            return View(departamento);
        }

        // POST: Departamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CodDepartamento, NDepartamento, PaisID,Estado")] Departamento departamento)
        {
            if (id != departamento.ID)
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
                    if (!DepartamentoExists(departamento.ID))
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
            return View(departamento);
        }


        // GET: Departamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamentos
                .SingleOrDefaultAsync(m => m.ID == id);
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        // POST: Departamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departamento = await _context.Departamentos.SingleOrDefaultAsync(m => m.ID == id);
            departamento.Estado = false;
            _context.Update(departamento);
          //  _context.Departamentos.Remove(departamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartamentoExists(int id)
        {
            return _context.Departamentos.Any(e => e.ID == id);
        }
    }
}
