using System;
using API.DTOs;
using Core.Entities;

namespace API.Extensions;

public static class AddressMappingExtensions
{
    public static AddressDto? ToDto(this Address? address)
    {
        if (address == null) return null;

        return new AddressDto
        {
            ZipCode = address.ZipCode,
            Street = address.Street,
            Number = address.Number,
            Complement = address.Complement,
            Neighborhood = address.Neighborhood,
            City = address.City,
            State = address.State,
        };
    }

    public static Address ToEntity(this AddressDto addressDto)
    {
        if (addressDto == null) throw new ArgumentException(nameof(addressDto));

        return new Address
        {
            ZipCode = addressDto.ZipCode,
            Street = addressDto.Street,
            Number = addressDto.Number,
            Complement = addressDto.Complement,
            Neighborhood = addressDto.Neighborhood,
            City = addressDto.City,
            State = addressDto.State,
        };
    }

    public static void UpdateFromDto(this Address address, AddressDto addressDto)
    {
        if (addressDto == null) throw new ArgumentException(nameof(addressDto));
        if (address == null) throw new ArgumentException(nameof(address));

        address.ZipCode = addressDto.ZipCode;
        address.Street = addressDto.Street;
        address.Number = addressDto.Number;
        address.Complement = addressDto.Complement;
        address.Neighborhood = addressDto.Neighborhood;
        address.City = addressDto.City;
        address.State = addressDto.State;
    }
}

