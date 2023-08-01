using System.Text.Json.Serialization;

namespace relacionamentos.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; } = String.Empty;
        public string Categoria { get; set; } = String.Empty;
        public int? FabricanteId {get; set;}
        [JsonIgnore]
        public Fabricante fabricante { get; set; }       
        
        
        
    }

    
}