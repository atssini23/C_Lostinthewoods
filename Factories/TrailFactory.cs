using System.Collections.Generic;
using System.Linq;
using YourNamespace;
using System.Data;
using MySql.Data.MySqlClient;
using YourNamespace.Models;
using Dapper;


 
namespace YourNamespace.Factory
{
    public class TrailFactory : IFactory<Trail>
    {
        private string connectionString;
        public TrailFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=Trail;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }
        public void Create(Trail trail)
        {
            using (IDbConnection dbConnection = Connection) {
                // string query =  "INSERT INTO Trail (Name, Description, Length, Elevation, Long, Lat) VALUES (@Name, @Description, @Length, @Elevation, @Long, @Lat);";
                string query = "INSERT INTO Trail (Name, Description, Length, Elevation, Longitude, Latitude) VALUES (@Name, @Description, @Length, @Elevation, @Longitude, @Latitude)";
                dbConnection.Open();
                dbConnection.Execute(query, trail);
            }
        }
        public IEnumerable<Trail> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Trail>("SELECT * FROM Trail");
            }
        }
        public Trail FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Trail>("SELECT * FROM Trail WHERE Id = @Id", new { Id = id }).FirstOrDefault();
            }
        }
    }
}