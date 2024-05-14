using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.testes
{
    public class TesteBase : IDisposable
    {
        protected ServiceProvider FornecedorDeServicos;
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
