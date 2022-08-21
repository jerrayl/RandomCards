using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RandomCards.Database;
using RandomCards.Business;
using RandomCards.Repositories;
using RandomCards.AutoMapper;
using RandomCards.SignalR;

namespace RandomCards
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<DatabaseContext>();

            services.AddScoped<IDeckBuilding, DeckBuilding>();
            services.AddScoped<IPlayer, Player>();
            services.AddScoped<IGame, Game>();
            services.AddScoped(typeof(IDatabaseRepository<>), typeof(DatabaseRepository<>));

            // Add Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RandomCards API", Version = "v1" });
                c.DocInclusionPredicate((_, api) => !string.IsNullOrWhiteSpace(api.GroupName));
                c.TagActionsBy(api => new[] { api.GroupName });
            });

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfileConfiguration());
            });

            services.AddCors();

            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "RandomCards");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder =>
              builder
                .WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
            );
            
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapSwagger();
                endpoints.MapHub<SignalRHub>("/signalr");
            });

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            using (var dbContext = serviceScope.ServiceProvider.GetService<DatabaseContext>())
            {
                DatabaseSeed.Seed(dbContext);
            }
        }
    }
}
