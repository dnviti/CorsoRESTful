using Data.Context;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onyce.Services.Data.Repo.SqlServer
{
    public class CorsoRESTAuthorRepo : IAuthorService
    {
        private readonly CorsoRESTDbContext _context;

        public CorsoRESTAuthorRepo(IDbContextFactory<CorsoRESTDbContext> contextFactory)
        {
            _context = contextFactory.CreateDbContext();
        }

        public void CreateAuthor(Author Author)
        {
            if (Author == null)
            {
                throw new ArgumentNullException(nameof(Author));
            }

            _context.Authors.Add(Author);
        }

        public void DeleteAuthor(Author Author)
        {
            if (Author == null)
            {
                throw new ArgumentNullException(nameof(Author));
            }

            _context.Authors.Remove(Author);
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _context.Authors.ToList();
        }

        public Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            throw new NotImplementedException();
        }

        public Author GetAuthorById(long Id)
        {
            return _context.Authors.FirstOrDefault(p => p.Id == Id);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateAuthor(Author Author)
        {
            //Nothing
        }
    }
}
