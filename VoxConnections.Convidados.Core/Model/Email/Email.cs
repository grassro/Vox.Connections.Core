using System;
using System.Collections.Generic;
using System.Text;

namespace VoxConnections.Convidados.Core
{
    public class Email
    {
        public string NomeDestinatario { get; set; }
        public string EmailDestinatario { get; set; }
        public string Assunto { get; set; }
        public string Url { get; set; }
    }

    public class EmailHeadhunter : Email
    {
        public string NomeCandidato { get; set; }
        public string EmailCandidato { get; set; }
        public string TituloVaga { get; set; }


    }

    public class EmailCandidato : Email
    {
        public string NomeHeadhunter { get; set; }
        public string TituloVaga { get; set; }
    }

}
