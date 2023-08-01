using System;
using System.Linq;
using relacionamentos;
using relacionamentos.Context;
using relacionamentos.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace relacionamentos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new FabricaContext())
            {
                var fabricante = db.fabricantes.Where(f => f.Nome.Equals("kibon")).Include(p => p.produtos).ToList();


                var jss = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.IgnoreCycles,
                    WriteIndented = true

                };


                string res = JsonSerializer.Serialize(fabricante, jss);
                Console.WriteLine(res);

                var pd = new Produto();
                pd.Nome = "pudim";
                pd.Categoria = "sobremesas";
                pd.fabricante = fabricante.Where(fb => fb.FabricanteId == 2).First();                 
                db.produtos.Add(pd);
                db.SaveChanges();

            }
        }

    }

}
