using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.Persistance.Dto
{
    public record CatPersistanceDto(string name, string breed, bool ismale, DateOnly arrivalDate, DateOnly? departureDate, DateOnly? birthDate, string description, string ID);
}
