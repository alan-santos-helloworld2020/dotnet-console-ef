using System;
using System.Linq;
using relacionamentos;
using relacionamentos.Context;
using relacionamentos.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoMapper;


namespace relacionamentos
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProdutoDto, Produto>();
            });
            
            var mapper = new Mapper(configuration);


            using (var db = new FabricaContext())
            {
                var fabricante = db.fabricantes.Where(f => f.Nome.Equals("bayer")).Include(p => p.produtos).ToList();


                var jss = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.IgnoreCycles,
                    WriteIndented = true

                };


                string res = JsonSerializer.Serialize(fabricante, jss);
                Console.WriteLine(res);

                var produtoDto = new ProdutoDto();
                produtoDto.Nome = "bypulgas";
                produtoDto.Categoria = "veneno";
                produtoDto.FabricanteId = 2;
                produtoDto.fabricante = db.fabricantes.Where(f => f.Nome.Equals("bayer")).FirstOrDefault();

                
                var pd = mapper.Map<Produto>(produtoDto);
                db.produtos.Add(pd);
                db.SaveChanges();

            }
        }

    }

}
