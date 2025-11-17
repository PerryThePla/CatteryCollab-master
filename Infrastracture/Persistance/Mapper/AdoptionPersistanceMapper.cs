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
    public static class AdoptionPersistanceMapper
    {
        public static AdoptionPersistanceDto ToPersistanceDto(this Adoption adoption)
        {
            return new AdoptionPersistanceDto(
                adoption.AdoptedCat.ToPersistanceDto(),
                adoption.AdoptionDate,
                adoption.AdopterData.ToPersistanceDto()
            );
        }
        public static Adoption ToEntity(this AdoptionPersistanceDto adoptionDto)
        {
            return new Adoption(
                adoptionDto.Cat.ToEntity(),
                adoptionDto.AdoptionDate,
                adoptionDto.Adopter.ToEntity()
            );
        }
    }
}
