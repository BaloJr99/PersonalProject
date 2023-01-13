using System;
using System.Collections.Generic;

namespace PersonalProject.Data.Models;

public partial class Address
{
    public Guid IdAddress { get; set; }

    public string Street { get; set; } = null!;

    public string? Apartment { get; set; }

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public string Country { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();

    public virtual ICollection<Patient> Patients { get; } = new List<Patient>();
}
