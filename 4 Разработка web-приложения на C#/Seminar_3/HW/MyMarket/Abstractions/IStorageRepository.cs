using MyMarket.DTO;

namespace MyMarket.Abstractions
{
    public interface IStorageRepository
    {
        public int AddStorage(StorageViewModel storageViewModel);
        public IEnumerable<StorageViewModel> GetStorages();
        public int DeleteStorage(int Id);
    }
}
