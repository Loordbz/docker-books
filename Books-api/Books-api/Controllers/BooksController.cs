using Domain.Interface.Service;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Books.Api.Controllers;

/// <summary>
///     Get all books and save books in database
/// </summary>
/// <returns>
///     Books
/// </returns>

[ApiController]
[Route("api/books")]
public class BooksController : ControllerBase
{
    private readonly IBooksService _service;

    public BooksController(IBooksService service) =>
        _service = service;

    [HttpGet]
    [ProducesResponseType(typeof(BooksDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BooksDTO), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetBossAsync()
        => Ok((await _service.GetAllBooks()).Retorno);
}