using System;
using System.Collections.Generic;

namespace PersonalProject.Data.Models;

public partial class Schedule
{
    public Guid IdSchedule { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public DateTime BreakTime { get; set; }

    public string DayOfWeek { get; set; } = null!;

    public virtual ICollection<DoctorSchedule> DoctorSchedules { get; } = new List<DoctorSchedule>();
}
