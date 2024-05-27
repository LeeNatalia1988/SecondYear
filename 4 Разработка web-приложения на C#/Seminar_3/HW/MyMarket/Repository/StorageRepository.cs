using AutoMapper;
using MyMarket.Abstractions;
using MyMarket.DB;
using MyMarket.DTO;
using MyMarket.Models;
using Microsoft.Extensions.Caching.Memory;

namespace MyMarket.Repository
{
    public class StorageRepository : IStorageRepository
    {
        private readonly IMapper _mapper;
        private IMemoryCache _memoryCache;

        public StorageRepository(IMapper mapper, IMemoryCache memoryCache)
        {
            _mapper = mapper;
            _memoryCache = memoryCache;
        }
        public int AddStorage(StorageViewModel storageViewModel)
        {
            using (var context = new ProductContext())
            {
                var entityStorage = context.Storages.FirstOrDefault(x => x.Name.ToLower().Equals(storageViewModel.Name.ToLower()));
                if (entityStorage == null)
                {
                    var entity = _mapper.Map<Storage>(storageViewModel);
                    context.Storages.Add(entity);
                    context.SaveChanges();
                    _memoryCache.Remove("storage");
                    return entity.Id;
                }
                else
                {
                    throw new Exception("Storage already exist");
                }
            }
        }

        public int DeleteStorage(int Id)
        {
            using (var context = new ProductContext())
            {
                var entityStorage = context.Storages.FirstOrDefault(x => x.Id.Equals(Id));
                if (entityStorage != null)
                {
                    context.Storages.Remove(entityStorage);
                    context.SaveChanges();
                    _memoryCache.Remove("storage");
                    return entityStorage.Id;
                }
                else
                {
                    throw new Exception("Storage not exist");
                }
            }
        }

        public IEnumerable<StorageViewModel> GetStorages()
        {
            if (_memoryCache.TryGetValue("storage", out List<StorageViewModel> storageCache))
            {
                return storageCache;
            }
            using (var context = new ProductContext())
            {
                var storage = context.Storages.Select(_mapper.Map<StorageViewModel>).ToList();
                _memoryCache.Set("storage", storage, TimeSpan.FromMinutes(30));
                return storage;
            }
        }
    }
}
