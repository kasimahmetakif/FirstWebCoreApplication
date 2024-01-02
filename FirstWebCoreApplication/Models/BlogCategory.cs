using System.ComponentModel.DataAnnotations.Schema;

namespace FirstWebCoreApplication.Models
{
    public class BlogCategory
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        [ForeignKey("BlogId")]
        public Blog Blog { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
