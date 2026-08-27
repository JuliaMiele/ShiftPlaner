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
    }
}