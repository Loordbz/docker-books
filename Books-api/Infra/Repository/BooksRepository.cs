using Dapper;
using Domain.Interface.Service;
using Domain.Models;
using Infra.Data.Context;

namespace Infra.Repository;

public class BooksRepository : IBooksRepository
{
    private readonly Db _dbContext;

    public BooksRepository(Db context)
        => _dbContext = context;

    public async Task<IEnumerable<BooksDTO?>?> GetAllBooks()
    {
        await EnsureBooksTableExists();

        string query = "SELECT name, price, description, cover FROM books";
        var result = await _dbContext.Connection.QueryAsync<BooksDTO>
            (sql: query, commandType: System.Data.CommandType.Text);

        return result.Any() ? result.ToList() : null;
    }

    public async Task EnsureBooksTableExists()
    {
        var checkTableQuery = @"
        SELECT COUNT(*) 
        FROM information_schema.tables 
        WHERE table_schema = DATABASE() AND table_name = 'books';";

        var tableExists = await _dbContext.Connection.ExecuteScalarAsync<int>(checkTableQuery);

        if (tableExists == 0)
        {
            var createTableQuery = @"
            CREATE TABLE books (
                id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                name VARCHAR(255) NOT NULL,
                price VARCHAR(20) NOT NULL,
                description TEXT,
                cover VARCHAR(255)
            );";

            await _dbContext.Connection.ExecuteAsync(createTableQuery);
            await ApplyBooks();
        }

    }

    private async Task ApplyBooks()
    {
        var listBooks = new List<BooksDTO>()
        {
            new BooksDTO
            {
                Name = "Arduino prático",
                Price = "R$39,90",
                Description = "10 projetos para executar, aprender, modificar e dominar o mundo",
                Cover = "arduino.jpg"
            },
            new BooksDTO
            {
                Name = "MongoDB",
                Price = "R$39,90",
                Description = "Construa novas aplicações com novas tecnologias",
                Cover = "mongo.png"
            },
            new BooksDTO
            {
                Name = "Mean",
                Price = "R$39,90",
                Description = "Full stack JavaScript com MongoDB, Express, Angular e Node",
                Cover = "mean.png"
            },
            new BooksDTO
            {
                Name = "Node.js",
                Price = "R$39,90",
                Description = "Os primeiros passos com Node.js",
                Cover = "livro-node.jpg"
            },
            new BooksDTO
            {
                Name = "TDD",
                Price = "R$39,90",
                Description = "Teste e Design no Mundo Real",
                Cover = "tdd.png"
            },
            new BooksDTO
            {
                Name = "Métricas Ágeis",
                Price = "R$39,90",
                Description = "Obtenha melhores resultados em sua equipe",
                Cover = "metricas-ageis.jpg"
            }
        };

        foreach (var book in listBooks)
        {
            var query = "INSERT INTO books (name, price, description, cover) VALUES (@name, @price, @description, @cover)";

            DynamicParameters parametros = new();
            {
                parametros.Add("@name", book.Name);
                parametros.Add("@price", book.Price);
                parametros.Add("@description", book.Description);
                parametros.Add("@cover", book.Cover);
            }

            await _dbContext.Connection.QuerySingleOrDefaultAsync<BooksDTO>(query, parametros);
        }
    }

    public void Dispose()
        => _dbContext.Dispose();
}