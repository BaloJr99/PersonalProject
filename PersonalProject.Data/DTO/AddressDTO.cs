using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonalProject.Data.DTO;

public partial class AddressDTO
{
    public Guid IdAddress { get; set; }
    
    [Display(Name ="Street")]
    [Required(ErrorMessage = "Street Required")]
    public string Street { get; set; } = null!;
    
    [Display(Name ="Apartment")]
    public string? Apartment { get; set; }

    [Display(Name ="City")]
    [Required(ErrorMessage = "City Required")]
    public string City { get; set; } = null!;

    [Display(Name ="State")]
    [Required(ErrorMessage = "State Required")]
    public string State { get; set; } = null!;

    [Display(Name ="ZipCode")]
    [Required(ErrorMessage = "ZipCode Required")]
    public string ZipCode { get; set; } = null!;

    [Display(Name ="Country")]
    [Required(ErrorMessage = "Country Required")]
    public string Country { get; set; } = null!;
}
