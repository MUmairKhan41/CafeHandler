using MySql.Data.MySqlClient;

namespace CafeHandler.Database
{
    public abstract class BaseRepository
    {
        // Every repository inherits this method
        // to get a database connection
        protected MySqlConnection GetConnection()
        {
            return DBHelper.GetConnection();
        }
    }
}