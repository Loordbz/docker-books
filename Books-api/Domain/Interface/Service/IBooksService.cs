using Domain.Models;
using Domain.Models.DTO;

namespace Domain.Interface.Service;

public interface IBooksService
{
    Task<ResponseGenerico<IEnumerable<BooksDTO>>> GetAllBooks();
}