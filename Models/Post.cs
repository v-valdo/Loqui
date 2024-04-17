using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loqui.Models;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime Published { get; set; }
    [Required]
    public string ApplicationUserId { get; set; }

    [ForeignKey("ApplicationUserId")]
    public ApplicationUser? ApplicationUser { get; set; }
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }

    public Post()
    {
        Published = DateTime.UtcNow;
    }
}
