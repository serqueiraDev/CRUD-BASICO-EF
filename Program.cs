using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;

namespace Blog
{
    public class Program
    {
        private static void Main(string[] args)
        {
            using (var context = new BlogDataContext())
            {
                //var tag = new Tag { Name = "ASP", Slug = "asp" };
                //context.Tags.Add(tag);
                //context.SaveChanges();

                //var tag2 = new Tag { Name = "GOlang", Slug = "golang" };
                //context.Tags.Add(tag2);
                //context.SaveChanges();

                //var tag3 = new Tag { Name = ".NET", Slug = ".net" };
                //context.Tags.Add(tag3);
                //context.SaveChanges();

                //var tag4 = new Tag { Name = "JUPITER", Slug = "jupiter" };
                //context.Tags.Add(tag4);
                //context.SaveChanges();

                //var tag5 = new Tag { Name = "HTML", Slug = "html" };
                //context.Tags.Add(tag5);
                //context.SaveChanges();

                //var tag6 = new Tag { Name = "CSS", Slug = "css" };
                //context.Tags.Add(tag6);
                //context.SaveChanges();

                // Sempre que atualizar uma informação, leia ela do banco, este processo chama-se Re-Hidratação
                // New sempre é recomendado para create, se ler do new pode dar diversos problemas.
                //var tag = context.Tags.FirstOrDefault(x => x.Id == 1);
                //tag.Name = ".NET";
                //tag.Slug = "dotnet";
                //context.Update(tag);
                //context.SaveChanges();

                //var tag = context.Tags.FirstOrDefault();                
                //context.Remove(tag);
                //context.SaveChanges();

                // Este comando apenas trás um tipo DbSet<>
                //var tags = context.Tags;

                //var tags = context
                //            .Tags
                //            .AsNoTracking() // --> Não trás metadados, desabilita o traking para consulta, melhora na performance
                //            .Where(x => x.Name.Contains(".NET")) // --> Filtro.
                //            .ToList(); // --> Comando que executa a query no banco, recomendado sempre ser o último comando, sempre após o filtro
                //                       // --> Pois o ToList() faz um select * from em toda a tabela
                //                       // --> Por este motivo é importante ser feito após o filtro, filtra em memória e depois vai no banco.

                //foreach (var tag in tags)
                //{
                //    Console.WriteLine(tag.Name);
                //}

                var tags = context
                            .Tags
                            .AsNoTracking() // --> Não trás metadados, desabilita o traking para consulta, melhora na performance
                            //.FirstOrDefault(x => x.Id == 55); // --> Este comando caso tenha 3 Ids iguais trará o primeiro que o banco enviar, ou utliza ele ou ToList()
                                                              // --> Se o item não existir ele trás null
                                                              //.First(); // --> Se o item não existir ele da erro 
                                                              //.ToList(); // --> Comando que executa a query no banco, recomendado sempre ser o último comando, sempre após o filtro
                                                              // --> Pois o ToList() faz um select * from em toda a tabela
                                                              // --> Por este motivo é importante ser feito após o filtro, filtra em memória e depois vai no banco.
                            .SingleOrDefault(x => x.Id == 55); // --> Este comando caso tenha 3 Ids iguais dará erro.


                Console.WriteLine(tags?.Name); // --> ? SIGNIFICA o null safe ou seja, se tiver o Name trás o nome se não, não faz nada.
               
                
                
            }
        }
    }
}