using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    [Table("Category")]
    public class Category
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // esta opção liga o identity no banco (1,1)
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        [MinLength(3)]
        [Column("Name", TypeName = "NVARCHAR")]
        public string Name { get; set; }

        [Required]
        [MaxLength(80)]
        [MinLength(3)]
        [Column("Slug", TypeName = "VARCHAR")]
        public string Slug { get; set; }
    }
}