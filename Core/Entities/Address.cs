using System;

namespace Core.Entities;

public class Address : BaseEntity
{
    public required string ZipCode { get; set; } // zip_code
    public required string Street { get; set; } // street_name
    public required string Number { get; set; } // street_number
    public string? Complement { get; set; } // (opcional)
    public required string Neighborhood { get; set; } // neighborhood
    public required string City { get; set; } // city
    public required string State { get; set; } // federal_unit (UF: "SP", "RJ", etc.)
}
