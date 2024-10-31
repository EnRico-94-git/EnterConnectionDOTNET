using System.Text.Json.Serialization;

namespace AdvancedBusinessDev.Models
{
    public class Empresa
    {
        public int EmpresaId { get; set; }
        public string Cnpj { get; set; }
        public string Cep { get; set; }
        public string TempAtuacao { get; set; }
        public string Especializacao { get; set; }
        public int? ParceiroIdParceiro { get; set; }
        public int? ClienteIdCliente { get; set; }

        [JsonIgnore]
        public Cliente Cliente { get; set; }  
        public ICollection<IA> IAs { get; set; }  
    }

}
