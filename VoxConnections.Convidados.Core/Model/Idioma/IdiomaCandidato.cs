using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoxConnections.Convidados.Core
{
    [Table("tb_Idioma_Candidato")]
    public class IdiomaCandidato
    {
        [Key]
        public int IdIdioma { get; set; }
        public string NomeIdioma { get; set; }
        public string NivelIdioma { get; set; }
        public int IdCandidato { get; set; }

    }
}