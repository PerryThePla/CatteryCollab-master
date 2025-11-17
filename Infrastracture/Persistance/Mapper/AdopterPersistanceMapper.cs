using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;
using Infrastracture.Persistance.Dto;

namespace Infrastracture.Persistance.Mapper
{
    public static class AdopterPersistanceMapper
    {
        public static AdopterPersistanceDto ToPersistanceDto(this Adopter adopter)
        {
            return new AdopterPersistanceDto(
                adopter.FirstName,
                adopter.LastName,
                adopter.Address.Value,
                adopter.Phone.Value,
                adopter.FiscalCode.Value,
                adopter.City,
                adopter.CityCap.Value
            );
        }
        public static Adopter ToEntity(this AdopterPersistanceDto adopterDto)
        {
            return new Adopter(
                adopterDto.FirstName,
                adopterDto.LastName,
                new Email(adopterDto.Address),
                new PhoneNumber(adopterDto.Phone),
                new FiscalCode(adopterDto.FiscalCode),
                adopterDto.City,
                new Cap(adopterDto.CityCap)
            );
        }
    }
}
