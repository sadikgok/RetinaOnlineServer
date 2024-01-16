using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetinaOnlineServer.Infrasturcture.Authentication
{
    public sealed class JwtOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretKey { get; set; }

        public static implicit operator JwtOptions(Microsoft.Extensions.Options.IOptions<JwtOptions> v)
        {
            throw new NotImplementedException();
        }
    }
}
