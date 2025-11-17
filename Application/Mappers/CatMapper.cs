using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using Domain.Model.Entities;

namespace Application.Mappers
{
    public static class CatMapper
    {
        public static Cat ToEntity(this CatDto dto)
        {
            if(dto is null){
                throw new ArgumentNullException(nameof(dto), "CatDto cannot be null.");
            }
            return new Cat(
                dto.name,
                dto.breed,
                dto.ismale,
                dto.arrivalDate,
                dto.departureDate,
                dto.birthDate,
                dto.description
            );
            //ID viene generato nel costruttore di Cat
        }
        public static CatDto ToDto(this Cat entity)
        {
            if(entity is null){
                throw new ArgumentNullException(nameof(entity), "Cat entity cannot be null.");
            }
            return new CatDto(
                name: entity.Name,
                breed: entity.Breed,
                ismale: entity.IsMale,
                arrivalDate: entity.ArrivalDate,
                departureDate: entity.DepartureDate,
                birthDate: entity.BirthDate,
                description: entity.Description,
                ID: entity.ID
            );
        }
    }
}
