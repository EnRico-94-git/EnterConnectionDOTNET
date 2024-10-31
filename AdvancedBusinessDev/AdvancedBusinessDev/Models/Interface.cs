using System.Text.Json.Serialization;

namespace AdvancedBusinessDev.Models
{
    public class Interface
    {
        public int IdInterface { get; set; }
        public string NomeInterface { get; set; }
        public string Funcionalidade { get; set; }
        public string Estilo { get; set; }
        public string Linguas { get; set; }
        public int? ClienteIdCliente { get; set; }
        public int? IaIdIa { get; set; }

        [JsonIgnore]
        public IA IA { get; set; }  
    }
}
