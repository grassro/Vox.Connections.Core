using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VoxConnections.Convidados.Core
{

    [Table("tb_Vagas")]
    public class Vagas
    {
        [Key]
        public int IdVaga { get; set; }
        public string Titulo { get; set; }
        public string AreaAtuacao { get; set; }
        public string Descricao { get; set; }
        public string NivelEscolaridade { get; set; }
        public string NivelFuncao { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string TipoContratacao { get; set; }
        public int IdHeadhunter { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
        public bool Ativo { get; set; } = true;

        [NotMapped]
        public bool Candidatou { get; set; }

        #region Foreign Key

        public virtual IList<IdiomaVaga> Idiomas { get; set; }
        public virtual Headhunter Headhunter { get; set; }

        #endregion


    }
}
