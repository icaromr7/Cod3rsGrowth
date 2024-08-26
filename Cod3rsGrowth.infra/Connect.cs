using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Infra
{
    public sealed class Connect
    {
        public static string connectionString { get; set; } = ConstantesDoRepositorio.CONNECTION_STRING;
    }
}
