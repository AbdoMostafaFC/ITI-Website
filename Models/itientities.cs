using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MainProgram.Models
{
	public class itientities:IdentityDbContext<ApplicationUser>
	{
		public itientities() : base()
		{


		}
        public itientities(DbContextOptions<itientities> options): base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=MainDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
		}
		public DbSet<course> Courses { get; set; }
		public DbSet<trainee> trainees { get; set; }
		public DbSet<Department> departments { get; set; }
		public DbSet<CrsResult> crsResults { get; set; }
		public DbSet<instructor> instructors { get; set; }

	}
}
