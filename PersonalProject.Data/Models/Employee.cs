using System;
using System.Collections.Generic;

namespace PersonalProject.Data.Models;

public partial class Employee
{
    public Guid IdEmployee { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime Birthday { get; set; }

    public string Gender { get; set; } = null!;

    public string Scholarity { get; set; } = null!;

    public Guid IdAddress { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<DoctorSchedule> DoctorSchedules { get; } = new List<DoctorSchedule>();

    public virtual Address IdAddressNavigation { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();
}
