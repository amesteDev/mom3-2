using Microsoft.EntityFrameworkCore;
using records.Models;

namespace records.Data
{
	public class CollectionContext : DbContext
	{
		public CollectionContext(DbContextOptions<CollectionContext> options)
			: base(options)
		{
		}

		public DbSet<Collection> Collection { get; set; }
		public DbSet<Artist> Artist { get; set; }
		public DbSet<Borrower> Borrower { get; set; }
	}
}