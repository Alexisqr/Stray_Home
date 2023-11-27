using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Contracts.Persistence
{
    public interface IPasswordHasher
    {
        string Hash(string password, out byte[] salt);
        bool Verify(string password,string hash, byte[] salt);
    }
}
