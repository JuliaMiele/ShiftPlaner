using ShiftPlaner.Models;


namespace ShiftPlaner.Tests
{
    public class WorkShiftTests
    {
        [Fact]
        public void Duration_CalculatesNormalDayShift()
        {
            WorkShift workShift = new()
            {
                StartTime = new TimeOnly(8, 0),
                EndTime = new TimeOnly(16, 30)


            };

            TimeSpan result = workShift.Duration;

            Assert.Equal(new TimeSpan(8, 30 , 0), result);
        }

        [Fact]
        public void Duration_CalculatesShiftAcrossMidnight()
        {
            WorkShift workShift = new()
            {
                StartTime = new TimeOnly(22, 0),
                EndTime = new TimeOnly(6, 0)


            };

            TimeSpan result = workShift.Duration;
            Assert.Equal(TimeSpan.FromHours(8), result);
        }
    }
}
