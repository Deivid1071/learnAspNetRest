using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Business.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Repository;
using Serilog;
using RestWithASPNETUdemy.Repository.Generic;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Rewrite;

namespace RestWithASPNETUdemy
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;

            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        }       

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddControllers();
            var connection = Configuration.GetConnectionString("PostgresConnectionString");
            services.AddEntityFrameworkNpgsql().AddDbContext<PostgresContext>(options => options.UseNpgsql(connection));

            if (Environment.IsDevelopment())
            {
                MigrateDatabase(connection);
            }
            //Versioning API
            services.AddApiVersioning();

            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "REST API'S From 0 to Azure with ASP.NET Core 5 and Docker",
                        Version = "v1",
                        Description = "API RESTful developed in course  'REST API'S From 0 to Azure with ASP.NET Core 5 and Docker'",
                        Contact = new OpenApiContact 
                        {
                            Name = "Deivid Nascimento",
                            Url = new Uri ("https://github.com/deivid1071"),
                        }
                    });
            });

            //Dependency Injection 
            services.AddScoped<IPersonBusiness, PersonalBusinessImplementation>(); 
            services.AddScoped<IBookBusiness, BookBusinessImplementation>();                      

            services.AddScoped(typeof(IRepository<>), typeof(GenericRepositoryImplementation<>));
        }

        private void MigrateDatabase(string connection)
        {
            try
            {
                var evolveConnection = new Npgsql.NpgsqlConnection(connection);
                var evolve = new Evolve.Evolve(evolveConnection, msg => Log.Information(msg))
                {
                    Locations = new List<string> { "db/migrations", "db/dataset" },
                    IsEraseDisabled = true,
                };
                evolve.Migrate();

            }
            catch (Exception ex)
            {
                Log.Error("Database migration failed", ex);
                throw ;
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "REST API'S From 0 to Azure with ASP.NET Core 5 and Docker - v1");
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
