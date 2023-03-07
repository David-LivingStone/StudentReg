using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentReg.Data;
using StudentReg.Models;

namespace StudentReg.Controllers
{
    public class RegistrationsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public RegistrationsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Registrations
        public async Task<IActionResult> Index()
        {
              return View(await _context.registrations.ToListAsync());
        }

        // GET: Registrations/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.registrations == null)
            {
                return NotFound();
            }

            var registration = await _context.registrations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registration == null)
            {
                return NotFound();
            }

            return View(registration);
        }

        // GET: Registrations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Registrations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Firstname,Lastname,Othernames,Department,Faculty,Level,Phone,Gender,CreatedDateTime")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                registration.Id = Guid.NewGuid();
                _context.Add(registration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registration);
        }

        // GET: Registrations/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.registrations == null)
            {
                return NotFound();
            }

            var registration = await _context.registrations.FindAsync(id);
            if (registration == null)
            {
                return NotFound();
            }
            return View(registration);
        }

        // POST: Registrations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Firstname,Lastname,Othernames,Department,Faculty,Level,Phone,Gender,CreatedDateTime")] Registration registration)
        {
            if (id != registration.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistrationExists(registration.Id))
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
            return View(registration);
        }

        // GET: Registrations/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.registrations == null)
            {
                return NotFound();
            }

            var registration = await _context.registrations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registration == null)
            {
                return NotFound();
            }

            return View(registration);
        }

        // POST: Registrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.registrations == null)
            {
                return Problem("Entity set 'ApplicationDBContext.registrations'  is null.");
            }
            var registration = await _context.registrations.FindAsync(id);
            if (registration != null)
            {
                _context.registrations.Remove(registration);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistrationExists(Guid id)
        {
          return _context.registrations.Any(e => e.Id == id);
        }
    }
}
