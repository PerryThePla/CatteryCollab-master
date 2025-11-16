using Application.Dto;
using Application.Interfaces;
using Application.Mappers;
using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class AdoptionService
    {
        private readonly IAdoptionRepository _adoptoinRepository;
        public AdoptionService(IAdoptionRepository adoptionRepository)
        {
            _adoptoinRepository = adoptionRepository;
        }
        public void Create(AdoptionDto dto)
        {
            dto = dto ?? throw new ArgumentNullException(nameof(dto), "AdopterDto cannot be null.");
            Adoption adoption=dto.ToEntity();
            _adoptoinRepository.AddToRepository(adoption);
        }
        public IEnumerable<AdoptionDto> GetAllAdoptions()
        {
            return _adoptoinRepository.GetAll().Select(a=>a.ToDto());
        }
        public void CancelAdoption(AdoptionDto dto)
        {
            if(dto is null) {
                throw new ArgumentNullException(nameof(dto), "AdoptionDto cannot be null.");
            }
            Adoption adoption = dto.ToEntity();
            adoption.AdoptedCat.DepartureDate = null;
            adoption.CancelAdoption();
            _adoptoinRepository.UpdateInRepository(adoption);
        }
        public IEnumerable<AdoptionDto>? GetAdoptionsByAdoptionDate(DateOnly date)
        {
            return _adoptoinRepository.GetAdoptionsByDate(date).Select(adoption => adoption.ToDto());
            //def finale
        }
    }
}
