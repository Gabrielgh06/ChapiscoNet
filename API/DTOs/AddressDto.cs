using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class AddressDto
{
    [Required]    
    public string ZipCode { get; set; } = string.Empty;
    [Required]
    public string Street { get; set; } = string.Empty;
    [Required]
    public string Number { get; set; } = string.Empty;

    public string? Complement { get; set; }
    [Required]
    public string Neighborhood { get; set; } = string.Empty;
    [Required]
    public string City { get; set; } = string.Empty;
    [Required]
    public string State { get; set; } = string.Empty;
}
