using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class Repository<T> where T:class
    {
        private readonly SqlConnection _connection;
        public Repository(SqlConnection connection)
        {
            _connection = connection;
        }

        public void Add(T entity)
        {
            _connection.Insert(entity);
        }

        public List<T> Read()
        {
            return _connection.GetAll<T>().ToList();
        }
        
        public T Read(int id)
        {
           return  _connection.Get<T>(id);
        }


        public void Update(T entity)
        {
            _connection.Update(entity);
        }

        public void Delete(T entity)
        {
            _connection.Delete(entity);
        }
        
        
    }
}
