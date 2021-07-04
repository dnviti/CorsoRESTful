using Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Services.Interfaces
{
    public interface IAuthorService
    {
        bool SaveChanges();
        IEnumerable<Author> GetAllAuthors();
        Task<IEnumerable<Author>> GetAllAuthorsAsync();
        Author GetAuthorById(int Id);
        void CreateAuthor(Author Author);
        void UpdateAuthor(Author Author);
        void DeleteAuthor(Author Author);
    }
}
