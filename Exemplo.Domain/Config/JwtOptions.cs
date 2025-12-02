using System;
using System.Collections.Generic;
using System.Text;

namespace Exemplo.Domain.Config
{
    public class JwtOptions
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpiresHours { get; set; }
    }
}
