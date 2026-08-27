using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShiftPlaner.Data;
using ShiftPlaner.Models;

namespace ShiftPlaner.Controllers
{
    public class WorkShiftsController : Controller
    {
        private readonly AppDbContext _context;

        public WorkShiftsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<WorkShift> workShifts = await _context.WorkShifts
                .OrderBy(workShift => workShift.Date)
                .ThenBy(workShift => workShift.StartTime)
                .ToListAsync();

            return View(workShifts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WorkShift workShift)
        {
            if (!ModelState.IsValid)
            {
                return View(workShift);
            }

            _context.WorkShifts.Add(workShift);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            WorkShift? workShift = await _context.WorkShifts.FindAsync(id);

            if (workShift == null)
            {
                return NotFound();
            }

            return View(workShift);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, WorkShift workShift)
        {
            if (id != workShift.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(workShift);
            }

            _context.WorkShifts.Update(workShift);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}