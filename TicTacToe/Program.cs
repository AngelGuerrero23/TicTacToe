using TicTacToe.Components;
using TicTacToe.DAL;
using Microsoft.EntityFrameworkCore;

namespace TicTacToe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



             //Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            //Para obtener el ConStr para usarlo en el contexto
            var ConStr = builder.Configuration.GetConnectionString("SqlConStr");

            //Para agregar el contexto al builder con el ConStr
            builder.Services.AddDbContextFactory<Contexto>(o => o.UseSqlServer(builder.Configuration.GetConnectionString(ConStr)));

            
            var app = builder.Build();
            
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
            
        }
    }
}
