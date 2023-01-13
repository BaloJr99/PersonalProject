using System;
using System.Collections.Generic;

namespace PersonalProject.Data.Models;

public partial class User
{
    public Guid IdUser { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public string Email { get; set; } = null!;

    public Guid IdEmployee { get; set; }

    public virtual Employee IdEmployeeNavigation { get; set; } = null!;

    public virtual ICollection<PatientDiagnosis> PatientDiagnoses { get; } = new List<PatientDiagnosis>();
}
