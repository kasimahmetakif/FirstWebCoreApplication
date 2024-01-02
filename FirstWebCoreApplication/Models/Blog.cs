using FirstWebCoreApplication.Models.Abstracts;

namespace FirstWebCoreApplication.Models
{
    public class Blog:CommonProperties
    {
        public DateTime CreateDate { get; set; }
        public string? Image { get; set; }
        public string? ShortDescription { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public List<BlogLike> BlogLikes { get; set; }
        public List<Comment> BlogComments { get; set; }
    }
}
