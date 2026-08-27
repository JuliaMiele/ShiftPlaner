using Microsoft.EntityFrameworkCore;
using ShiftPlaner.Models;

namespace ShiftPlaner.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<WorkShift> WorkShifts { get; set; }
    }
}