using Microsoft.EntityFrameworkCore;
using TicTacToe.Components;
using TicTacToe.DAL;
using TicTacToe.Services;

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

            ////Para obtener el ConStr para usarlo en el contexto
            //var ConStr = builder.Configuration.GetConnectionString("SqlConStr");

            ////Para agregar el contexto al builder con el ConStr
            //builder.Services.AddDbContextFactory<Contexto>(o => o.UseSqlServer(ConStr));

            //Inyeccion del API
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://gestionhuacalesapi.azurewebsites.net/") });

            //Inyeccion del service
            builder.Services.AddScoped<Contexto>();
            builder.Services.AddScoped<JugadoresService>();

            builder.Services.AddScoped<PartidasService>();
            builder.Services.AddScoped<MovimientosService>();

            var app = builder.Build();
            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
            
        }
    }
}
