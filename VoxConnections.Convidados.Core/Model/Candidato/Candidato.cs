using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VoxConnections.Convidados.Core
{

    [Table("tb_Candidato")]
    public class Candidato
    {

        [Key]
        public int IdCandidato { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Linkedin { get; set; }
        public string Formacao { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Celular { get; set; }
        public string NivelEscolaridade { get; set; }
        public string AreaAtuacao { get; set; }
        public string NivelFuncao { get; set; }
        public int IdCurriculo { get; set; }
        public string AreaInteresse { get; set; }
        public bool Empregado { get; set; }
        public string Esfera { get; set; }
        public string AreaExecutiva { get; set; }
        public string Link { get; set; }
        public string Empresa { get; set; }
        public Guid IdUsuario { get; set; }
        public bool Ativo { get; set; } = true;

        #region Foreign Key

        public virtual IList<IdiomaCandidato> Idiomas { get; set; }
        public virtual Curriculo Curriculo { get; set; }
        public virtual Usuario Usuario { get; set; }

        #endregion Foreign Key

    }
}
