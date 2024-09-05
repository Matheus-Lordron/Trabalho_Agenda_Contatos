using Microsoft.EntityFrameworkCore;
using Trabalho_Agenda_Contatos.Auxiliar;
using Trabalho_Agenda_Contatos.Data;
using Trabalho_Agenda_Contatos.Repositorio;

namespace Trabalho_Agenda_Contatos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var provider = builder.Services.BuildServiceProvider();
            var configuration = provider.GetService<IConfiguration>();

            // Configura o DbContext para usar o SQL Server.
            builder.Services.AddDbContext<BancoContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Database")));

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            // Adiciona o repositório de contatos como um serviço Scoped.
            builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();

            // Adiciona o repositório de usuários como um serviço Scoped.
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            builder.Services.AddScoped<ISessao, Sessao>();

            builder.Services.AddSession(o =>
            {
                o.Cookie.HttpOnly = true;
                o.Cookie.IsEssential = true;
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

           

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

