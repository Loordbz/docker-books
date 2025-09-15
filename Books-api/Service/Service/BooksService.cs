using AutoMapper;
using Domain.Interface.Service;
using Domain.Models;
using Domain.Models.DTO;

namespace Service.Service;

public class BooksService : IBooksService
{
    private readonly IBooksRepository _service;
    private readonly IMapper _mapper;

    public BooksService(IBooksRepository service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task<ResponseGenerico<IEnumerable<BooksDTO>>> GetAllBooks()
    {
        var result = await _service.GetAllBooks();
        if (result == null)
            return new ResponseGenerico<IEnumerable<BooksDTO>> { Retorno = Enumerable.Empty<BooksDTO>() };

        return new ResponseGenerico<IEnumerable<BooksDTO>> { Retorno = result! };
    }
}