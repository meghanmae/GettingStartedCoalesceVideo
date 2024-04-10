
namespace Demo.Data.Models;
public class Author
{
    public int AuthorId { get; set; }

    [Required]
    public required string Name { get; set; }

    public ICollection<Book> Books { get; set; } = [];

    public class AuthorDataSource : StandardDataSource<Author, AppDbContext>
    {
        public AuthorDataSource(CrudContext<AppDbContext> context) : base(context) { }

        public override IQueryable<Author> GetQuery(IDataSourceParameters parameters)
        {
            return base.GetQuery(parameters).Where(x => x.Books.Any());
        }
    }
}
