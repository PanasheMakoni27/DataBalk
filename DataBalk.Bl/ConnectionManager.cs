using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace DataBalk.Bl
{
    public class ConnectionManager:IConnectionManager
    {
        private readonly IConfiguration _configuration;

        public ConnectionManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection DefaultConnection()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection") + "Pooling=true;";
            return new SqlConnection(connectionString);
        }

    }
}
