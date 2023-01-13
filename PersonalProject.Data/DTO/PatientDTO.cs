using System;
using System.Collections.Generic;

namespace PersonalProject.Data.DTO;

public partial class PatientDTO
{
    public Guid IdPatient { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime Birthday { get; set; }

    public string Gender { get; set; } = null!;

    public Guid IdAddress { get; set; }
}
