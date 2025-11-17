using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ValueObjects
{
    public record Cattery
    {
        public List<Cat> Cats { get; set; } = new List<Cat>();
        public List<Adoption> Adoptions { get; set; } = new List<Adoption>();
    }
}
