

namespace Demo.Data.Models;

[Edit(SecurityPermissionLevels.AllowAll)]
[Delete(SecurityPermissionLevels.DenyAll)]
public class Book
{
    public int BookId { get; set; }

    [Required]
    public required string Title { get; set; }

    public string? Description { get; set; }

    public DateTime? PublishDate { get; set; }

    [Required]
    public int AuthorId { get; set; }
    public Author? Author { get; set; }

    public class BookBehaviors : StandardBehaviors<Book, AppDbContext>
    {
        public BookBehaviors(CrudContext<AppDbContext> context) : base(context) { }

        public override ItemResult BeforeSave(SaveKind kind, Book? oldItem, Book item)
        {
            if(SaveKind.Create == kind && item.PublishDate is null)
            {
                item.PublishDate = DateTime.Now;
            }

            if(SaveKind.Update == kind && oldItem?.AuthorId != item.AuthorId)
            {
                return "Cannot update the author of a book";
            }

            return base.BeforeSave(kind, oldItem, item);
        }
    }
}
