﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VoxConnections.Convidados.Core
{
    [Table("tb_Idioma_Gestor")]
    public class IdiomaGestor
    {
        [Key]
        public int IdIdioma { get; set; }
        public string NomeIdioma { get; set; }
        public string NivelIdioma { get; set; }
        public int IdGestor { get; set; }

    }
}
