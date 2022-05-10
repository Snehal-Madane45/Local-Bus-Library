using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalBussPassLibrary.Common
{
    public class AuthResponse
    {
        public string token { get; set; }
        public int passengerId { get; set; }
    }
}
