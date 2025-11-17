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
    public static class CatPersistanceMapper
    {
        public static CatPersistanceDto ToPersistanceDto(this Cat cat)
        {
            return new CatPersistanceDto(
                cat.Name,
                cat.Breed,
                cat.IsMale,
                cat.ArrivalDate,
                cat.DepartureDate,
                cat.BirthDate,
                cat.Description,
                cat.ID
            );
        }
        public static Cat ToEntity(this CatPersistanceDto catDto)
        {
            return new Cat(
                catDto.name,
                catDto.breed,
                catDto.ismale,
                catDto.arrivalDate,
                catDto.departureDate,
                catDto.birthDate,
                catDto.description,
                catDto.ID
            );
        }
    }
}
