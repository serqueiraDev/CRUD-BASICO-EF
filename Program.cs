using Blog.Data;
using Blog.Models;
using System.Linq;

namespace Blog
{
    public class Program
    {
        private static void Main(string[] args)
        {
            using var context = new BlogDataContext();

            //context.UserBlogs.Add(new UserBlog() { 
            //    Bio = "Dev FullCycle",
            //    Email = "maine@maine.com",
            //    Image = "https://maine.io",
            //    Name = "Maine Serqueira",
            //    PasswordHash = "123456",
            //    Slug = "maine-serqueira"
            //});

            var user = context.UserBlogs.FirstOrDefault(x => x.Id == 2);

            context.Posts.Add(new Post()
            {
                Author = user,
                Category = new Category()
                {
                    Name = "FrontEnd",
                    Slug = "frontend"
                },
                Body = "Meu ARTIGO",
                Title = "Meu artigo",
                Slug = "meu-artigo",
                Summary = "Neste artigo, vamos conferir...",
                CreateDate = System.DateTime.Now,

            });

            context.SaveChanges();
        }
    }
}