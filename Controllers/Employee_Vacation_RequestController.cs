using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EZ_Task.Data;
using EZ_Task.Models;

namespace EZ_Task.Controllers
{
    public class Employee_Vacation_RequestController : Controller
    {
        private readonly EZ_TaskContext _context;

        public Employee_Vacation_RequestController(EZ_TaskContext context)
        {
            _context = context;
        }

        // GET: Employee_Vacation_Request
        public async Task<IActionResult> Index()
        {
            var eZ_TaskContext = _context.Employee_Vacation_Request.Include(e => e.Employee).Include(e => e.Vacation);
            return View(await eZ_TaskContext.ToListAsync());
        }

        // GET: Employee_Vacation_Request/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee_Vacation_Request = await _context.Employee_Vacation_Request
                .Include(e => e.Employee)
                .Include(e => e.Vacation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee_Vacation_Request == null)
            {
                return NotFound();
            }

            return View(employee_Vacation_Request);
        }

        // GET: Employee_Vacation_Request/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Fullname");
            ViewData["VacationId"] = new SelectList(_context.Vacation, "Id", "Type");
            return View();
        }

        // POST: Employee_Vacation_Request/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartDate,EndDate,EmployeeId,VacationId")] Employee_Vacation_Request employee_Vacation_Request)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee_Vacation_Request);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Fullname", employee_Vacation_Request.EmployeeId);
            ViewData["VacationId"] = new SelectList(_context.Vacation, "Id", "Type", employee_Vacation_Request.VacationId);
            return View(employee_Vacation_Request);
        }

        // GET: Employee_Vacation_Request/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee_Vacation_Request = await _context.Employee_Vacation_Request.FindAsync(id);
            if (employee_Vacation_Request == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Fullname", employee_Vacation_Request.EmployeeId);
            ViewData["VacationId"] = new SelectList(_context.Vacation, "Id", "Type", employee_Vacation_Request.VacationId);
            return View(employee_Vacation_Request);
        }

        // POST: Employee_Vacation_Request/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartDate,EndDate,EmployeeId,VacationId")] Employee_Vacation_Request employee_Vacation_Request)
        {
            if (id != employee_Vacation_Request.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee_Vacation_Request);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Employee_Vacation_RequestExists(employee_Vacation_Request.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Fullname", employee_Vacation_Request.EmployeeId);
            ViewData["VacationId"] = new SelectList(_context.Vacation, "Id", "Type", employee_Vacation_Request.VacationId);
            return View(employee_Vacation_Request);
        }

        // GET: Employee_Vacation_Request/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee_Vacation_Request = await _context.Employee_Vacation_Request
                .Include(e => e.Employee)
                .Include(e => e.Vacation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee_Vacation_Request == null)
            {
                return NotFound();
            }

            return View(employee_Vacation_Request);
        }

        // POST: Employee_Vacation_Request/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee_Vacation_Request = await _context.Employee_Vacation_Request.FindAsync(id);
            _context.Employee_Vacation_Request.Remove(employee_Vacation_Request);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Employee_Vacation_RequestExists(int id)
        {
            return _context.Employee_Vacation_Request.Any(e => e.Id == id);
        }
    }
}
