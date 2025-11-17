using Application.Interfaces;
using Domain.Model.Entities;
using Infrastracture.Persistance.Dto;
using Infrastracture.Persistance.Mapper;
using System.Text.Json;
namespace Infrastracture.Persistance.Repositories
{
    public class JsonCatRepository : ICatRepository
    {
        private readonly string _filePath = "cats.json";
        private readonly Dictionary<string, Cat> _cache = new(StringComparer.OrdinalIgnoreCase);
        private bool _inizialized = false;

        public JsonCatRepository(string filePath)
        {
            _filePath = filePath;
        }
        public void EnsureLoaded()
        {
            if (_inizialized) return;
            if (!File.Exists(_filePath))
            {
                _inizialized = true; return;
            }
            var json = File.ReadAllText(_filePath);
            var catDtos = JsonSerializer.Deserialize<List<CatPersistanceDto>>(json) ?? new List<CatPersistanceDto>();
            foreach (var dto in catDtos)
            {
                var cat = dto.ToEntity();
                _cache[cat.ID] = cat;
            }
            _inizialized = true;
        }
        public void AddToRepository(Cat cat)
        {
            EnsureLoaded();
            if (_cache.ContainsKey(cat.ID))
            {
                throw new InvalidOperationException($"A cat with ID {cat.ID} already exists.");
            }
            _cache[cat.ID] = cat;
            SaveToFile();
        }
        public void RemoveFromRepository(Cat cat)
        {
            RemoveById(cat.ID);
        }
        public void UpdateInRepository(Cat cat)
        {
            EnsureLoaded();
            if (!_cache.ContainsKey(cat.ID))
            {
                throw new KeyNotFoundException($"No cat found with ID {cat.ID}.");
            }
            _cache[cat.ID] = cat;
            SaveToFile();
        }
        public void RemoveById(string id)
        {
            EnsureLoaded();
            if (!_cache.Remove(id))
            {
                throw new KeyNotFoundException($"No cat found with ID {id}.");
            }
            SaveToFile();
        }
        public IEnumerable<Cat> GetAll()
        {
            EnsureLoaded();
            return _cache.Values.ToList();
        }
        public Cat? GetById(string id)
        {
            EnsureLoaded();
            _cache.TryGetValue(id, out var cat);
            return cat;
        }
        public void SaveToFile()
        {
            var dtos = _cache.Values.Select(cat => cat.ToPersistanceDto()).ToList();
            var json = JsonSerializer.Serialize(dtos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}
