using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Blog
{
    public class Program
    {
        private static void Main(string[] args)
        {
            using var context = new BlogDataContext();

            //var userBlog = new UserBlog()
            //{
            //    Name = "Eduardo Serqueira",
            //    Slug = "eduardoserqueira",
            //    Email = "edu.test@test.com",
            //    Bio = "Dev .NET",
            //    Image = "https:\\edu.io",
            //    PasswordHash = "1234567890"
            //};

            //var category = new Category()
            //{
            //    Name = "Backend",
            //    Slug = "backend"
            //};

            //// No caso do objeto post houve uma referencia aos objetos User e Category e note que
            //// os objetos User e Category não está sendo passado o campo ID, pois o entity já entendi
            //// que estes objetos não existem no banco e serão criados e por último será criado o objeto User
            //var post = new Post()
            //{
            //    Author = userBlog,
            //    Category = category,
            //    Body = "<p>Hello World</p>",
            //    Slug = "comecando-com-ef-core",
            //    Summary = "Neste artigo vamos aprender EF Core",
            //    Title = "Começando com EF Core",
            //    CreateDate = DateTime.Now,
            //    LastUpdateDate = DateTime.Now
            //};

            //// Adicionou os itens em memória através do objeto post
            //context.Posts.Add(post);
            //// Com o SaveChanges executa o context e salva as informações no banco.
            //context.SaveChanges();

            //var posts = context
            //    .Posts
            //    .AsNoTracking()
            //    .OrderByDescending(x => x.LastUpdateDate)
            //    .ToList();

            //foreach (var post in posts)
            //{
            //    Console.WriteLine($"{post.Title}");
            //}

            var posts = context
                .Posts
                .AsNoTracking()
                //.Include(x => x.Author)
                .Where(x => x.AuthorId == 1)
                .OrderByDescending(x => x.LastUpdateDate)
                .ToList();

            //// Este é o mesmo select acima
            //// SELECT Post.Title, UserBlog.Name
            //// FROM Post inner join UserBlog
            //// ON Post.AuthorId = UserBlog.Id
            //// WHERE Post.AuthorId = 1
            //// Order by Post.LastUpdateDate Desc;

            foreach (var post in posts)
            {
                Console.WriteLine($"{post.Title} escrito por {post.Author?.Name}");
                //--> {post.Author?.Name} ? é um if que válida se não tiver author não retorne erro.
            }
        }
    }
}