using MongoDB.Driver;

namespace noSQLportal.Models
{
    public class Settings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}