﻿using Cod3rsGrowth.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.testes
{
    public interface IGeneroRepositorio
    {
        List<Genero> ObterTodos();
        Genero ObterPorId(int id);

        String Cadastrar(Genero genero);
        String Deletar(Genero genero);
        String Atualizar(Genero genero);
    }
}
