using System.Text.Json.Serialization;

namespace AdvancedBusinessDev.Models
{
    public class IA
    {
        public int IdIa { get; set; }
        public string HistRecomendacao { get; set; }
        public string Tecnologias { get; set; }
        public string BancoDados { get; set; }
        public string Dados { get; set; }
        public int? ParceiroIdParceiro { get; set; }
        public int? EmpresaEmpresaId { get; set; }

        // Relacionamentos
        [JsonIgnore]
        public Empresa Empresa { get; set; }  
        public Parceiro Parceiro { get; set; }  
        public ICollection<Interface> Interfaces { get; set; }  
    }
}
