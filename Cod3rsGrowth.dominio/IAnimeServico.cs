﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.dominio
{
    public interface IAnimeServico
    {
        List<Anime> ObterTodos();
        Anime ObterPorId(int id);
        String Cadastrar(Anime anime);
        String Deletar(Anime anime);
        String Atualizar(Anime anime);
    }
}