using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Entities;
using Application.Dto;

namespace Application.Mappers
{
    public static class AdopterMapper
    {
        public static AdopterDto ToDto(this Adopter entity)
        {
            if(entity is null) {
                throw new ArgumentNullException(nameof(entity), "Adopter entity cannot be null.");
            }
            return new AdopterDto(
                FirstName: entity.FirstName,
                LastName: entity.LastName,
                Address: entity.Address,
                Phone: entity.Phone,
                FiscalCode: entity.FiscalCode,
                City: entity.City,
                CityCap: entity.CityCap
            );
        }
        public static Adopter ToEntity(this AdopterDto dto)
        {
            if(dto is null) {
                throw new ArgumentNullException(nameof(dto), "AdopterDto cannot be null.");
            }
            return new Adopter(
                dto.FirstName,
                dto.LastName,
                dto.Address,
                dto.Phone,
                dto.FiscalCode,
                dto.City,
                dto.CityCap
            );
        }
    }
}
