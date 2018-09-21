using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clinique2000.Data;
using Clinique2000.Models;

namespace Clinique2000.Controllers
{
    public class medecinsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public medecinsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: medecins
        public async Task<IActionResult> Index()
        {
            return View(await _context.medecin.ToListAsync());
        }

        // GET: medecins/Details/5
      //  [Route("medecins/information")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medecin = await _context.medecin
                .FirstOrDefaultAsync(m => m.MedecinID == id);
            if (medecin == null)
            {
                return NotFound();
            }

            return View(medecin);
        }

        // GET: medecins/Create
    //    [Route("medecins/creation")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: medecins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MedecinID,Nom,Prenom,Adresse,Telephone,CodePostal,Sexe,Email,Note")] medecin medecin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medecin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medecin);
        }

        // GET: medecins/Edit/5
      //  [Route("medecins/modification")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medecin = await _context.medecin.FindAsync(id);
            if (medecin == null)
            {
                return NotFound();
            }
            return View(medecin);
        }

        // POST: medecins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MedecinID,Nom,Prenom,Adresse,Telephone,CodePostal,Sexe,Email,Note")] medecin medecin)
        {
            if (id != medecin.MedecinID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medecin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!medecinExists(medecin.MedecinID))
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
            return View(medecin);
        }

        // GET: medecins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medecin = await _context.medecin
                .FirstOrDefaultAsync(m => m.MedecinID == id);
            if (medecin == null)
            {
                return NotFound();
            }

            return View(medecin);
        }

        // POST: medecins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medecin = await _context.medecin.FindAsync(id);
            _context.medecin.Remove(medecin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool medecinExists(int id)
        {
            return _context.medecin.Any(e => e.MedecinID == id);
        }
    }
}
