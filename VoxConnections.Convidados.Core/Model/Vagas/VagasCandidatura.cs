using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VoxConnections.Convidados.Core
{

    [Table("tb_Candidatura_Vagas")]
    public class VagasCandidatura
    {
        [Key]
        public int IdCandidatura { get; set; }
        public int IdVaga { get; set; }
        public string IdUsuario { get; set; }

        #region Foreign Key

        public virtual Vagas Vaga { get; set; }
        public virtual Usuario Usuario { get; set; }

        #endregion

    }
}
