using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAcar.Persistence.Services
{
    public interface IAuthServices
    {
        string GenerateToken();
    }
}
