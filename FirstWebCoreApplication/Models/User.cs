using Microsoft.AspNetCore.Authentication;
using System.Diagnostics;

namespace FirstWebCoreApplication.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Image { get; set; }
        public bool IsStatus { get; set; }
        public bool IsDelete { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<BlogLike> BlogLikes { get; set; }
        public List<Comment> BlogComments { get; set; }
    }
}
