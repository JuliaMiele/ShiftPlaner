using System.ComponentModel.DataAnnotations;

namespace ShiftPlaner.Models
{
    public class WorkShift
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Bitte wähle ein Datum aus.")]
        [Display(Name = "Datum")]
        public DateOnly Date { get; set; }
        [Required(ErrorMessage = "Bitte gib eine Startzeit an.")]
        [Display(Name = "Beginn")]
        public TimeOnly StartTime { get; set; }
        [Required(ErrorMessage = "Bitte gib eine Endzeit ein.")]
        [Display(Name = "Ende")]
        public TimeOnly EndTime { get; set; }
        [Required(ErrorMessage = "Bitte wähle einen Schichttyp aus.")]
        [Display(Name = "Schichttyp")]
        public string ShiftType { get; set; } = string.Empty;
        [Display(Name ="Notiz")]
        public string? Note { get; set; }

        [Display(Name = "Arbeitsdauer")]
        public TimeSpan Duration
        {
            get
            {
                TimeSpan duration = EndTime - StartTime;

                if (duration < TimeSpan.Zero)
                {
                    duration += TimeSpan.FromDays(1);
                }

                return duration;
            }
        }

    }
}
