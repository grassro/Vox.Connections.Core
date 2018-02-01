using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VoxConnections.Convidados.Core
{

    [Table("tb_Curriculo")]
    public class Curriculo
    {
        [Key]
        public int IdCurriculo { get; set; }
        public byte[] CurriculumVitae { get; set; }
        public string FileNameCurriculumVitae { get; set; }
        public string FileTypeCurriculumVitae { get; set; }
    }
}
