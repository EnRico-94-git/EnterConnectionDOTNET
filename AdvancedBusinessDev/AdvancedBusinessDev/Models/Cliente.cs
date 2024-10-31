using System.Text.Json.Serialization;

namespace AdvancedBusinessDev.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string SetorAtuando { get; set; }
        public string Cep { get; set; }
        public string TempAtuacao { get; set; }
        public string Cnpj { get; set; }

        [JsonIgnore]
        public ICollection<Empresa> Empresas { get; set; }
    }
}
