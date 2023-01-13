using System;
using System.Collections.Generic;

namespace PersonalProject.Data.Models;

public partial class Patient
{
    public Guid IdPatient { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime Birthday { get; set; }

    public string Gender { get; set; } = null!;

    public Guid IdAddress { get; set; }

    public virtual Address IdAddressNavigation { get; set; } = null!;

    public virtual ICollection<PatientsHistory> PatientsHistories { get; } = new List<PatientsHistory>();
}
