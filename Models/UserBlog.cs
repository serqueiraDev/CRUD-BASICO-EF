using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    [Table("UserBlog")]
    public class UserBlog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // esta opção liga o identity no banco (1,1)
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }
        public string Bio { get; set; }
    }
}