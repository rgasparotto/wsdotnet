using System.Collections.Generic;
using System.Threading.Tasks;
using wsTest.Models.Data;

namespace wsTest.Models.Services.Datas
{
    public interface IDBService
    {
        public Task<LoginResult> login(Login credentials);
        public Task<List<User>> GetAll();
        public Task<LoginResult> GetById(int id);
    }
}
