namespace Lendly.Core.Domain.Model
{
    public class Category : EntityBase
    {
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
