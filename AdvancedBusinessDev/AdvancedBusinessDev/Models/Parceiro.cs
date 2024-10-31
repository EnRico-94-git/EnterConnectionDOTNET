using System.Text.Json.Serialization;

namespace AdvancedBusinessDev.Models
{
    public class Parceiro
    {
        public int IdParceiro { get; set; }
        public string NomeParceiro { get; set; }
        public string AreaAtuando { get; set; }
        public string AvaliacaoDesempenho { get; set; }
        public string TipoParceria { get; set; }

        [JsonIgnore]
        public ICollection<IA> IAs { get; set; }
        public ICollection<Empresa> Empresas { get; set; }
    }
}
