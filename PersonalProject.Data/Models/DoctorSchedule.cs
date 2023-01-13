using System;
using System.Collections.Generic;

namespace PersonalProject.Data.Models;

public partial class DoctorSchedule
{
    public Guid IdDoctorSchedule { get; set; }

    public Guid IdEmployee { get; set; }

    public Guid IdSchedule { get; set; }

    public virtual Schedule IdEmployeeNavigation { get; set; } = null!;

    public virtual Employee IdScheduleNavigation { get; set; } = null!;
}
