﻿using Cod3rsGrowth.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.testes
{
    public class GeneroRepositorioMock : IGeneroRepositorioMock
    {
        public List<Genero> ObterTodos()
        {
            List<Genero> generos = new List<Genero>();
            return generos;
        }
    }
}
