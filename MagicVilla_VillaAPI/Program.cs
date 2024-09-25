
using MagicVilla_VillaAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //Add Db connectoin
            builder.Services.AddDbContext<ApplicationDbContext>(option => { 
                option.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultSQLConection")
                ); 
            });
            //


            builder.Services.AddControllers();

            //Add Razor
            builder.Services.AddRazorPages();
            //

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //Add
           app.UseRouting();
            //
            app.UseHttpsRedirection();

            app.UseAuthorization();
            

            app.MapControllers();

            //Add
            app.UseEndpoints(endpoints => {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
            //

            app.Run();
        }
    }
}
