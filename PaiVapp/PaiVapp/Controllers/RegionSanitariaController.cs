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
    public class RegionSanitariaController : Controller
    {
        private readonly PaiVContext _context;

        public RegionSanitariaController(PaiVContext context)
        {
            _context = context;
        }

        // GET: RegionSanitaria
        /*
        public async Task<IActionResult> Index()
        {
            var paiVContext = _context.RegionSanitarias.Include(r => r.Departamento);
            return View(await paiVContext.ToListAsync());
        }*/
        public async Task<IActionResult> Index(int? page)
        {
           
            var rs = from p in _context.RegionSanitarias.Include(d => d.Departamento) orderby p.Estado select p;
 
          
            //cantidad de rows por pagina
            int pageSize = 10;
            return View(await PaginatedList<RegionSanitaria>.CreateAsync(rs.AsNoTracking(), page ?? 1, pageSize));
        }

        // GET: RegionSanitaria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regionSanitaria = await _context.RegionSanitarias
                .Include(r => r.Departamento)
                .SingleOrDefaultAsync(m => m.RegionSanitariaID == id);
            if (regionSanitaria == null)
            {
                return NotFound();
            }

            return View(regionSanitaria);
        }

        // GET: RegionSanitaria/Create
        public IActionResult Create()
        {
            ViewData["DepartamentoID"] = new SelectList(_context.Departamentos, "DepartamentoID", "NDepartamento");
            return View();
        }

        // POST: RegionSanitaria/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegionSanitariaID,CodRS,NRegionS,DepartamentoID")] RegionSanitaria regionSanitaria)
        {
            if (ModelState.IsValid)
            {
                regionSanitaria.Estado = true;
                _context.Add(regionSanitaria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartamentoID"] = new SelectList(_context.Departamentos, "DepartamentoID", "NDepartamento", regionSanitaria.DepartamentoID);
            return View(regionSanitaria);
        }

        // GET: RegionSanitaria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regionSanitaria = await _context.RegionSanitarias.SingleOrDefaultAsync(m => m.RegionSanitariaID == id);
            if (regionSanitaria == null)
            {
                return NotFound();
            }
            ViewData["DepartamentoID"] = new SelectList(_context.Departamentos, "DepartamentoID", "NDepartamento", regionSanitaria.DepartamentoID);
            return View(regionSanitaria);
        }

        // POST: RegionSanitaria/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RegionSanitariaID,CodRS,NRegionS,Estado,DepartamentoID")] RegionSanitaria regionSanitaria)
        {
            if (id != regionSanitaria.RegionSanitariaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regionSanitaria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegionSanitariaExists(regionSanitaria.RegionSanitariaID))
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
            ViewData["DepartamentoID"] = new SelectList(_context.Departamentos, "DepartamentoID", "NDepartamento", regionSanitaria.DepartamentoID);
            return View(regionSanitaria);
        }

        // GET: RegionSanitaria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regionSanitaria = await _context.RegionSanitarias
                .Include(r => r.Departamento)
                .SingleOrDefaultAsync(m => m.RegionSanitariaID == id);
            if (regionSanitaria == null)
            {
                return NotFound();
            }

            return View(regionSanitaria);
        }

        // POST: RegionSanitaria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regionSanitaria = await _context.RegionSanitarias.SingleOrDefaultAsync(m => m.RegionSanitariaID == id);
            regionSanitaria.Estado = false;
            _context.RegionSanitarias.Update(regionSanitaria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegionSanitariaExists(int id)
        {
            return _context.RegionSanitarias.Any(e => e.RegionSanitariaID == id);
        }
    }
}
