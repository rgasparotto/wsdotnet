using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wsTest.Models.Data;

namespace wsTest.Models.Services.Datas
{
    public class MysqlService : IDBService

    {
        public async Task<LoginResult> login(Login credentials)
        {
            LoginResult res = new LoginResult();
            res.token = "";
            if (credentials.userName == "gas")
            {
                res.userName = credentials.userName;
                res.password = credentials.password;
                res.token = "1234";
                res.dtLog = DateTime.Now;
            }
            return res;
        }
    }
}
