using Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public record AdopterDto(string FirstName, string LastName, Email Address, PhoneNumber Phone, FiscalCode FiscalCode, string City, Cap CityCap);
}
