using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManualAuthenticationSample.Common
{
    public static class SignalrUsers
    {
        public static Dictionary<String, string> Users { get; set; } = new Dictionary<string, string>();
    }
}
