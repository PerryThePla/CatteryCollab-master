using Application.Interfaces;
using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using Application.Mappers;

namespace Application.UseCases
{
    public class CatService
    {
        private readonly ICatRepository _catRepository;
        public CatService(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }
        public void Remove(string id) {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id), "ID cannot be null or empty.");
            }
            Cat? cat = _catRepository.GetById(id);
            if (cat is null)
            {
                throw new InvalidOperationException("Cat with the specified ID does not exist.");
            }
            _catRepository.RemoveById(id);
        }
        public IEnumerable<CatDto> GetAllCats()
        {
            return _catRepository.GetAll().Select(cat=>cat.ToDto());
        }
        public Cat? GetCatById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id), "ID cannot be null or empty.");
            }
            return _catRepository.GetById(id);
        }
        public void AddCat(CatDto dto)
        {
            if(dto is null)
            {
                throw new ArgumentNullException(nameof(dto), "Cat cannot be null.");
            }
            Cat cat = dto.ToEntity();
            if (_catRepository.GetById(cat.ID) is not null)
            {
                throw new InvalidOperationException("A cat with the same ID already exists.");
            }
            _catRepository.AddToRepository(cat);
        }
        public void UpdateDepartureDate(string id, DateOnly? departureDate)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id), "ID cannot be null or empty.");
            }
            Cat? cat = _catRepository.GetById(id);
            if (cat is null)
            {
                throw new InvalidOperationException("Cat with the specified ID does not exist.");
            }
            cat.UpdateDepartureDate(departureDate);
            _catRepository.UpdateInRepository(cat);
        }
    }
}
