using System.Collections.Generic;

namespace Blog.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public IList<UserBlog> UserBlogs { get; set; }
    }
}