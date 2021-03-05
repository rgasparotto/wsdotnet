using System;

namespace wsTest.Models.Data
{
    public class LoginResult: Login
    {
        public string token { get; set; }
        public DateTime dtLog { get; set; }

    }
}
