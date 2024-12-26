namespace MvcEFCore.Models;
public class Produto {
    public int Id { get; set; }
    public required string Nome { get; set;}
    public System.Decimal Preco { get; set; } 
}