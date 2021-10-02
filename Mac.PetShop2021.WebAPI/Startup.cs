
using Mac.PetShop2021comp.Domain.IRepositories;
using Mac.PetShop2021comp.Domain.Services;
using Mac.PetShop2021comp1.Core.IServices;
using Mac.PetShop2021comp1.EFCore;
using Mac.PetShop2021comp1.EFCore.Repositories;
using Mac.PetShop2021comp1.Infrastructure.DataAcces.PetShop2021.Infrastructure.Static.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using IPetTypeRepository = Mac.PetShop2021comp.Domain.IRepositories.IPetTypeRepository;
using OwnerRepository = Mac.PetShop2021comp1.EFCore.Repositories.OwnerRepository;

namespace Mac.PetShop2021.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Mac.PetShop2021.WebAPI", Version = "v1"});
            });
            
            var loggerFactory = LoggerFactory.Create(builder => {
                    builder.AddConsole();
                }
            );

            services.AddDbContext<PetShopContext>(
                opt =>
                {
                    opt.UseLoggerFactory(loggerFactory).
                    UseSqlite("Data Source = MyDatabase.db"); 
                });

            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetService, PetService>();
            
            services.AddScoped<IPetTypeRepository, PetTypeRepository>();
            services.AddScoped<IPetTypeService, PetTypeService>();

            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IOwnerService, OwnerService>();

            services.AddScoped<IInsuranceRepository, InsuranceRepository>();
            services.AddScoped<IInsuranceService, InsuranceService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mac.PetShop2021.WebAPI v1"));

                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<PetShopContext>();
                    ctx.Database.EnsureDeleted();
                    ctx.Database.EnsureCreated();
                }
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}