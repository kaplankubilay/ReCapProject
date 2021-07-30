using System;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        //token
        public string Token { get; set; }
        //geçerlilik süresi
        public DateTime Expiration { get; set; }
    }
}
