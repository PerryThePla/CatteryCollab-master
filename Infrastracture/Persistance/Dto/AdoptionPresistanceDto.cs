using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.Persistance.Dto
{
    public record AdoptionPersistanceDto(CatPersistanceDto Cat, DateOnly AdoptionDate, AdopterPersistanceDto Adopter);
}
