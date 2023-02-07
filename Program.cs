using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

class Program
{
    private const string CONNECTION_STRING = @"Server=127.0.0.1,1434;Database=Blog;User ID=SA;Password=vQtoFDpKdvkRtRAHqU8z5XDz2;trustServerCertificate=true;";
    static void Main(string[] args)
    {
        using var connection = new SqlConnection(CONNECTION_STRING);
        var repository = new Repository<User>(connection);

        ReadWithRoles(connection);
    }


    private static void ReadWithRoles(SqlConnection connection)
    {
        var repository = new UserRepository(connection);
        var users = repository.ReadWithRole();
        foreach (var user in users)
        {
            Console.WriteLine($"{user.Name} - {user.Email}");
            
            foreach (var role in user.Roles)
            {
                Console.WriteLine($" - {role.Slug}");
            }
        }
    }

    private static void ReadUsers()
    {
        using (var connection = new SqlConnection(CONNECTION_STRING))
        {
            var users = connection.GetAll<User>();

            foreach (var user in users)
            {
                Console.WriteLine(user.Name);
            }
        }
    }
}
