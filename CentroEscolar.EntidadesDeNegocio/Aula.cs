﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEscolar.EntidadesDeNegocio
{
    public class Aula
    {    
        public int Id { get; set; }

        public int NumeroDeAula { get; set; }

        public Aula() { }

        public Aula(int pId, int pNumeroDeAula)
        {
            Id = pId;
            NumeroDeAula = pNumeroDeAula;
        }
    }
}
