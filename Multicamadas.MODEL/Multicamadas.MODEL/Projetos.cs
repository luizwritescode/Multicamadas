using System;
using System.Collections.Generic;


namespace Multicamadas.MODEL
{
    public partial class Projetos
    {
        public int Id { get; set; }
        public string NomeProjeto { get; set; }
        public string NomeGerente { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public string Resumo { get; set; }
        public string Status { get; set; }
    }
}
