using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VoxConnections.Convidados.Core
{
    public class AreaAtuacao
    {
        [Key]
        public int IdAreaAtuacao { get; set; }
        public string Descricao { get; set; }
    }
}
