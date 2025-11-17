using Application.Interfaces;
using Domain.Model.Entities;
using Infrastracture.Persistance.Dto;
using Infrastracture.Persistance.Mapper;
using System.Text.Json;

namespace Infrastracture.Persistance.Repositories
{
    public class JsonAdoptionRepository : IAdoptionRepository
    {
        private readonly string _filePath = "adoptions.json";
        private readonly List<Adoption> _cache = new List<Adoption>();
        private bool _inizialized = false;
        public JsonAdoptionRepository(string filePath)
        {
            _filePath = filePath;
        }
        public void EnsureLoaded()
        {
            if (_inizialized)
            {
                return;
            }
            if (!File.Exists(_filePath))
            {
                _inizialized = true;
                return;
            }
            var json = File.ReadAllText(_filePath);
            var dtos=new List<AdoptionPersistanceDto>();
            try
            {
                dtos = JsonSerializer.Deserialize<List<AdoptionPersistanceDto>>(json);
            }
            catch (Exception ex)
            {
                 
            }
            
            foreach(var dto in dtos)
            {
                var adoption=dto.ToEntity();
                _cache.Add(adoption);
            }
            _inizialized = true;
        }
        public void AddToRepository(Adoption adoption)
        {
            EnsureLoaded();
            if(_cache.Contains(adoption)) throw new InvalidOperationException("This adoption record already exists.");
            adoption.AdoptedCat.DepartureDate = adoption.AdoptionDate;
            _cache.Add(adoption);
            SaveToFile();
        }
        public void UpdateInRepository(Adoption adoption)
        {
            EnsureLoaded();
            if (adoption is null)
            {
                throw new ArgumentNullException(nameof(adoption), "Adoption cannot be null.");
            }
            int index=_cache.IndexOf(adoption);
            if(index==-1) throw new KeyNotFoundException("No matching adoption record found to update.");
            _cache[index] = adoption;
            SaveToFile();
        }
        public IEnumerable<Adoption> GetAll()
        {
            EnsureLoaded();
            return _cache;
        }
        public IEnumerable<Adoption> GetAdoptionsByDate(DateOnly date)
        {
            EnsureLoaded();
            return _cache.Where(a => a.AdoptionDate == date);
        }
        private void SaveToFile()
        {
            var dtos=_cache.Select(adoption => adoption.ToPersistanceDto()).ToList();
            var json = JsonSerializer.Serialize(dtos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
        public void RemoveFromRepository(Adoption adoption)
        {
            EnsureLoaded();
            if(!_cache.Remove(adoption))
            {
                throw new KeyNotFoundException("No matching adoption record found to remove.");
            }
            SaveToFile();
        }
    }
}
