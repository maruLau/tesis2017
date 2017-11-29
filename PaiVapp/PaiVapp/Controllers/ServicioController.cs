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
    public class ServicioController : Controller
    {
        private readonly PaiVContext _context;

        public ServicioController(PaiVContext context)
        {
            _context = context;
        }

        // GET: Servicio
        /*
        public async Task<IActionResult> Index()
        {
            var paiVContext = _context.Servicios.Include(s => s.CategoriaServicio).Include(s => s.Distrito).Include(s => s.RegionSanitaria);
            return View(await paiVContext.ToListAsync());
        }*/
        public async Task<IActionResult> Index(int? page)
        {

            var servicio = from p in _context.Servicios.Include(d => d.Distrito).Include(rs => rs.RegionSanitaria).Include(cat => cat.CategoriaServicio) orderby p.Estado select p;


            //cantidad de rows por pagina
            int pageSize = 10;
            return View(await PaginatedList<Servicio>.CreateAsync(servicio.AsNoTracking(), page ?? 1, pageSize));
        }

        // GET: Servicio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicio = await _context.Servicios
                .Include(s => s.CategoriaServicio)
                .Include(s => s.Distrito)
                .Include(s => s.RegionSanitaria)
                .SingleOrDefaultAsync(m => m.ServicioID == id);
            
            if (servicio.TipoServicio == 0)
            {
                ViewData["tipoS"] = "Urbano";
              
            }
            else
            {
                ViewData["tipoS"] = "Rural";
              
            }

            return View(servicio);
        }

        // GET: Servicio/Create
        public IActionResult Create()
        {
            ViewData["CategoriaServicioID"] = new SelectList(_context.CategoriaServicios, "CategoriaServicioID", "NCategoria");
            ViewData["DistritoID"] = new SelectList(_context.Distritos, "DistritoID", "NDistrito");
            ViewData["RegionSanitariaID"] = new SelectList(_context.RegionSanitarias, "RegionSanitariaID", "NRegionS");
            return View();
        }

        // POST: Servicio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServicioID,CodServicio,NServicio,Cabecera,TipoServicio,PoblacionMenor,DistanciaRS,DistritoID,RegionSanitariaID,CategoriaServicioID")] Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                servicio.Estado = true;
                _context.Add(servicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaServicioID"] = new SelectList(_context.CategoriaServicios, "CategoriaServicioID", "NCategoria", servicio.CategoriaServicioID);
            ViewData["DistritoID"] = new SelectList(_context.Distritos, "DistritoID", "NDistrito", servicio.DistritoID);
            ViewData["RegionSanitariaID"] = new SelectList(_context.RegionSanitarias, "RegionSanitariaID", "NRegionS", servicio.RegionSanitariaID);
            return View(servicio);
        }

        // GET: Servicio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicio = await _context.Servicios.SingleOrDefaultAsync(m => m.ServicioID == id);
            if (servicio == null)
            {
                return NotFound();
            }
            ViewData["CategoriaServicioID"] = new SelectList(_context.CategoriaServicios, "CategoriaServicioID", "NCategoria", servicio.CategoriaServicioID);
            ViewData["DistritoID"] = new SelectList(_context.Distritos, "DistritoID", "NDistrito", servicio.DistritoID);
            ViewData["RegionSanitariaID"] = new SelectList(_context.RegionSanitarias, "RegionSanitariaID", "NRegionS", servicio.RegionSanitariaID);
            return View(servicio);
        }

        // POST: Servicio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServicioID,CodServicio,NServicio,Cabecera,TipoServicio,PoblacionMenor,DistanciaRS,Estado,DistritoID,RegionSanitariaID,CategoriaServicioID")] Servicio servicio)
        {
            if (id != servicio.ServicioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicioExists(servicio.ServicioID))
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
            ViewData["CategoriaServicioID"] = new SelectList(_context.CategoriaServicios, "CategoriaServicioID", "NCategoria", servicio.CategoriaServicioID);
            ViewData["DistritoID"] = new SelectList(_context.Distritos, "DistritoID", "NDistrito", servicio.DistritoID);
            ViewData["RegionSanitariaID"] = new SelectList(_context.RegionSanitarias, "RegionSanitariaID", "NRegionS", servicio.RegionSanitariaID);
            return View(servicio);
        }

        // GET: Servicio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicio = await _context.Servicios
                .Include(s => s.CategoriaServicio)
                .Include(s => s.Distrito)
                .Include(s => s.RegionSanitaria)
                .SingleOrDefaultAsync(m => m.ServicioID == id);
            if (servicio == null)
            {
                return NotFound();
            }

            return View(servicio);
        }

        // POST: Servicio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servicio = await _context.Servicios.SingleOrDefaultAsync(m => m.ServicioID == id);
            servicio.Estado = false;
            _context.Servicios.Remove(servicio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicioExists(int id)
        {
            return _context.Servicios.Any(e => e.ServicioID == id);
        }
    }
}
