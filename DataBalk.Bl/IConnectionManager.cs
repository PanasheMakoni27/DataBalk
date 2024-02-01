using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBalk.Bl
{
    public interface IConnectionManager
    {
        IDbConnection DefaultConnection();
    }
}
