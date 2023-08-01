using System.Text.Json.Serialization;

namespace relacionamentos.Models
{
    public class Fabricante
    {
        public int FabricanteId { get; set; }
        public string Nome { get; set; } = String.Empty;
        public string Telefone { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Cnpj { get; set; } = String.Empty;
        public List<Produto> produtos {get; set;}= new();
        
        
    }

    
}