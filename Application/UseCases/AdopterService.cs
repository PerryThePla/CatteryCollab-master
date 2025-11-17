using Application.Interfaces;
using Application.Dto;
using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Mappers;

namespace Application.UseCases
{
    public class AdopterService
    {
        public readonly IModelRepository<Adopter> _adopterRepository;
        public AdopterService(IModelRepository<Adopter> adopterRepository)
        {
            _adopterRepository = adopterRepository;
        }
        public IEnumerable<AdopterDto> GetAllAdopters()
        {
            return _adopterRepository.GetAll().Select(a=>a.ToDto());
        }
        public void AddAdopter(AdopterDto adopter)
        {
            _adopterRepository.AddToRepository(adopter.ToEntity());
        }
        public void RemoveAdopter(string fiscalcode)
        {
            Adopter? adopter = _adopterRepository.GetAll().FirstOrDefault(a => a.FiscalCode.Value == fiscalcode);
            if(adopter is null)
            {
                throw new ArgumentException("Adopter with the given fiscal code does not exist.");
            }
            _adopterRepository.RemoveFromRepository(adopter);
        }
        public void UpdateAdopter(AdopterDto adopter)
        {
            _adopterRepository.UpdateInRepository(adopter.ToEntity());
        }
    }
}
