using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System.Data;

namespace Infra.Data.Context;

public class Db : IDisposable
{
    public IDbConnection Connection { get; set; }

    public Db(IConfiguration configuration)
    {
        Connection = new MySqlConnection(configuration["DefaultConnection"]);
        Connection.Open();
    }
    

    public void Dispose() => Connection?.Dispose();
}
