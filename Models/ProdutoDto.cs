using System.Text.Json.Serialization;

namespace relacionamentos.Models
{
    public class ProdutoDto
    {

        public string Nome { get; set; } = String.Empty;
        public string Categoria { get; set; } = String.Empty;
        public int? FabricanteId {get; set;}
        public Fabricante? fabricante { get; set; }      
        
        
    }

    
}