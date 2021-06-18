using Data.Context;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.Repo.CorsoRESTRepo
{
    public class CorsoRESTShopRepo : IShopService
    {
        private readonly CorsoRESTDbContext _context;

        public CorsoRESTShopRepo(IDbContextFactory<CorsoRESTDbContext> contextFactory)
        {
            _context = contextFactory.CreateDbContext();
        }

        public void CreateShop(Shop Shop)
        {
            if (Shop == null)
            {
                throw new ArgumentNullException(nameof(Shop));
            }

            _context.Shops.Add(Shop);
        }

        public void DeleteShop(Shop Shop)
        {
            if (Shop == null)
            {
                throw new ArgumentNullException(nameof(Shop));
            }

            _context.Shops.Remove(Shop);
        }

        public IEnumerable<Shop> GetAllShops()
        {
            return _context.Shops.ToList();
        }

        public Task<IEnumerable<Shop>> GetAllShopsAsync()
        {
            throw new NotImplementedException();
        }

        public Shop GetShopById(int Id)
        {
            return _context.Shops.FirstOrDefault(p => p.Id == Id);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateShop(Shop Shop)
        {
            //Nothing
        }
    }
}
