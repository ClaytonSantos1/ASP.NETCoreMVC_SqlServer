
namespace MvcEFCore.Models;

public class InicializaDB {

    public static void Inicialize(ProdutoContexto context) {

        context.Database.EnsureCreated();

        //Procura por produtos
        if (context.Produtos.Any()){

            return; //O BD doi alimento
        }

        var produtos = new Produto[] {
            new Produto{Nome="Sacolé Goumert", Preco=10.00M},
            new Produto{Nome="Pastel", Preco=12.00M},
        };

        foreach(Produto p in produtos){
            context.Produtos.Add(p);
        }

        context.SaveChanges();
    }
}