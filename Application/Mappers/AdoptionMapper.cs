using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Entities;
using Application.Dto;

namespace Application.Mappers
{
    public static class AdoptionMapper
    {
        public static Adoption ToEntity(this AdoptionDto dto)
        {
            if(dto is null) {
                throw new ArgumentNullException(nameof(dto), "AdoptionDto cannot be null.");
            }
            return new Adoption(
                dto.Cat.ToEntity(),
                dto.AdoptionDate,
                dto.Adopter.ToEntity()
            );
        }
        public static AdoptionDto ToDto(this Adoption entity)
        {
            if(entity is null) {
                throw new ArgumentNullException(nameof(entity), "Adoption entity cannot be null.");
            }
            return new AdoptionDto(
                Cat: entity.AdoptedCat.ToDto(),
                AdoptionDate: entity.AdoptionDate,
                Adopter: entity.AdopterData.ToDto(),
                status: entity.Status
            );
        }
    }
}
