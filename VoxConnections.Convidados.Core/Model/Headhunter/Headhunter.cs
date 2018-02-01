using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VoxConnections.Convidados.Core
{
    [Table("tb_Headhunter")]
    public class Headhunter
    {

        [Key]
        public int IdHeadhunter { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Empresa { get; set; }
        public Guid IdUsuario { get; set; }
        public bool Ativo { get; set; } = true;

        #region Foreign Key

        public virtual Usuario Usuario { get; set; }

        #endregion Foreign Key
    }
}
