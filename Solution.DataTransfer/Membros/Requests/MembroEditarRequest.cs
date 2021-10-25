﻿using Solution.Dominio.Faccoes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DataTransfer.Membros.Requests
{
    public class MembroEditarRequest
    {
        public string Nome { get; set; }
        public string NomeVulgo { get; set; }
        public int Idade { get; set; }
        public Faccao Faccao { get; set; }
        public DateTime DataBatismo { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Referencia { get; set; }
        public string Matricula { get; set; }
        public string Foto { get; set; }
        public string CPF { get; set; }
        public string NomeMae { get; set; }
        public bool Obito { get; set; }
        public DateTime DataObito { get; set; }
        public string LocalObito { get; set; }
        public string Caracteristicas { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DataDesativacao { get; set; }
        public string MotivoDesativacao { get; set; }
    }
}
