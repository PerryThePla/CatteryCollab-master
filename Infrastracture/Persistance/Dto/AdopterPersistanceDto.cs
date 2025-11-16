using Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.Persistance.Dto
{
    public record AdopterPersistanceDto(string FirstName, string LastName, string Address, string Phone, string FiscalCode, string City, string CityCap);
    //def
}
