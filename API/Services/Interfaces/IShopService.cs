using Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IShopService
    {
        bool SaveChanges();
        IEnumerable<Shop> GetAllShops();
        Task<IEnumerable<Shop>> GetAllShopsAsync();
        Shop GetShopById(int Id);
        void CreateShop(Shop Shop);
        void UpdateShop(Shop Shop);
        void DeleteShop(Shop Shop);
    }
}
