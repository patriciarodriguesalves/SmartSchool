﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Dtos
{
    public class AlunoDto
    {
        public int Id { get; set; }
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public int Idade { get; set; }
        public DateTime DataIni { get; set; } = DateTime.Now;
        public bool Ativo { get; set; } = true;
    }
}
