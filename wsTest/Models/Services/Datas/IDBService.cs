using System.Threading.Tasks;
using wsTest.Models.Data;

namespace wsTest.Models.Services.Datas
{
    public interface IDBService
    {
        public Task<LoginResult> login(Login credentials);
    }
}
