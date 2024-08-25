using MainProgram.Models;
using MainProgram.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MainProgram
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			

			// Add services to the container.
			builder.Services.AddControllersWithViews();
			builder.Services.AddSession(option =>
			{

				option.IdleTimeout.Add(TimeSpan.FromMinutes(30));
			});
            builder.Services.AddScoped<IcourseRepository,CourseRepository>();
            builder.Services.AddScoped<IDepatmentRepository,RepositoryDepartment>();
            builder.Services.AddDbContext<itientities>(optionBulider => {
				optionBulider.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
				
				});

			builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option =>
			{
				option.Password.RequireUppercase=false;

			}).AddEntityFrameworkStores<itientities>();
	
			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStaticFiles();
			app.UseSession();
			app.UseRouting();
			app.UseAuthentication();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
