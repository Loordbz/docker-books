using Domain.Models;
using Domain.Models.DTO;

namespace Domain.Interface.Service;

public interface IBooksRepository
{
    Task<IEnumerable<BooksDTO?>?> GetAllBooks();
    Task ApplyBooks();
}