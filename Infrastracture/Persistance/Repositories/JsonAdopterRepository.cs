using Application.Interfaces;
using Domain.Model.Entities;
using Infrastracture.Persistance.Dto;
using Infrastracture.Persistance.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastracture.Persistance.Repositories
{
    public class JsonAdopterRepository : IModelRepository<Adopter>
    {
        private readonly string _filePath = "adopters.json";
        private readonly List<Adopter> _cache = new List<Adopter>();
        private bool _inizialized = false;
        public JsonAdopterRepository(string filePath)
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
            var dtos = new List<AdopterPersistanceDto>();
            try
            {
                dtos = JsonSerializer.Deserialize<List<AdopterPersistanceDto>>(json);
            }
            catch (Exception ex)
            {

            }

            foreach (var dto in dtos)
            {
                var Adopter = dto.ToEntity();
                _cache.Add(Adopter);
            }
            _inizialized = true;
        }
        public void AddToRepository(Adopter Adopter)
        {
            EnsureLoaded();
            if (_cache.Contains(Adopter)) throw new InvalidOperationException("This Adopter record already exists.");
            _cache.Add(Adopter);
            SaveToFile();
        }
        public void UpdateInRepository(Adopter Adopter)
        {
            EnsureLoaded();
            if (Adopter is null)
            {
                throw new ArgumentNullException(nameof(Adopter), "Adopter cannot be null.");
            }
            int index = _cache.IndexOf(Adopter);
            if (index == -1) throw new KeyNotFoundException("No matching Adopter record found to update.");
            _cache[index] = Adopter;
            SaveToFile();
        }
        public IEnumerable<Adopter> GetAll()
        {
            EnsureLoaded();
            return _cache;
        }
        private void SaveToFile()
        {
            var dtos = _cache.Select(Adopter => Adopter.ToPersistanceDto()).ToList();
            var json = JsonSerializer.Serialize(dtos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
        public void RemoveFromRepository(Adopter Adopter)
        {
            EnsureLoaded();
            if (!_cache.Remove(Adopter))
            {
                throw new KeyNotFoundException("No matching Adopter record found to remove.");
            }
            SaveToFile();
        }
    }
}
