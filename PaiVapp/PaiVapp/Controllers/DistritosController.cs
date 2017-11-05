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
    public class DistritosController : Controller
    {
        private readonly PaiVContext _context;

        public DistritosController(PaiVContext context)
        {
            _context = context;
        }

        // GET: Distritos
        public async Task<IActionResult> Index()
        {
            var distritos = from s in _context.Distritos.Include(d => d.Departamento.NDepartamento) select s;
            return View(await _context.Distritos.OrderBy(s => s.CodDistrito).ToListAsync());
           
        }

        // GET: Distritos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distrito = await _context.Distritos
                .SingleOrDefaultAsync(m => m.ID == id);
            if (distrito == null)
            {
                return NotFound();
            }

            return View(distrito);
        }
        private void PopulateDptoDropDownList(object selectDpto = null)
        {
            var dptoD = from d in _context.Departamentos.Include(p=>p.Pais)
                            orderby d.CodDepartamento
                            select d;
            ViewBag.DepartamentoID = new SelectList(dptoD.AsNoTracking(), "ID",  "NDepartamento", selectDpto);
        }
        // GET: Distritos/Create
        public IActionResult Create()
        {
            PopulateDptoDropDownList();
            return View();
        }

        // POST: Distritos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CodDistrito,NDistrito,DepartamentoID")] Distrito distrito)
        {
            if (ModelState.IsValid)
            {
                _context.Add(distrito);
                distrito.Estado = true;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(distrito);
        }

        // GET: Distritos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distrito = await _context.Distritos.SingleOrDefaultAsync(m => m.ID == id);
            if (distrito == null)
            {
                return NotFound();
            }
            PopulateDptoDropDownList(distrito.Departamento.ID);
            return View(distrito);
        }

        // POST: Distritos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CodDistrito,NDistrito,Estado,DepartamentoID")] Distrito distrito)
        {
            if (id != distrito.ID)
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
                    if (!DistritoExists(distrito.ID))
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
            return View(distrito);
        }

        // GET: Distritos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distrito = await _context.Distritos
                .SingleOrDefaultAsync(m => m.ID == id);
            if (distrito == null)
            {
                return NotFound();
            }

            return View(distrito);
        }

        // POST: Distritos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var distrito = await _context.Distritos.SingleOrDefaultAsync(m => m.ID == id);
            distrito.Estado = false;
            _context.Update(distrito);
            //_context.Distritos.Remove(distrito);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DistritoExists(int id)
        {
            return _context.Distritos.Any(e => e.ID == id);
        }
    }
}
